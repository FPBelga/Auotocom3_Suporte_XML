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
            string connectionString = $"Server={textServidor.Text},{textPorta.Text};Database={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};";
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

           // string connectionString1 = $"Server={textServidor.Text},{textPorta.Text};Database={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text} Encrypt=False;";
            string connectionString = "Data Source=" + server + "," + port + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";" + ";Integrated Security=True;Encrypt=False";
            string query = "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml";

            if (materialCheckbox1.Checked)
            {
                query += " WHERE caixa = @Caixa";                         
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (materialCheckbox1.Checked)
                {
                    command.Parameters.AddWithValue("@Caixa", textCaixas.Text);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

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

                foreach (DataRow row in dataTable.Rows)
                {
                    string conteudo = row["conteudo"].ToString();
                    XDocument xmlDoc = XDocument.Parse(conteudo);
                    foreach (var vNF in xmlDoc.Descendants("vNF"))
                    {
                        if (decimal.TryParse(vNF.Value, out decimal valor))
                        {
                            somaVNF += valor;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao somar xml");
                        }
                    }

                    string nomeArquivo = $"{row["arquivo"]}.xml";
                    xmlDoc.Save(pasta.ToString() + "\\" + nomeArquivo + "");
                    //xmlDoc.Save($@"C:\caminho\para\salvar\{nomeArquivo}");
                }

                lblResultado.Text = $"{somaVNF:C}";
            }
        }
    }
}
