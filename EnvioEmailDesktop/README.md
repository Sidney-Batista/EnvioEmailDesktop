# EnvioEmailDesktop

Aplica��o WinForms para envio em massa de e?mails usando SendGrid.

## Vis�o geral
Projeto .NET 9 (net9.0-windows) que fornece uma interface simples para:
- configurar API Key do SendGrid,
- informar remetente (e-mail/nome),
- montar assunto e corpo (texto/HTML),
- adicionar destinat�rios (manual ou CSV),
- controlar paralelismo de envio e monitorar progresso.

## Pr�?requisitos
- Windows com suporte a WinForms.
- Visual Studio 2026 ou `dotnet` SDK (.NET 9).
- Pacote NuGet: `SendGrid` (j� referenciado no `EnvioEmailDesktop.csproj` � vers�o 9.29.3).

## Instala��o / primeiros passos
1. Abra a solu��o no Visual Studio 2026.
2. Restaure pacotes: __Build > Restore NuGet Packages__ ou execute `dotnet restore`.
3. (Se necess�rio) Instale o pacote via __Manage NuGet Packages__ ou: