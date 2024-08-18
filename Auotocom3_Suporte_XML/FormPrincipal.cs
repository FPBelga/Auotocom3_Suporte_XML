using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

                // Variáveis para armazenar as contagens
                int quantidadeMod55 = 0;
                int quantidadeMod65 = 0;

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

                // Calcula a quantidade de arquivos XML a serem processados
                int quantidadeArquivos = dataTable.Rows.Count;
                progressBarSalvando.Maximum = quantidadeArquivos;
                progressBarSalvando.Value = 0;

                foreach (DataRow row in dataTable.Rows)
                {
                    string conteudo = row["conteudo"].ToString();
                    string arquivo = row["arquivo"].ToString();
                    string caixaAtual = row["caixa"].ToString();

                    // Carrega o conteúdo XML
                    XDocument xmlDoc = XDocument.Parse(conteudo);

                    // Verifica se há namespaces no documento
                    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

                    List<decimal> notasFaltantes = new List<decimal>();

                    foreach (var elemento in xmlDoc.Descendants(ns + "nNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valorAtual))
                        {
                            // Se o valor anterior for diferente de zero e a diferença for maior que 1, temos notas faltantes
                            if (valorAnterior != 0)
                            {
                                if (valorAtual > valorAnterior + 1)
                                {
                                    // Adiciona ao novo DataGridView todas as notas faltantes entre valorAnterior e valorAtual
                                    for (decimal i = valorAnterior + 1; i < valorAtual; i++)
                                    {
                                        notasFaltantes.Add(i); // Adiciona apenas a nota faltante à lista
                                    }
                                }
                            }

                            // Atualiza o valor anterior
                            valorAnterior = valorAtual;
                        }
                    }

                    // Adiciona as notas faltantes ao novo DataGridView após o loop
                    foreach (var notaFaltante in notasFaltantes)
                    {
                        novoDataGridView.Rows.Add(notaFaltante); // Adiciona apenas a nota faltante
                    }

                    // Verifica cada elemento <mod>
                    foreach (var elemento in xmlDoc.Descendants(ns + "mod"))
                    {
                        if (elemento.Value == "55")
                        {
                            quantidadeMod55++; // Incrementa a quantidade de "55"
                        }
                        else if (elemento.Value == "65")
                        {
                            quantidadeMod65++; // Incrementa a quantidade de "65"
                        }
                    }

                    // Soma os valores de <vNF>
                    foreach (var elemento in xmlDoc.Descendants(ns + "vNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valor))
                        {
                            somaVNF += valor;
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

                    // Atualiza a barra de progresso
                    progressBarSalvando.Value += 1;
                    Application.DoEvents();
                }

                // Exibe a mensagem de finalização e o resultado na Label
                MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");
                lbTotalNfe.Visible = true;
                lbTotalNfe.Text = quantidadeMod55.ToString();
                lbTotalNfce.Visible = true;
                lbTotalNfce.Text = quantidadeMod65.ToString();
                lbQtdNotas.Visible = true;
                lbQtdNotas.Text = dataTable.Rows.Count.ToString();
                lblResultado.Visible = true;
                lblResultado.Text = $"{somaVNF:0,00}".Replace(',', '.');
                dataGridView1.DataSource = dataTable;
                btnRelXMLPDF.Enabled = true;
                btnRelXMLEXCEL.Enabled = true;
                btnRelFaltntesLPDF.Enabled = true;
                btnRelFaltntesLEXCEL.Enabled = true;
            }
        }

        // Função para filtrar as colunas do DataGridView
        private DataTable GetFilteredDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Adiciona as colunas do DataGridView exceto "arquivo" e "conteúdo"
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name != "arquivo" && column.Name != "conteudo")
                {
                    dt.Columns.Add(column.Name, column.ValueType);
                }
            }

            // Adiciona as linhas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Name != "arquivo" && column.Name != "conteudo")
                    {
                        dr[column.Name] = row.Cells[column.Name].Value;
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        private void btnRelXMLPDF_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "RelatorioDataGridView1.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string caminhoPDF = saveFileDialog.FileName;

                        // Criar documento PDF
                        Document doc = new Document();
                        PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                        doc.Open();

                        // Adicionar título ao documento
                        doc.Add(new Paragraph("Relatório de XMLs extraídos"));

                        // Filtrar colunas
                        DataTable filteredTable = GetFilteredDataTable(dataGridView1);

                        // Criar tabela PDF com colunas filtradas
                        PdfPTable table = new PdfPTable(filteredTable.Columns.Count);

                        // Adicionar cabeçalhos
                        foreach (DataColumn column in filteredTable.Columns)
                        {
                            table.AddCell(new Phrase(column.ColumnName));
                        }

                        // Adicionar linhas de dados
                        foreach (DataRow row in filteredTable.Rows)
                        {
                            foreach (var cell in row.ItemArray)
                            {
                                table.AddCell(new Phrase(cell?.ToString()));
                            }
                        }

                        // Adicionar a tabela ao documento
                        doc.Add(table);
                        doc.Close();

                        MessageBox.Show("Relatório PDF gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}");
                    }
                }
            }
        }

        private void btnRelXMLEXCEL_Click_1(object sender, EventArgs e)
        {
            // Caminho para salvar o Excel
            string caminhoExcel = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    caminhoExcel = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Nenhuma pasta selecionada. Operação cancelada.");
                    return;
                }
            }

            // Criar o Workbook
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Relatório de XML baixados");

            // Adicionar cabeçalhos
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
            }

            // Adicionar linhas de dados
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Salvar o arquivo Excel
            workbook.SaveAs(caminhoExcel);

            MessageBox.Show("Relatório Excel gerado com sucesso!");

        }

        private void btnRelFaltntesLPDF_Click(object sender, EventArgs e)
        {
            // Caminho para salvar o PDF
            string caminhoPDF = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    caminhoPDF = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Nenhuma pasta selecionada. Operação cancelada.");
                    return;
                }
            }

            // Criar documento PDF
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
            doc.Open();

            // Adicionar título ao documento
            doc.Add(new Paragraph("Relatório dos XML baixados"));

            // Criar tabela PDF
            PdfPTable table = new PdfPTable(novoDataGridView.Columns.Count);

            // Adicionar cabeçalhos
            foreach (DataGridViewColumn column in novoDataGridView.Columns)
            {
                table.AddCell(new Phrase(column.HeaderText));
            }

            // Adicionar linhas de dados
            foreach (DataGridViewRow row in novoDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new Phrase(cell.Value?.ToString()));
                }
            }

            // Adicionar a tabela ao documento
            doc.Add(table);
            doc.Close();

            MessageBox.Show("Relatório PDF gerado com sucesso!");
        }

        private void btnRelFaltntesLEXCEL_Click(object sender, EventArgs e)
        {
            // Caminho para salvar o Excel
            string caminhoExcel = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    caminhoExcel = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Nenhuma pasta selecionada. Operação cancelada.");
                    return;
                }
            }

            // Criar o Workbook
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Relatório de XML baixados");

            // Adicionar cabeçalhos
            for (int i = 0; i < novoDataGridView.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = novoDataGridView.Columns[i].HeaderText;
            }

            // Adicionar linhas de dados
            for (int i = 0; i < novoDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < novoDataGridView.Columns.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = novoDataGridView.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Salvar o arquivo Excel
            workbook.SaveAs(caminhoExcel);

            MessageBox.Show("Relatório Excel gerado com sucesso!");
        }
    }
}
