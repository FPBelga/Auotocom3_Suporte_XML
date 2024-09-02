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
using System.Windows.Forms;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Xml;

namespace Auotocom3_Suporte_XML
{
    public partial class FormPrincipal : MaterialForm
    {
        public TextBox textMes;
        public TextBox textAno;
        public string fantasia;  // Variável para armazenar o valor da tag <xFant>
        private DataTable dataTable;
        public FormPrincipal()
        {
            InitializeComponent();
            // Atribua o evento KeyDown aos TextBoxes
            textAno.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textMes.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textCaixas.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textDataIni.KeyDown += new KeyEventHandler(textBox_KeyDown);
            textDataFim.KeyDown += new KeyEventHandler(textBox_KeyDown);
            //  btnCarregarDados.KeyDown += new KeyEventHandler(textBox_KeyDown);



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

        }

        private void LimparDados()
        {
            try
            {
                // Desvincula o DataTable dos DataGridView
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;

                // Limpa os DataGridView
                dataGridView1.Rows.Clear();
               
                dataGridView2.Rows.Clear();

                // Limpa o DataTable
                if (dataTable != null)
                {
                    dataTable.Clear();
                    dataTable.Dispose(); // Opcional: libera os recursos do DataTable
                    dataTable = null; // Opcional: permite que o GC colete o DataTable
                }

                // Reseta o valor das Labels e outros controles
                lbTotalNfe.Text = string.Empty;
                lbQtdNotas.Text = string.Empty;
                lblResultado.Text = string.Empty;

                progressBarSalvando.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar os dados: {ex.Message}");
            }
        }      

        private void btnRelXMLPDF_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "Relatório PDF dos XML NFCE Baixados.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        dataGridView1.Columns["num_caixa"].HeaderText = "Caixa";
                        dataGridView1.Columns.Remove("hora");
                        dataGridView1.Columns.Remove("n14");
                        dataGridView1.Columns.Remove("nfe_cstat");
                        dataGridView1.Columns.Remove("nfe_chave");
                        dataGridView1.Columns.Remove("nfe_canc");
                        dataGridView1.Columns.Remove("arquivo");
                        dataGridView1.Columns["c07"].HeaderText = "COO";


                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open();

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório PDF dos XML NFCE Baixados",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titulo);

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                            // Definir largura das colunas (ajuste os valores conforme necessário)
                            float[] columnWidths = new float[] { 1f, 2f, 2f, 2f, 7f }; // exemplo de larguras personalizadas
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
                                FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER;
                            doc.Add(total);
                            Paragraph totalNotas = new Paragraph($"TOTAL de XML = {lbQtdNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            totalNotas.Alignment = Element.ALIGN_CENTER;
                            doc.Add(totalNotas);

                            doc.Close(); // Certifique-se de que o documento seja fechado corretamente
                        }

                        MessageBox.Show("Relatório PDF dos XML NFCE Baixados gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}");
                    }
                }
            }
        }
        private void btnRelXMLPDF2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "Relatório PDF dos XML NFE Baixados.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        dataGridView1.Columns.Remove("arquivo");
                        dataGridView1.Columns["caixa"].HeaderText = "Serie";

                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open();

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório PDF dos XML NFE Baixados",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titulo);

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                            // Definir largura das colunas (ajuste os valores conforme necessário)
                            float[] columnWidths = new float[] { 7f, 2f, 2f }; // exemplo de larguras personalizadas
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
                                FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER;
                            doc.Add(total);
                            Paragraph totalNotas = new Paragraph($"TOTAL de XML = {lbQtdNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            totalNotas.Alignment = Element.ALIGN_CENTER;
                            doc.Add(totalNotas);

                            doc.Close(); // Certifique-se de que o documento seja fechado corretamente
                        }

                        MessageBox.Show("Relatório PDF dos XML NFCE Baixados gerado com sucesso!");
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
                saveFileDialog.FileName = "Relatório dos XML NFCE Baixados.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Excluindo e renomeando as colunas
                        dataGridView1.Columns["num_caixa"].HeaderText = "Caixa";
                        dataGridView1.Columns.Remove("hora");
                        dataGridView1.Columns.Remove("n14");
                        dataGridView1.Columns.Remove("nfe_cstat");
                        dataGridView1.Columns.Remove("nfe_chave");
                        dataGridView1.Columns.Remove("nfe_canc");
                        dataGridView1.Columns.Remove("arquivo");
                        dataGridView1.Columns["c07"].HeaderText = "COO";

                        string caminhoExcel = saveFileDialog.FileName;

                        // Criar o Workbook
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Relatório dos XML NFCE Baixados");

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

                        MessageBox.Show("Relatório EXCEL dos XML NFCE Baixados gerado com sucesso!");
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
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Salvar Relatório em Excel";
                saveFileDialog.FileName = "Relatório dos XML Faltantes.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {                       

                        string caminhoExcel = saveFileDialog.FileName;

                        // Criar o Workbook
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Relatório dos XML Faltantes");

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

                        MessageBox.Show("Relatório EXCEL gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo Excel: {ex.Message}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textSenha.Enabled = !textLogin.Enabled;
            textServidor.Enabled = !textServidor.Enabled;
            textPorta.Enabled = !textPorta.Enabled;
            textLogin.Enabled = !textLogin.Enabled;
            btnTestarConexao.Visible = !btnTestarConexao.Visible;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            FormEnviaEmail formEnviaEmail = new FormEnviaEmail(this);
            formEnviaEmail.ShowDialog();
        }
        //private void ExportToExcel()
        //{
        //    // Creating a Excel object.
        //    Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

        //    try
        //    {

        //        worksheet = workbook.ActiveSheet;

        //        worksheet.Name = "ExportedFromDatGrid";

        //        int cellRowIndex = 1;
        //        int cellColumnIndex = 1;

        //        //Loop through each row and read value from each column.
        //        for (int i = 0; i < dgvCityDetails.Rows.Count - 1; i++)
        //        {
        //            for (int j = 0; j < dgvCityDetails.Columns.Count; j++)
        //            {
        //                // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
        //                if (cellRowIndex == 1)
        //                {
        //                    worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Columns[j].HeaderText;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCityDetails.Rows[i].Cells[j].Value.ToString();
        //                }
        //                cellColumnIndex++;
        //            }
        //            cellColumnIndex = 1;
        //            cellRowIndex++;
        //        }

        //        //Getting the location and file name of the excel to save from user.
        //        SaveFileDialog saveDialog = new SaveFileDialog();
        //        saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        //        saveDialog.FilterIndex = 2;

        //        if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            workbook.SaveAs(saveDialog.FileName);
        //            MessageBox.Show("Export Successful");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        excel.Quit();
        //        workbook = null;
        //        excel = null;
        //    }

        //}
        //private void btn_xml_Click(object sender, EventArgs e)
        //{
        //    string FileName = @"C:\Xml_Entrada\2053- CITROLEO.xml";
        //    List<ClasseItensXml> ListaItens = new List<ClasseItensXml>(); //A lista é do tipo ClasseItensXml
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(FileName);
        //    var proditens = doc.GetElementsByTagName("prod");

        //    foreach (XmlElement nodo in proditens)
        //    {
        //        ListaItens.Add(
        //             new ClasseItensXml()
        //             {
        //                 CodigoProduto = nodo.GetElementsByTagName("cProd")[0].InnerText.Trim(),
        //                 NomeProduto = nodo.GetElementsByTagName("xProd")[0].InnerText.Trim(),
        //                 QuantidadeComercializada = nodo.GetElementsByTagName("qCom")[0].InnerText.Trim()
        //             });

        //        //Repare que cada "nodo" é um item, portanto só adiciona um ClasseItensXml na lista.
        //    }

        //    dgw_Xml.DataSource = ListaItens; //por fim, usa a lista de source

        //}
        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Verifica se nenhum item está selecionado no CheckedListBox
            if (checkedListBoxNota.CheckedItems.Count == 0)
            {
                // Exibe uma mensagem para o usuário caso nada esteja marcado
                MessageBox.Show("Por favor, selecione uma opção ('NFCE' ou 'NFE') no checklist antes de prosseguir.", "Seleção Obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método para evitar a execução de código adicional
            }

            // Verifica se o item "NFCE" está selecionado no CheckedListBox
            if (checkedListBoxNota.CheckedItems.Contains("NFCE"))
            {
                // Executa a ação se "NFCE" estiver selecionado
                // Código para a ação se "NFCE" estiver selecionado

                // Inicia o cronômetro
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                LimparDados();

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
                                "   WHEN (fiscal_r04.nfe_cstat = 100 OR fiscal_r04.nfe_cstat = 150) AND fiscal_r04.nfe_canc = '' THEN 'FATURADA' " +
                                "   WHEN (fiscal_r04.nfe_cstat = 100 OR fiscal_r04.nfe_cstat = 150) AND fiscal_r04.nfe_canc = 101 THEN 'CANCELADA' " +
                                "   ELSE 'PRE-NOTA' " +
                                " END AS Situacao," +
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

                    lbTotalNfce.Visible = true;
                    lbTotalNfce.Text = quantidadeArquivos.ToString();
                    lbQtdNotas.Visible = true;
                    lbQtdNotas.Text = dataTable.Rows.Count.ToString();
                    lblResultado.Visible = true;
                    lbTotalNfe.Text = "0";

                    progressBarSalvando.Value = 0;

                    decimal valorFormatado = somaVNF / 100;
                    lblResultado.Text = valorFormatado.ToString("N2", new CultureInfo("pt-BR"));

                    // Remove a coluna 'conteudo' e atualiza o DataGridView
                    dataTable.Columns.Remove("conteudo");
                    dataGridView1.DataSource = dataTable;

                    string zipNome;

                    if (materialCheckbox1.Checked)
                    {
                        zipNome = $"XML_NFCE_{fantasia}_{textMes.Text}_{textAno.Text}_{string.Join("_", caixas)}.zip";
                    }
                    else
                    {
                        zipNome = $"XML_NFCE_{fantasia}_{textMes.Text}_{textAno.Text}_Completo.zip";
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

                        MessageBox.Show($"Arquivo ZIP '{zipNome}' criado com sucesso em '{pasta}'!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao tentar compactar os arquivos: {ex.Message}");
                    }

                    // Habilita os botões relacionados a relatórios e envio de e-mail
                    btnRelXMLPDF.Enabled = true;
                    btnRelXMLPDF.Visible = true;
                    btnRelXMLPDF2.Enabled = false;
                    btnRelXMLPDF2.Visible = false;
                    btnRelXMLEXCEL.Enabled = true;
                    btnRelXMLEXCEL.Visible = true;
                    btnRelXMLEXCEL2.Enabled = false;
                    btnRelXMLEXCEL2.Visible = false;
                    btnRelFaltntesLPDF.Enabled = true;
                    btnRelFaltntesLEXCEL.Enabled = true;
                    btnEnviarEmail.Enabled = true;
                }
            }
            else if (checkedListBoxNota.CheckedItems.Contains("NFE"))
            {
                // Executa a ação alternativa se "NFCE" não estiver selecionado
                // Código para a ação alternativa se "NFCE" não estiver selecionado

                // Declaração e inicialização das variáveis fora do escopo de repetição
                string conteudo = string.Empty;
                string arquivo = string.Empty;
                decimal valorAnterior = 0;

                // Limpa todos os dados antes de carregar novos
                LimparDados();
                

                // Cria um dicionário para armazenar a última nota fiscal por série
                Dictionary<string, decimal> ultimaNotaPorSerie = new Dictionary<string, decimal>();

                if (materialCheckbox1.Checked)
                {
                    MessageBox.Show("O botão não está disponível quando o checkbox Caixas está marcado.");
                    return;
                }

                // Inicia o cronômetro
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                textDatabase.Text = "Autocom3_Filial_Movimento_Mensal_" + textAno.Text + "_" + textMes.Text;

                string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

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

                bool isFantasiaCapturada = false;

                string query = "SELECT chavenfe, arquivo, caixa, data, conteudo FROM repositorio_de_xml WHERE conteudo LIKE '%<mod>55</mod>%'";

                if (isDataInicioValida)
                {
                    query += " AND data >= @dataInicioFormatada";
                }

                if (isDataFimValida)
                {
                    query += " AND data <= @dataFimFormatada";
                }

                query += " ORDER BY chavenfe ASC";

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
                    int totalnotasfaltantes = 0;
                    progressBarSalvando.Maximum = quantidadeArquivos;
                    progressBarSalvando.Value = 0;

                    DataTable filteredDataTable = dataTable.Clone(); // Cria uma nova DataTable com a mesma estrutura

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Atribuição de valores às variáveis
                        conteudo = row["conteudo"].ToString();
                        arquivo = row["arquivo"].ToString();

                        if (string.IsNullOrEmpty(conteudo))
                        {
                            continue; // Continua para o próximo registro
                        }

                        XDocument xmlDoc;
                        try
                        {
                            xmlDoc = XDocument.Parse(conteudo);
                        }
                        catch (Exception ex)
                        {
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

                        // Filtra apenas as notas fiscais cujo <mod> seja igual a 55
                        bool isNotaMod55 = xmlDoc.Descendants(ns + "mod").Any(e => e.Value == "55");
                        if (!isNotaMod55)
                        {
                            continue; // Pula para o próximo registro se não for mod 55
                        }

                        foreach (var elemento in xmlDoc.Descendants(ns + "vNF"))
                        {
                            if (decimal.TryParse(elemento.Value, out decimal valor))
                            {
                                somaVNF += valor;
                            }
                        }

                        // Captura o valor da tag <serie>
                        string serie = xmlDoc.Descendants(ns + "serie").FirstOrDefault()?.Value ?? "Desconhecida";

                        

                        // Verifica se a série já existe no dicionário, caso contrário, inicializa
                        if (!ultimaNotaPorSerie.ContainsKey(serie))
                        {
                            ultimaNotaPorSerie[serie] = 0;
                        }

                        try
                        {
                            // Verifica os valores de <nNF>
                            foreach (var elemento in xmlDoc.Descendants(ns + "nNF"))
                            {
                                if (decimal.TryParse(elemento.Value, out decimal valorAtual))
                                {
                                    // Obtém o último valor de nNF para a série atual
                                    valorAnterior = ultimaNotaPorSerie[serie];

                                    // Se o valor anterior for diferente de zero e a diferença for maior que 1, temos notas faltantes
                                    if (valorAnterior != 0 && valorAtual > valorAnterior + 1)
                                    {
                                        // Adiciona ao novo DataGridView todas as notas faltantes
                                        for (decimal i = valorAnterior + 1; i < valorAtual; i++)
                                        {
                                            // Adiciona a nota faltante com base na série
                                            dataGridView2.Rows.Add(i, serie);
                                            totalnotasfaltantes++;
                                        }
                                    }

                                    // Atualiza o valor anterior para a série atual no dicionário
                                    ultimaNotaPorSerie[serie] = valorAtual;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Caso ocorra um erro, exibe uma mensagem
                            MessageBox.Show($"Erro ao processar o arquivo {arquivo}: {ex.Message}");
                        }

                        string caminhoArquivo = Path.Combine(pasta, $"{arquivo}.xml");

                        if (File.Exists(caminhoArquivo))
                        {
                            File.Delete(caminhoArquivo);
                        }

                        xmlDoc.Save(caminhoArquivo);
                        progressBarSalvando.Value += 1;
                        Application.DoEvents();

                        // Adiciona a linha ao DataTable filtrado
                        filteredDataTable.ImportRow(row);
                    }

                    // Limpa o DataGridView antes de adicionar novos valores
                    dataGridView1.Rows.Clear();
                    


                    // Atualiza o DataGridView com o DataTable filtrado
                    dataGridView1.DataSource = filteredDataTable;
                    dataGridView1.Columns.Remove("Caixa");
                    // Alterando as propriedades da coluna após carregar os dados
                    DataGridViewColumn coluna = dataGridView1.Columns["num_caixa"];

                    if (coluna != null)
                    {
                        coluna.DataPropertyName = "caixa";
                        coluna.Name = "caixa";
                        coluna.HeaderText = "Serie";
                    }

                    // Para o cronômetro
                    stopwatch.Stop();
                    TimeSpan tempoTotal = stopwatch.Elapsed;

                    // Atualiza o Label com o tempo total
                    label10.Text = $"Tempo Total: {tempoTotal.TotalSeconds:F2} segundos";

                    // Atualiza a interface com os resultados
                    MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");
                    lbTotalNfe.Visible = true;
                    lbTotalNfce.Text = "0";
                    lbTotalNfe.Text = dataTable.Rows.Count.ToString();
                    lbQtdNotas.Visible = true;
                    lbQtdNotas.Text =  dataGridView1.Rows.Count.ToString();
                    lblResultado.Visible = true;
                    progressBarSalvando.Value = 0;

                    // Formata o valor total de NF com duas casas decimais
                    decimal valorFormatado = somaVNF / 100;
                    lblResultado.Text = valorFormatado.ToString("N2", new CultureInfo("pt-BR"));
                    labelTotalNotas.Text = totalnotasfaltantes.ToString();

                    // Remove a coluna 'conteudo' que não é necessária para exibição
                    filteredDataTable.Columns.Remove("conteudo");
                    


                    // Define o nome do arquivo ZIP com base na seleção do checkbox
                    string zipNome = $"XML_NFE_{fantasia}_{textMes.Text}_{textAno.Text}.zip";
                    string zipPath = Path.Combine(pasta, zipNome);
                    string pastaCompleto = Path.Combine(pasta, "XMLCompleto");

                    try
                    {
                        // Verifica se o arquivo ZIP já existe e o exclui se necessário
                        if (File.Exists(zipPath))
                        {
                            File.Delete(zipPath);
                        }

                        // Cria a pasta "XMLCompleto" para armazenar os arquivos antes de compactar, se necessário
                        if (!Directory.Exists(pastaCompleto))
                        {
                            Directory.CreateDirectory(pastaCompleto);
                        }

                        // Move ou copia os arquivos XML para a pasta "XMLCompleto" antes de compactar, se necessário
                        if (!materialCheckbox1.Checked)
                        {
                            foreach (string file in Directory.GetFiles(pasta, "*.xml"))
                            {
                                string destFile = Path.Combine(pastaCompleto, Path.GetFileName(file));
                                File.Move(file, destFile);
                            }
                        }

                        // Configura a barra de progresso para a compactação dos arquivos
                        string[] arquivosParaCompactar = Directory.GetFiles(materialCheckbox1.Checked ? pasta : pastaCompleto, "*.xml", SearchOption.AllDirectories);
                        progressBarSalvando.Maximum = arquivosParaCompactar.Length;
                        progressBarSalvando.Value = 0;

                        // Cria o arquivo ZIP com todos os arquivos na pasta "XMLCompleto" ou "pasta" conforme o checkbox
                        if (!materialCheckbox1.Checked)
                        {
                            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                            {
                                foreach (string filePath in arquivosParaCompactar)
                                {
                                    string entryName = Path.GetRelativePath(materialCheckbox1.Checked ? pasta : pastaCompleto, filePath);
                                    archive.CreateEntryFromFile(filePath, entryName, CompressionLevel.Optimal);
                                    progressBarSalvando.Value += 1;
                                    Application.DoEvents();
                                }
                            }
                        }

                        // Verifica se o checkbox está desmarcado para remover a pasta "XMLCompleto"
                        if (!materialCheckbox1.Checked)
                        {
                            Directory.Delete(pastaCompleto, true);
                        }

                        progressBarSalvando.Value = 0;
                        MessageBox.Show($"Arquivo ZIP '{zipNome}' criado com sucesso em '{pasta}'!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao criar o arquivo ZIP: {ex.Message}");
                    }
                }

                // Habilita os botões relacionados a relatórios e envio de e-mail
                btnRelXMLPDF2.Enabled = true;
                btnRelXMLPDF2.Visible = true;
                btnRelXMLPDF.Enabled = false;
                btnRelXMLPDF.Visible = false;
                btnRelXMLEXCEL2.Enabled = true;
                btnRelXMLEXCEL2.Visible = true;
                btnRelXMLEXCEL.Enabled = false;
                btnRelXMLEXCEL.Visible = false;
                btnRelFaltntesLPDF.Enabled = true;
                btnRelFaltntesLEXCEL.Enabled = true;
                btnEnviarEmail.Enabled = true;
            }

            else
            {
                // Exibe uma mensagem se "NFCE" e "NFE" não estiverem selecionados
                MessageBox.Show("Por favor, selecione 'NFCE' ou 'NFE' no checklist para continuar.", "Seleção Obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void checkedListBoxNota_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Verifica se o item está sendo marcado
            if (e.NewValue == CheckState.Checked)
            {
                // Percorre todos os itens no CheckedListBox
                for (int i = 0; i < checkedListBoxNota.Items.Count; i++)
                {
                    // Se o item não for o item selecionado atualmente
                    if (i != e.Index)
                    {
                        // Desmarca o item
                        checkedListBoxNota.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void btnRelXMLEXCEL2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Salvar Relatório em Excel";
                saveFileDialog.FileName = "Relatório dos XML NFE Baixados.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Renomeando as colunas                        
                        dataGridView1.Columns["caixa"].HeaderText = "Serie";

                        string caminhoExcel = saveFileDialog.FileName;

                        // Criar o Workbook
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Relatório dos XML NFE Baixados");

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

                        MessageBox.Show("Relatório EXCEL dos XML NFE Baixados gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo Excel: {ex.Message}");
                    }
                }
            }
        }
    }
}
