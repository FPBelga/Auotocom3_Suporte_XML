using System.Data;
using System.Xml.Linq;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.IO.Compression;
using Autocom3_Suporte_XML;
using MaterialSkin;
using System.IO.Compression;
using iTextSharp.text;
using System.Diagnostics;

namespace Auotocom3_Suporte_XML
{
    public partial class FormPrincipal : MaterialForm
    {
        public TextBox textMes;
        public TextBox textAno;
        public string fantasia;  // Variável para armazenar o valor da tag <xFant>
        public FormPrincipal()
        {
            InitializeComponent();
            // Atribua o evento KeyDown aos TextBoxes
            textAno.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textMes.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textCaixas.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textDataIni.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textDataFim.KeyDown += new KeyEventHandler(textBox_KeyDown);
            btnCarregarDados.KeyDown += new KeyEventHandler(textBox_KeyDown);
            lblResultado.ForeColor = Color.Red; // Altera a cor do texto para vermelho
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple700, Primary.DeepPurple700,
                Primary.DeepPurple700, Accent.DeepPurple700,
                TextShade.WHITE

            );
        }
        private void novoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
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
            // Inicia o cronômetro
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            textDatabase.Text = "";
            textDatabase.Text = "Autocom3_Filial_Movimento_Mensal_" + textAno.Text + "_" + textMes.Text;

            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

            string Caixa = textCaixas.Text;
            string[] caixas = Caixa.Split(',').Select(c => c.Trim()).ToArray(); // Definido aqui para estar disponível em todo o método

            DateTime dataInicio;
            DateTime dataFim;
            bool isDataInicioValida = DateTime.TryParseExact(textDataIni.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataInicio);
            bool isDataFimValida = DateTime.TryParseExact(textDataFim.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataFim);

            if (!string.IsNullOrEmpty(textDataIni.Text) && !isDataInicioValida)
            {
                MessageBox.Show("A data de início não está no formato correto (dd/MM/yyyy).");
                return;
            }

            if (!string.IsNullOrEmpty(textDataFim.Text) && !isDataFimValida)
            {
                MessageBox.Show("A data de fim não está no formato correto (dd/MM/yyyy).");
                return;
            }

            // Conversão das datas para o formato "yyyy-MM-dd"
            string dataInicioFormatada = dataInicio.ToString("yyyy-MM-dd");
            string dataFimFormatada = dataFim.ToString("yyyy-MM-dd");

            string query = "SELECT " +
                            " fiscal_r04.num_caixa," +
                            " fiscal_r04.data," +
                            " fiscal_r04.hora," +
                            " fiscal_r04.c07," +
                            " fiscal_r04.n14," +
                            " fiscal_r04.nfe_cstat," +
                            " fiscal_r04.nfe_chave," +
                            "fiscal_r04.nfe_canc," +
                            " CASE " +
                            "   WHEN (f.nfe_cstat = 100 OR f.nfe_cstat = 150) AND f.nfe_canc = '' THEN 'FATURADA' " +
                            "   WHEN (f.nfe_cstat = 100 OR f.nfe_cstat = 150) AND f.nfe_canc = 101 THEN 'CANCELADA' " +
                            "   ELSE 'PRE-NOTA' " +
                            " END AS SITUACAO," +
                            " repositorio_de_xml.chavenfe," +
                            " repositorio_de_xml.arquivo," +
                            " repositorio_de_xml.conteudo" +
                            " FROM dbo.fiscal_r04 " +
                            " JOIN repositorio_de_xml ON fiscal_r04.nfe_chave = repositorio_de_xml.chavenfe" +
                            " WHERE 1=1";

            if (isDataInicioValida)
            {
                query += " AND fiscal_r04.data >= @dataInicioFormatada";
            }

            if (isDataFimValida)
            {
                query += " AND fiscal_r04.data <= @dataFimFormatada";
            }

            if (materialCheckbox1.Checked && caixas.Any())
            {
                query += $" AND fiscal_r04.num_caixa IN ({string.Join(",", caixas.Select(c => $"'{c}'"))} )";
            }

            // Adiciona a cláusula ORDER BY ao final da consulta
            query += " ORDER BY fiscal_r04.num_caixa, fiscal_r04.c07 ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Definir o tempo limite da consulta para o DataAdapter
                adapter.SelectCommand.CommandTimeout = 120;  // Tempo em segundos

                if (isDataInicioValida)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@dataInicioFormatada", dataInicioFormatada);
                }

                if (isDataFimValida)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@dataFimFormatada", dataFimFormatada);
                }

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                decimal somaVNF = 0;
                string pasta = "";

                int totalNotas = 0;
                int quantidadeMod55 = 0;
                int quantidadeMod65 = 0;

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

                bool isFantasiaCapturada = false;

                // Armazenar as notas por caixa
                var notasPorCaixa = new Dictionary<string, List<decimal>>();

                foreach (DataRow row in dataTable.Rows)
                {
                    string conteudo = row["conteudo"].ToString();
                    string arquivo = row["arquivo"].ToString();
                    string caixaAtual = row["num_caixa"].ToString();

                    // Inicializa a lista de notas para o caixa atual
                    if (!notasPorCaixa.ContainsKey(caixaAtual))
                    {
                        notasPorCaixa[caixaAtual] = new List<decimal>();
                    }

                    // Converte o valor de c07 para decimal e adiciona à lista
                    if (decimal.TryParse(row["c07"].ToString(), out decimal c07Atual))
                    {
                        notasPorCaixa[caixaAtual].Add(c07Atual);
                    }

                    if (string.IsNullOrEmpty(conteudo))
                    {
                        // Adiciona ao DataGridView2 os registros que não possuem conteúdo
                        if (decimal.TryParse(row["c07"].ToString(), out decimal c07AtualSemConteudo))
                        {
                           // dataGridView2.Rows.Add(c07AtualSemConteudo, caixaAtual);
                            totalNotas++;
                        }
                        continue; // Continua para o próximo registro
                    }

                    XDocument xmlDoc;
                    try
                    {
                        xmlDoc = XDocument.Parse(conteudo);
                    }
                    catch (Exception ex)
                    {
                        // Adiciona uma entrada ao DataGridView2 para o erro de parsing e continua
                        if (decimal.TryParse(row["c07"].ToString(), out decimal c07AtualErro))
                        {
                            dataGridView2.Rows.Add(c07AtualErro, caixaAtual);
                            totalNotas++;
                        }
                        MessageBox.Show($"Erro ao processar o XML do arquivo '{arquivo}': {ex.Message}");
                        continue; // Continua para o próximo registro
                    }

                    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

                    // Captura o valor da tag <xFant> somente no primeiro arquivo
                    if (!isFantasiaCapturada)
                    {
                        foreach (var elemento in xmlDoc.Descendants(ns + "xFant"))
                        {
                            fantasia = elemento.Value;
                            isFantasiaCapturada = true;
                            break;
                        }
                    }

                    //foreach (var elemento in xmlDoc.Descendants(ns + "mod"))
                    //{
                    //    if (elemento.Value == "55")
                    //    {
                    //        quantidadeMod55++;
                    //    }
                    //    else if (elemento.Value == "65")
                    //    {
                    //        quantidadeMod65++;
                    //    }
                    //}

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
                    progressBarSalvando.Value += 1;
                    Application.DoEvents();
                }

                // Adiciona as notas fiscais faltantes por caixa
                foreach (var caixa in notasPorCaixa.Keys)
                {
                    var c07Existentes = notasPorCaixa[caixa];
                    if (c07Existentes.Any())
                    {
                        decimal c07Min = c07Existentes.Min();
                        decimal c07Max = c07Existentes.Max();
                        for (decimal i = c07Min; i <= c07Max; i++)
                        {
                            if (!c07Existentes.Contains(i))
                            {
                                dataGridView2.Rows.Add(i, caixa);
                                totalNotas++;
                            }
                        }
                    }
                }

                // Para o cronômetro
                stopwatch.Stop();
                TimeSpan tempoTotal = stopwatch.Elapsed;

                // Atualiza o Label com o tempo total
                label10.Text = $"Tempo Total: {tempoTotal.TotalSeconds:F2} segundos";

                // Atualiza a interface com os resultados
                MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");
                lbTotalNfe.Visible = true;
                lbTotalNfe.Text = quantidadeMod55.ToString();
                lbTotalNfce.Visible = true;
                lbTotalNfce.Text = quantidadeMod65.ToString();
                lbQtdNotas.Visible = true;
                lbQtdNotas.Text = dataTable.Rows.Count.ToString();
                lblResultado.Visible = true;
                lblResultado.ForeColor = Color.Red;
                progressBarSalvando.Value = 0;

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
                            progressBarSalvando.Value += 1;
                            Application.DoEvents();
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
            }

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
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open();

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório dos XMLs Baixados",
                                FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titulo);

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                            // Definir largura das colunas (ajuste os valores conforme necessário)
                            float[] columnWidths = new float[] { 7f, 1f, 2f }; // exemplo de larguras personalizadas
                            table.SetWidths(columnWidths);

                            // Adicionar cabeçalhos
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Define cor de fundo para o cabeçalho
                                table.AddCell(cell);
                            }

                            // Adicionar linhas de dados
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }

                            }

                            // Adicionar a tabela ao documento
                            doc.Add(table);

                            // Adicionar o total ao final
                            Paragraph total = new Paragraph($"TOTAL = {lblResultado.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_RIGHT;
                            doc.Add(total);

                            doc.Close(); // Certifique-se de que o documento seja fechado corretamente
                        }

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
                saveFileDialog.FileName = "Relatório dos XMLs Faltantes.pdf";


                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open();

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório dos XMLs Faltantes",
                                FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titulo);

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView2.Columns.Count);

                            // Definir largura das colunas (ajuste os valores conforme necessário)
                            float[] columnWidths = new float[] { 2f, 1f }; // exemplo de larguras personalizadas
                            table.SetWidths(columnWidths);

                            // Adicionar cabeçalhos
                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Define cor de fundo para o cabeçalho
                                table.AddCell(cell);
                            }

                            // Adicionar linhas de dados
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }

                            }

                            // Adicionar a tabela ao documento
                            doc.Add(table);

                            // Adicionar o total ao final
                            Paragraph total = new Paragraph($"TOTAL DE NOTAS = {labelTotalNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER;
                            doc.Add(total);

                            doc.Close(); // Certifique-se de que o documento seja fechado corretamente
                        }

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
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = dataGridView2.Columns[i].HeaderText;
            }

            // Adicionar linhas de dados
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = dataGridView2.Rows[i].Cells[j].Value?.ToString();
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
            FormEnviaEmail formEnviaEmail = new FormEnviaEmail(this);
            formEnviaEmail.ShowDialog();
        }

        private void VerificarNotasFaltantes(DataTable dataTable, DataGridView novoDataGridView)
        {

            decimal valorAnterior = 0;

            // Limpa o DataGridView antes de adicionar novos valores
            novoDataGridView.Rows.Clear();

            string conteudo = null;
            string arquivo = null;

            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    conteudo = row["conteudo"].ToString();
                    arquivo = row["arquivo"].ToString();

                    // Carrega o conteúdo XML
                    XDocument xmlDoc = XDocument.Parse(conteudo);

                    // Verifica se há namespaces no documento
                    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

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
                                    novoDataGridView.Rows.Add(arquivo, i);
                                }
                            }

                            // Atualiza o valor anterior
                            valorAnterior = valorAtual;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Caso ocorra um erro, exibe uma mensagem
                MessageBox.Show($"Erro ao processar o arquivo {arquivo}: {ex.Message}");
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em breve a função extrair xmls de NFe");
        }
    }
}
