namespace EnvioEmailDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblFromEmail;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label lblFromName;
        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.CheckBox chkIsHtml;
        private System.Windows.Forms.ListBox lstRecipients;
        private System.Windows.Forms.TextBox txtNewRecipient;
        private System.Windows.Forms.Button btnAddRecipient;
        private System.Windows.Forms.Button btnRemoveRecipient;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblParallelism;
        private System.Windows.Forms.NumericUpDown nudParallelism;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblApiKey = new Label();
            txtApiKey = new TextBox();
            lblFromEmail = new Label();
            txtFromEmail = new TextBox();
            lblFromName = new Label();
            txtFromName = new TextBox();
            lblSubject = new Label();
            txtSubject = new TextBox();
            lblBody = new Label();
            txtBody = new TextBox();
            chkIsHtml = new CheckBox();
            lstRecipients = new ListBox();
            txtNewRecipient = new TextBox();
            btnAddRecipient = new Button();
            btnRemoveRecipient = new Button();
            btnLoadFile = new Button();
            btnSend = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            lblParallelism = new Label();
            nudParallelism = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudParallelism).BeginInit();
            SuspendLayout();
            // 
            // lblApiKey
            // 
            lblApiKey.Location = new Point(12, 12);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(80, 23);
            lblApiKey.TabIndex = 0;
            lblApiKey.Text = "API Key:";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(100, 12);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(540, 23);
            txtApiKey.TabIndex = 1;
            txtApiKey.UseSystemPasswordChar = true;
            // 
            // lblFromEmail
            // 
            lblFromEmail.Location = new Point(12, 45);
            lblFromEmail.Name = "lblFromEmail";
            lblFromEmail.Size = new Size(120, 23);
            lblFromEmail.TabIndex = 2;
            lblFromEmail.Text = "Remetente (e-mail):";
            // 
            // txtFromEmail
            // 
            txtFromEmail.Location = new Point(140, 45);
            txtFromEmail.Name = "txtFromEmail";
            txtFromEmail.Size = new Size(250, 23);
            txtFromEmail.TabIndex = 3;
            // 
            // lblFromName
            // 
            lblFromName.Location = new Point(400, 45);
            lblFromName.Name = "lblFromName";
            lblFromName.Size = new Size(80, 23);
            lblFromName.TabIndex = 4;
            lblFromName.Text = "Nome:";
            // 
            // txtFromName
            // 
            txtFromName.Location = new Point(450, 45);
            txtFromName.Name = "txtFromName";
            txtFromName.Size = new Size(190, 23);
            txtFromName.TabIndex = 5;
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(12, 78);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(80, 23);
            lblSubject.TabIndex = 6;
            lblSubject.Text = "Assunto:";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(100, 78);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(540, 23);
            txtSubject.TabIndex = 7;
            // 
            // lblBody
            // 
            lblBody.Location = new Point(12, 110);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(80, 23);
            lblBody.TabIndex = 8;
            lblBody.Text = "Corpo:";
            // 
            // txtBody
            // 
            txtBody.Location = new Point(100, 110);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.ScrollBars = ScrollBars.Vertical;
            txtBody.Size = new Size(540, 174);
            txtBody.TabIndex = 9;
            // 
            // chkIsHtml
            // 
            chkIsHtml.Location = new Point(660, 110);
            chkIsHtml.Name = "chkIsHtml";
            chkIsHtml.Size = new Size(120, 24);
            chkIsHtml.TabIndex = 10;
            chkIsHtml.Text = "HTML";
            // 
            // lstRecipients
            // 
            lstRecipients.Location = new Point(100, 325);
            lstRecipients.Name = "lstRecipients";
            lstRecipients.Size = new Size(540, 139);
            lstRecipients.TabIndex = 11;
            // 
            // txtNewRecipient
            // 
            txtNewRecipient.Location = new Point(100, 290);
            txtNewRecipient.Name = "txtNewRecipient";
            txtNewRecipient.PlaceholderText = "email ou email,nome";
            txtNewRecipient.Size = new Size(350, 23);
            txtNewRecipient.TabIndex = 12;
            // 
            // btnAddRecipient
            // 
            btnAddRecipient.Location = new Point(460, 288);
            btnAddRecipient.Name = "btnAddRecipient";
            btnAddRecipient.Size = new Size(80, 26);
            btnAddRecipient.TabIndex = 13;
            btnAddRecipient.Text = "Adicionar";
            btnAddRecipient.Click += btnAddRecipient_Click;
            // 
            // btnRemoveRecipient
            // 
            btnRemoveRecipient.Location = new Point(550, 288);
            btnRemoveRecipient.Name = "btnRemoveRecipient";
            btnRemoveRecipient.Size = new Size(90, 26);
            btnRemoveRecipient.TabIndex = 14;
            btnRemoveRecipient.Text = "Remover";
            btnRemoveRecipient.Click += btnRemoveRecipient_Click;
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(660, 288);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(120, 26);
            btnLoadFile.TabIndex = 15;
            btnLoadFile.Text = "Carregar CSV";
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(660, 400);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(120, 40);
            btnSend.TabIndex = 18;
            btnSend.Text = "Enviar";
            btnSend.Click += btnSend_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 490);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(870, 20);
            progressBar.TabIndex = 19;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(12, 520);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(870, 23);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Pronto";
            // 
            // lblParallelism
            // 
            lblParallelism.Location = new Point(660, 330);
            lblParallelism.Name = "lblParallelism";
            lblParallelism.Size = new Size(120, 23);
            lblParallelism.TabIndex = 16;
            lblParallelism.Text = "Paralelismo:";
            // 
            // nudParallelism
            // 
            nudParallelism.Location = new Point(660, 355);
            nudParallelism.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudParallelism.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudParallelism.Name = "nudParallelism";
            nudParallelism.Size = new Size(120, 23);
            nudParallelism.TabIndex = 17;
            nudParallelism.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(lblApiKey);
            Controls.Add(txtApiKey);
            Controls.Add(lblFromEmail);
            Controls.Add(txtFromEmail);
            Controls.Add(lblFromName);
            Controls.Add(txtFromName);
            Controls.Add(lblSubject);
            Controls.Add(txtSubject);
            Controls.Add(lblBody);
            Controls.Add(txtBody);
            Controls.Add(chkIsHtml);
            Controls.Add(lstRecipients);
            Controls.Add(txtNewRecipient);
            Controls.Add(btnAddRecipient);
            Controls.Add(btnRemoveRecipient);
            Controls.Add(btnLoadFile);
            Controls.Add(lblParallelism);
            Controls.Add(nudParallelism);
            Controls.Add(btnSend);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Envio de Emails - SendGrid";
            ((System.ComponentModel.ISupportInitialize)nudParallelism).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
