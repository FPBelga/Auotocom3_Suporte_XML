using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auotocom3_Suporte_XML;

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
                MessageBox.Show("E-mail não foi inserido. Operação cancelada.");
                return;
            }

            if (_formPrincipal == null)
            {
                MessageBox.Show("FormPrincipal não foi inicializado.");
                return;
            }

            if (_formPrincipal.textMes == null || _formPrincipal.textAno == null || _formPrincipal.fantasia == null)
            {
                MessageBox.Show("Um ou mais controles no FormPrincipal não foram inicializados.");
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

                    if (result == DialogResult.OK && ofd.FileNames.Length > 0)
                    {
                        SmtpClient smtpClient = new SmtpClient()
                        {
                            Host = "smtp.uni5.net",
                            Port = 587, // ou 465, dependendo do servidor
                            EnableSsl = false, // Para a maioria dos servidores, SSL deve ser ativado
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(emailRemetende, senhaRemetende),
                            //DeliveryMethod = SmtpDeliveryMethod.Network,
                        };
                        MessageBox.Show(smtpClient.ToString());
                        if (smtpClient == null)
                        {
                            MessageBox.Show("smtpClient não foi inicializado.");
                            return;
                        }

                        MailMessage mail = new MailMessage
                        {
                            From = new MailAddress(emailRemetende + "@autocom3.com.br"),
                            Subject = $"Arquivos XML gerados do mês de {textMes}/{textAno} para a empresa {fantasia}.",
                            Body = $"Em anexo estão os arquivos XML gerados do mês de {textMes}/{textAno} para a empresa {fantasia}.",
                            BodyEncoding = Encoding.GetEncoding("ISO-8859-1"),
                            Priority = MailPriority.Normal,
                        };

                        mail.To.Add(emailDestino);

                        foreach (string arquivo in ofd.FileNames)
                        {
                            Attachment anexo = new Attachment(arquivo);
                            mail.Attachments.Add(anexo);
                        }

                        smtpClient.Send(mail);
                        MessageBox.Show("E-mail enviado com sucesso.");
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
