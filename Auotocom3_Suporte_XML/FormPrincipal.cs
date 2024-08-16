using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Auotocom3_Suporte_XML
{
    public partial class FormPrincipal : MaterialSkin.Controls.MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        { 
            if (materialCheckbox1.Checked)
            {
                textCaixas.Enabled = true;
            }else
            {
                textCaixas.Enabled = false;
            }
        }
            private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            string server = textServidor.Text.ToString();
            string port = textPorta.Text.ToString();
            string database = textDatabase.Text.ToString();
            string username = textLogin.Text.ToString();
            string password = textSenha.Text.ToString();          

            string connectionString = "Data Source=" + server + "," + port + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";" + ";Integrated Security=True;Encrypt=False"; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexão bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conexão: {ex.Message}");
            }
        }

        private void btnCarregarDados_Click(object sender, EventArgs e)
        {
            string server = textServidor.Text.ToString();
            string port = textPorta.Text.ToString();
            string database = textDatabase.Text.ToString();
            string username = textLogin.Text.ToString();
            string password = textSenha.Text.ToString();
            string Caixa = textCaixas.Text.ToString();
            string[] caixas = Caixa.Split(',');

            // string connectionString1 = $"Server={textServidor.Text},{textPorta.Text};Database={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text} Encrypt=False;";
            string connectionString = "Data Source=" + server + "," + port + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";" + ";Integrated Security=True;Encrypt=False";

            string query = "";
            if (materialCheckbox1.Checked)
            {
                // Modifica a query para usar IN em vez de =
                query = "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml WHERE caixa IN (" + string.Join(",", caixas.Select(c => $"'{c.Trim()}'")) + ")";

            }
            else
            {
                query = "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (materialCheckbox1.Checked)
                {
                    command.Parameters.AddWithValue("@Caixa", textCaixas.Text.ToString());
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                

                decimal somaVNF = 0;

                string pasta = "";

                using (var fbd = new FolderBrowserDialog()) //abre janela pra escolher a pasta que vai salvar
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        pasta = fbd.SelectedPath;

                        //System.Windows.Forms.MessageBox.Show(pasta);
                    }
                }

                // Supondo que a variável Caixa contenha os números dos caixas separados por vírgula, ex: "001,002,003" 
                foreach (string caixa in caixas)
                {
                    string caixaTrimmed = caixa.Trim(); // Remove espaços em branco extras
                    string pastaCaixa = Path.Combine(pasta.ToString(), caixaTrimmed);

                    // Verifica se a pasta existe, se não, cria a pasta.
                    if (!Directory.Exists(pastaCaixa))
                    {
                        Directory.CreateDirectory(pastaCaixa);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string conteudo = row["conteudo"].ToString();
                        XDocument xmlDoc = XDocument.Parse(conteudo);

                        foreach (var vNF in xmlDoc.Descendants("vNF"))
                        {
                            if (decimal.TryParse(vNF.Value, out decimal valor))
                            //{
                                somaVNF += valor;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Erro ao somar valor do XML.");
                            //}
                        }

                        string nomeArquivo = $"{row["arquivo"]}.xml";
                        xmlDoc.Save(Path.Combine(pastaCaixa, nomeArquivo)); // Salva na pasta do caixa
                    }
                }

                // Exibe a mensagem de finalização e o resultado na Label
                MessageBox.Show("Finalizado com sucesso: Encontrados: " + dataTable.Rows.Count);
                lblResultado.Text = $"{somaVNF:C}";
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
