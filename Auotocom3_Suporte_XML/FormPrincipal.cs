using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;

namespace Auotocom3_Suporte_XML
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            textCaixas.Enabled = materialCheckbox1.Checked;
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

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
            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

            string Caixa = textCaixas.Text;
            string[] caixas = Caixa.Split(',').Select(c => c.Trim()).ToArray();

            string query = materialCheckbox1.Checked ?
                $"SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml WHERE caixa IN ({string.Join(",", caixas.Select(c => $"'{c}'"))})" :
                "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                decimal somaVNF = 0;
                decimal valorAnterior = 0;
                string pasta = "";

                // Limpa o DataGridView antes de adicionar novos valores
                novoDataGridView.Rows.Clear();

                // Abre janela para escolher a pasta onde os arquivos serão salvos
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        pasta = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma pasta selecionada. Operação cancelada.");
                        return;
                    }
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    string conteudo = row["conteudo"].ToString();
                    string arquivo = row["arquivo"].ToString();
                    string caixaAtual = row["caixa"].ToString();

                    // Carrega o conteúdo XML
                    XDocument xmlDoc = XDocument.Parse(conteudo);

                    // Verifica se há namespaces no documento
                    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

                    // Soma os valores de <vNF>
                    foreach (var elemento in xmlDoc.Descendants(ns + "vNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valor))
                        {
                            somaVNF += valor;
                        }
                    }

                    // Verifica os valores de <nNF>
                    foreach (var elemento in xmlDoc.Descendants(ns + "nNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valorAtual))
                        {
                            // Se o valor anterior for diferente de zero e a diferença for maior que 1, temos notas faltantes
                            if (valorAnterior != 0 && valorAtual > valorAnterior + 1)
                            {
                                // Adiciona ao novo DataGridView todas as notas faltantes
                                for (decimal i = valorAnterior + 1; i < valorAtual; i++)
                                {
                                    novoDataGridView.Rows.Add(i, i);
                                }
                            }

                         // Atualiza o valor anterior
                         valorAnterior = valorAtual;
                        }
                    }

                    // Cria a pasta específica do caixa se não existir
                    string pastaCaixa = Path.Combine(pasta, caixaAtual);
                    if (!Directory.Exists(pastaCaixa))
                    {
                        Directory.CreateDirectory(pastaCaixa);
                    }

                    // Salva o arquivo XML na pasta correspondente
                    xmlDoc.Save(Path.Combine(pastaCaixa, $"{arquivo}.xml"));
                }

                // Exibe a mensagem de finalização e o resultado na Label
                MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");
                lblResultado.Text = somaVNF.ToString("N2").Replace('.', 'X').Replace(',', '.').Replace('X', ',');
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
