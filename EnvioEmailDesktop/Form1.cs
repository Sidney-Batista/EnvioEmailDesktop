using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EnvioEmailDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddRecipient_Click(object sender, EventArgs e)
        {
            var text = txtNewRecipient.Text?.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Digite um e-mail ou 'email,nome'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TryParseRecipient(text, out var email, out var name))
            {
                lstRecipients.Items.Add(string.IsNullOrEmpty(name) ? email : $"{email},{name}");
                txtNewRecipient.Clear();
            }
            else
            {
                MessageBox.Show("Formato inválido. Use 'email' ou 'email,nome'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveRecipient_Click(object sender, EventArgs e)
        {
            var selected = lstRecipients.SelectedIndices;
            if (selected.Count == 0) return;

            // remove from last to first to keep indices valid
            for (int i = selected.Count - 1; i >= 0; i--)
            {
                lstRecipients.Items.RemoveAt(selected[i]);
            }
        }

        private async void btnLoadFile_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = await File.ReadAllLinesAsync(ofd.FileName);
                var added = 0;
                foreach (var line in lines.Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)))
                {
                    if (TryParseRecipient(line, out var email, out var name))
                    {
                        lstRecipients.Items.Add(string.IsNullOrEmpty(name) ? email : $"{email},{name}");
                        added++;
                    }
                }

                MessageBox.Show($"Carregados {added} destinatários.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            // Basic validation
            var apiKey = txtApiKey.Text?.Trim();
            var fromEmail = txtFromEmail.Text?.Trim();
            var fromName = txtFromName.Text?.Trim() ?? string.Empty;
            var subject = txtSubject.Text ?? string.Empty;
            var body = txtBody.Text ?? string.Empty;
            var isHtml = chkIsHtml.Checked;
            var parallel = (int)nudParallelism.Value;

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("API Key obrigatória.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(fromEmail))
            {
                MessageBox.Show("E-mail do remetente inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstRecipients.Items.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um destinatário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSend.Enabled = false;
            btnLoadFile.Enabled = false;
            lblStatus.Text = "Iniciando envio...";
            progressBar.Value = 0;
            progressBar.Maximum = lstRecipients.Items.Count;

            var recipients = lstRecipients.Items.Cast<string>().Select(ParseRecipientTuple).ToList();

            try
            {
                await SendBulkAsync(apiKey, fromEmail, fromName, subject, body, isHtml, recipients, parallel);
            }
            finally
            {
                btnSend.Enabled = true;
                btnLoadFile.Enabled = true;
            }
        }

        private async Task SendBulkAsync(string apiKey, string fromEmail, string fromName, string subject, string body, bool isHtml, List<(string Email, string Name)> recipients, int parallelism)
        {
            var client = new SendGridClient(apiKey);

            int total = recipients.Count;
            int sent = 0;
            int failed = 0;
            var semaphore = new SemaphoreSlim(parallelism);

            var tasks = recipients.Select(async r =>
            {
                await semaphore.WaitAsync();
                try
                {
                    // Build message
                    var msg = new SendGridMessage();
                    msg.SetFrom(new EmailAddress(fromEmail, fromName));
                    msg.SetSubject(subject);

                    // Personalize per recipient
                    var to = new EmailAddress(r.Email, r.Name);
                    msg.AddTo(to);

                    if (isHtml)
                        msg.AddContent(MimeType.Html, body);
                    else
                        msg.AddContent(MimeType.Text, body);

                    // Optionally you can set tracking or other settings here

                    var response = await client.SendEmailAsync(msg);

                    if (response.IsSuccessStatusCode)
                    {
                        Interlocked.Increment(ref sent);
                    }
                    else
                    {
                        Interlocked.Increment(ref failed);
                        var responseBody = await response.Body.ReadAsStringAsync();
                        // Log or store responseBody as needed
                    }
                }
                catch (Exception ex)
                {
                    Interlocked.Increment(ref failed);
                    // Optionally log ex
                }
                finally
                {
                    semaphore.Release();
                    UpdateProgressInterlocked(total, ref sent, ref failed);
                }
            }).ToArray();

            await Task.WhenAll(tasks);

            this.Invoke(() =>
            {
                lblStatus.Text = $"Concluído. Sucesso: {sent}, Falhas: {failed}";
            });
        }

        private void UpdateProgressInterlocked(int total, ref int sent, ref int failed)
        {
            // safe read
            var done = sent + failed;
            var enviados = sent;
            var falhas = failed;
            this.Invoke(() =>
            {
                progressBar.Value = Math.Min(progressBar.Maximum, done);
                lblStatus.Text = $"Enviados: {enviados} | Falhas: {falhas} | Total: {total}";
            });
        }

        private static bool TryParseRecipient(string input, out string email, out string name)
        {
            email = string.Empty;
            name = string.Empty;

            if (string.IsNullOrWhiteSpace(input)) return false;

            var parts = input.Split(new[] { ',' }, 2).Select(p => p.Trim()).ToArray();
            if (parts.Length >= 1 && IsValidEmail(parts[0]))
            {
                email = parts[0];
                name = parts.Length == 2 ? parts[1] : string.Empty;
                return true;
            }

            return false;
        }

        private static (string Email, string Name) ParseRecipientTuple(string item)
        {
            TryParseRecipient(item, out var email, out var name);
            return (email, name);
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                // simple validation
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
