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
using System.Globalization;
using System.Net.Mail;
using System.Diagnostics;
using System.IO.Compression;
using DocumentFormat.OpenXml.InkML;

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

        public void btnCarregarDados_Click(object sender, EventArgs e)
        {
            textDatabase.Text = "";
            textDatabase.Text = "Autocom3_Filial_Movimento_Mensal_" + textAno.Text + "_" + textMes.Text;

            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

            string Caixa = textCaixas.Text;
            string[] caixas = Caixa.Split(',').Select(c => c.Trim()).ToArray(); // Definido aqui para estar disponível em todo o método

            DateTime dataInicio;
            DateTime dataFim;
            bool isDataInicioValida = DateTime.TryParseExact(textDataIni.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out dataInicio);
            bool isDataFimValida = DateTime.TryParseExact(textDataFim.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out dataFim);

            if (!string.IsNullOrEmpty(textDataIni.Text) && !isDataInicioValida)
            {
                MessageBox.Show("A data de início não está no formato correto (yyyy/MM/dd).");
                return;
            }

            if (!string.IsNullOrEmpty(textDataFim.Text) && !isDataFimValida)
            {
                MessageBox.Show("A data de fim não está no formato correto (yyyy/MM/dd).");
                return;
            }

            string query = "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml WHERE 1=1";

            if (isDataInicioValida)
            {
                query += " AND data >= @dataInicio";
            }

            if (isDataFimValida)
            {
                query += " AND data <= @dataFim";
            }

            if (materialCheckbox1.Checked && caixas.Any())
            {
                query += $" AND caixa IN ({string.Join(",", caixas.Select(c => $"'{c}'"))})";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                if (isDataInicioValida)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@dataInicio", dataInicio);
                }

                if (isDataFimValida)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@dataFim", dataFim);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                decimal somaVNF = 0;
                decimal valorAnterior = 0;
                string pasta = "";

                int quantidadeMod55 = 0;
                int quantidadeMod65 = 0;

                novoDataGridView.Rows.Clear();

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

                int quantidadeArquivos = dataTable.Rows.Count;
                
                progressBarSalvando.Maximum = quantidadeArquivos;
                progressBarSalvando.Value = 0;
                
                bool isFantasiaCapturada = false;  // Variável para controlar a captura da fantasia
                string fantasia = null;  // Variável para armazenar o valor da tag <xFant>
                
                List<decimal> notasFaltantes = new List<decimal>();
                
                string caixaAtual = null;

                //string pastaTemporaria = Path.Combine(pasta, "Temp");

                //// Criação do diretório temporário
                //if (Directory.Exists(pastaTemporaria))
                //{
                //    Directory.Delete(pastaTemporaria, true);
                //}
                //Directory.CreateDirectory(pastaTemporaria);

                foreach (DataRow row in dataTable.Rows)
                {
                    string conteudo = row["conteudo"].ToString();
                    string arquivo = row["arquivo"].ToString();
                    caixaAtual = row["caixa"].ToString();

                    XDocument xmlDoc = XDocument.Parse(conteudo);

                    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

                    // Captura o valor da tag <xFant> somente no primeiro arquivo
                    if (!isFantasiaCapturada)
                    {
                        foreach (var elemento in xmlDoc.Descendants(ns + "xFant"))
                        {
                            fantasia = elemento.Value;  // Obtém o valor da tag <xFant>
                            isFantasiaCapturada = true; // Marca que o valor já foi capturado
                            break;  // Interrompe o loop após capturar o valor
                        }
                    }                  

                    foreach (var elemento in xmlDoc.Descendants(ns + "mod"))
                    {
                        if (elemento.Value == "55")
                        {
                            quantidadeMod55++;
                        }
                        else if (elemento.Value == "65")
                        {
                            quantidadeMod65++;
                        }
                    }

                    foreach (var elemento in xmlDoc.Descendants(ns + "vNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valor))
                        {
                            somaVNF += valor;
                        }
                    }

                    string pastaDestino;

                    if (materialCheckbox1.Checked)
                    {
                        pastaDestino = Path.Combine(pasta, caixaAtual);
                        if (!Directory.Exists(pastaDestino))
                        {
                            Directory.CreateDirectory(pastaDestino);
                        }
                    }
                    else
                    {
                        pastaDestino = pasta;
                    }

                    string caminhoArquivo = Path.Combine(pastaDestino, $"{arquivo}.xml");

                    if (File.Exists(caminhoArquivo))
                    {
                        File.Delete(caminhoArquivo);
                    }

                    xmlDoc.Save(caminhoArquivo);                   

                    foreach (var elemento in xmlDoc.Descendants(ns + "nNF"))
                    {
                        if (decimal.TryParse(elemento.Value, out decimal valorAtual))
                        {
                            if (valorAnterior != 0)
                            {
                                if (valorAtual > valorAnterior + 1)
                                {
                                    for (decimal i = valorAnterior + 1; i < valorAtual; i++)
                                    {
                                          notasFaltantes.Add(i);
                                    }
                                }
                            }

                            valorAnterior = valorAtual;
                        }
                    }
                    progressBarSalvando.Value += 1;
                    Application.DoEvents();
                }
                
                // Atualiza a interface com os resultados
                MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");
                lbTotalNfe.Visible = true;
                lbTotalNfe.Text = quantidadeMod55.ToString();
                lbTotalNfce.Visible = true;
                lbTotalNfce.Text = quantidadeMod65.ToString();
                lbQtdNotas.Visible = true;
                lbQtdNotas.Text = dataTable.Rows.Count.ToString();
                lblResultado.Visible = true;
                progressBarSalvando.Value = 0;
               
                // Formata o valor total de VNF
                decimal valorFormatado = somaVNF / 100;
                lblResultado.Text = valorFormatado.ToString("N2", new CultureInfo("pt-BR"));

                // Remove a coluna 'conteudo' e atualiza o DataGridView
                dataTable.Columns.Remove("conteudo");
                dataGridView1.DataSource = dataTable;

              
                string zipNome;

                if (materialCheckbox1.Checked)
                {
                    zipNome = $"XML_{fantasia}_{textMes.Text}_{textAno.Text}_{string.Join("_", caixas)}.zip";
                }
                else
                {
                    zipNome = $"XML_{fantasia}_{textMes.Text}_{textAno.Text}_Completo.zip";
                }

                string zipPath = Path.Combine(pasta, zipNome);
                string pastaCompleto = Path.Combine(pasta, "XMLCompleto");

                try
                {
                    // Verifica se o arquivo ZIP já existe
                    if (File.Exists(zipPath))
                    {
                        // Se existir, apaga o arquivo ZIP antigo
                        File.Delete(zipPath);
                    }

                    // Cria a pasta "XMLCompleto" para armazenar os arquivos antes de compactar
                    if (!Directory.Exists(pastaCompleto))
                    {
                        Directory.CreateDirectory(pastaCompleto);
                    }

                    // Mover ou copiar os arquivos para a pasta "XMLCompleto" antes da compactação
                    if (!materialCheckbox1.Checked)
                    {
                        foreach (string file in Directory.GetFiles(pasta, "*.xml"))
                        {
                            string destFile = Path.Combine(pastaCompleto, Path.GetFileName(file));
                            File.Move(file, destFile);
                        }
                    }

                    // Configura a barra de progresso
                    string[] arquivosParaCompactar = Directory.GetFiles(materialCheckbox1.Checked ? pasta : pastaCompleto, "*.xml", SearchOption.AllDirectories);
                    progressBarSalvando.Maximum = arquivosParaCompactar.Length;
                    progressBarSalvando.Value = 0;

                    // Compacta a pasta ou arquivos dependendo do estado do checkbox
                    if (materialCheckbox1.Checked)
                    {
                        foreach (string caixa in caixas)
                        {
                            string pastaCaixa = Path.Combine(pasta, caixa);
                            if (Directory.Exists(pastaCaixa))
                            {
                                ZipFile.CreateFromDirectory(pastaCaixa, zipPath);
                                Directory.Delete(pastaCaixa, true);
                            }
                        }
                    }
                    else
                    {
                        // Compacta a pasta "XMLCompleto"
                        using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                        {
                            foreach (string file in arquivosParaCompactar)
                            {
                                zip.CreateEntryFromFile(file, Path.GetFileName(file));
                                progressBarSalvando.Value += 1;
                                Application.DoEvents();
                            }
                        }

                        // Após compactação, exclui a pasta "XMLCompleto" e seus arquivos
                        Directory.Delete(pastaCompleto, true);
                    }

                    MessageBox.Show("Arquivos compactados e ZIP criado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar compactar os arquivos: {ex.Message}");
                }

                // Habilita os botões relacionados a relatórios e envio de e-mail
                btnRelXMLPDF.Enabled = true;
                btnRelXMLEXCEL.Enabled = true;
                btnRelFaltntesLPDF.Enabled = true;
                btnRelFaltntesLEXCEL.Enabled = true;
                btnEnviarEmail.Enabled = true;


                //foreach (var notaFaltante in notasFaltantes)
                //{
                //    novoDataGridView.Rows.Add(notaFaltante, caixaAtual);
                //}
            }

        }
            // Função para filtrar as colunas do DataGridView
        public DataTable GetFilteredDataTable(DataGridView dgv)
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
                saveFileDialog.FileName = "Relatório dos XMLs Baixados.pdf";

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
                        doc.Add(new Paragraph("                             " +
                            "                  Relatório dos XMLs Baixados"));
                        doc.Add(new Paragraph(""));
                        doc.Add(new Paragraph(""));

                        // Criar tabela PDF
                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                        // Adicionar cabeçalhos
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            table.AddCell(new Phrase(column.HeaderText));
                        }

                        // Adicionar linhas de dados
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new Phrase(cell.Value?.ToString()));
                            }
                        }

                        // Adicionar a tabela ao documento
                        doc.Add(table);

                        // Adicionando os Totais
                        doc.Add(new Paragraph("                                                                           " +
                            "                    TOTAL = " + lblResultado.Text));
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
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Salvar Relatório em Excel";
                saveFileDialog.FileName = "RelatórioDosXMLsBaixados.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string caminhoExcel = saveFileDialog.FileName;

                        // Criar o Workbook
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Relatório dos XMLs Baixados");

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
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo Excel: {ex.Message}");
                    }
                }
            }
        }

        private void btnRelFaltntesLPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "RelatorioDasNotasFaltantes.pdf";

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
                        doc.Add(new Paragraph("Relatório das Notas Faltantes"));

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
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}");
                    }
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            textSenha.Enabled = !textLogin.Enabled;
            textServidor.Enabled = !textServidor.Enabled;
            textPorta.Enabled = !textPorta.Enabled;
            textLogin.Enabled = !textLogin.Enabled;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            // Abre uma caixa de entrada para o usuário inserir o e-mail
            string emailDestino = Microsoft.VisualBasic.Interaction.InputBox("Digite o e-mail para envio:", "Enviar Arquivos por E-mail", "");

            // Verifica se o e-mail foi inserido
            if (string.IsNullOrWhiteSpace(emailDestino))
            {
                MessageBox.Show("E-mail não foi inserido. Operação cancelada.");
                return;
            }

            try
            {

                // Caminho onde os arquivos estão salvos
                string caminhoArquivos = "";
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        caminhoArquivos = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma pasta selecionada. Operação cancelada.");
                        return;
                    }
                }                
                string[] arquivos = Directory.GetFiles(caminhoArquivos);

                // Constrói a string para anexar os arquivos (precisa estar na forma de file://)
                string anexos = string.Join(",", arquivos.Select(a => "file:///" + Uri.EscapeUriString(a.Replace('\\', '/'))));

                // Constrói a string mailto
                string mailto = $"mailto:{emailDestino}?subject=Arquivos Gerados&body=Em anexo estão os arquivos gerados.&attachment={anexos}";

                // Abre o cliente de e-mail padrão
                System.Diagnostics.Process.Start(mailto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o gerenciador de e-mails: {ex.Message}");
            }
            //Abre uma caixa de entrada para o usuário inserir o e - mail

        }
    }
}
