using Auotocom3_Suporte_XML;
using MaterialSkin;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Autocom3_Suporte_XML
{
    public partial class FormEnviaEmail : MaterialSkin.Controls.MaterialForm
    {
        private FormPrincipal _formPrincipal;
        public FormEnviaEmail(FormPrincipal formPrincipal)
        {

            InitializeComponent();
            _formPrincipal = formPrincipal; // Atribua o parâmetro à variável
            textSenha.PasswordChar = '*'; // Define o caractere de máscara como asterisco (*)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple700, Primary.DeepPurple700,
                Primary.DeepPurple700, Accent.DeepPurple700,
                TextShade.WHITE
            );

            // Atribua o evento KeyDown aos TextBoxes
            textDestinatario.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textRemetente.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textSenha.KeyDown += new KeyEventHandler(textBox_KeyDown);
            btnEnviarEmail.KeyDown += new KeyEventHandler(textBox_KeyDown);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {

            string emailDestino = textDestinatario.Text.Trim();
            string emailRemetende = textRemetente.Text.Trim() + "@autocom3.com.br";
            string senhaRemetende = textSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(emailDestino))
            {
                MessageBox.Show("E-mail Destinatário não foi inserido. Operação cancelada.");
                return;
            }

            // Verifica se o e-mail foi inserido
            if (string.IsNullOrWhiteSpace(emailRemetende))
            {
                MessageBox.Show("E-mail Remetente não foi inserido. Operação cancelada.");
                return;
            }

            string textMes = _formPrincipal.textMes.Text;
            string textAno = _formPrincipal.textAno.Text;
            string fantasia = _formPrincipal.fantasia;

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Title = "Selecione os arquivos para anexar";
                    ofd.Filter = "Todos os Arquivos|*.*";

                    DialogResult result = ofd.ShowDialog();

                    // Verifica se o usuário selecionou arquivos
                    if (result == DialogResult.OK && ofd.FileNames.Length > 0)
                    {

                        //Configuração do cliente SMTP
                        SmtpClient smtpClient = new SmtpClient()
                        {
                            Host = "smtp.uni5.net",
                            UseDefaultCredentials = false, // vamos utilizar credencias especificas
                            Credentials = new NetworkCredential(emailRemetende.Trim(), senhaRemetende), // seu usuário e senha para autenticação
                            EnableSsl = false, // GMail requer SSL
                            Port = 587,      // porta para SSL
                            DeliveryMethod = SmtpDeliveryMethod.Network, // modo de envio

                        };

                        if (smtpClient == null)
                        {
                            MessageBox.Show("smtpClient não foi inicializado.");
                            return;
                        }

                        // Criação do e-mail
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(emailRemetende);
                        mail.To.Add(emailDestino);
                        mail.Subject = $"Arquivos XML gerados do mês de {textMes}/{textAno} para a empresa {fantasia}.";
                        mail.Body = $"Em anexo estão os arquivos XML gerados do mês de {textMes}/{textAno} para a empresa {fantasia}.";
                        mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                        mail.Priority = MailPriority.Normal;


                        // Adiciona os arquivos como anexo
                        foreach (string arquivo in ofd.FileNames)
                        {
                            Attachment anexo = new Attachment(arquivo);
                            mail.Attachments.Add(anexo);
                        }

                        // Envia o e-mail
                        smtpClient.Send(mail);
                        MessageBox.Show("E-mail enviado com sucesso.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum arquivo selecionado. Operação cancelada.");
                        return;
                    }
                }
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"Erro SMTP: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}
