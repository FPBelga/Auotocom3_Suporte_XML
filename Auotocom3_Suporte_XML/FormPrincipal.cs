using Autocom3_Suporte_XML;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Xml.Linq;

namespace Auotocom3_Suporte_XML
{
    public partial class FormPrincipal : MaterialForm
    {
        public TextBox textMes;          // Campo de texto para o mês
        public TextBox textAno;          // Campo de texto para o ano
        public string fantasia;          // Variável para armazenar o valor da tag <xFant> (possivelmente um nome fantasia de uma empresa)
        private DataTable dataTable;     // Tabela de dados para armazenar informações consultadas
        public FormPrincipal()
        {
            InitializeComponent();  // Método gerado automaticamente para inicializar os componentes do formulário

            // Atribuindo o evento KeyDown aos campos de texto (TextBoxes)
            textAno.KeyDown += new KeyEventHandler(textBox_KeyDown);     // Adiciona um evento KeyDown ao TextBox textAno
            textMes.KeyDown += new KeyEventHandler(textBox_KeyDown);     // Adiciona um evento KeyDown ao TextBox textMes
            textCaixas.KeyDown += new KeyEventHandler(textBox_KeyDown);  // Adiciona um evento KeyDown ao TextBox textCaixas
            textDataIni.KeyDown += new KeyEventHandler(textBox_KeyDown); // Adiciona um evento KeyDown ao TextBox textDataIni
            textDataFim.KeyDown += new KeyEventHandler(textBox_KeyDown); // Adiciona um evento KeyDown ao TextBox textDataFim
            btnCarregarDados.KeyDown += new KeyEventHandler(textBox_KeyDown); // Adiciona um evento KeyDown ao botão btnCarregarDados

            textDatabase.Text = "";
            textDatabase.Text = textBanco.Text + "_" + textAno.Text + "_" + textMes.Text;

            // Inicialização do MaterialSkinManager para gerenciar o tema e o esquema de cores do formulário
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);  // Adiciona o formulário atual ao gerenciador de MaterialSkin
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Define o tema como LIGHT (claro)

            // Configuração do esquema de cores do MaterialSkin
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.DeepPurple700, // Cor primária para componentes principais (botões, barras de título, etc.)
                Primary.DeepPurple700, // Cor para elementos secundários (ex: barras de navegação)
                Primary.DeepPurple700, // Cor de destaque (ex: barra de progresso, seleção)
                Accent.DeepPurple700,  // Cor para acentuação (botões flutuantes de ação)
                TextShade.WHITE        // Cor do texto


            );
        }

        // Evento acionado quando o estado do checkbox "materialCheckbox1" é alterado (marcado/desmarcado)
        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            // Habilita ou desabilita o TextBox "textCaixas" dependendo se o checkbox está marcado ou não
            textCaixas.Enabled = materialCheckbox1.Checked;
        }

        // Evento de clique do botão "btnTestarConexao" para testar a conexão com o banco de dados
        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            // Monta a string de conexão com os parâmetros fornecidos nos TextBoxes correspondentes
            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

            try
            {
                // Cria uma nova conexão SQL usando a string de conexão especificada
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tenta abrir a conexão
                    connection.Open();
                    // Exibe uma mensagem de sucesso se a conexão for aberta corretamente
                    MessageBox.Show("Conexão bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção ao tentar abrir a conexão
                MessageBox.Show($"Erro na conexão: {ex.Message}");
            }
        }

        // Método para limpar dados do DataGridView e resetar controles associados
        private void LimparDados()
        {
            try
            {
                // Desvincula o DataTable dos DataGridView para evitar problemas ao limpar
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;

                // Limpa todas as linhas dos DataGridView
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                // Limpa o conteúdo do DataTable, se ele não for nulo
                if (dataTable != null)
                {
                    dataTable.Clear();       // Remove todos os dados do DataTable
                    dataTable.Dispose();     // Libera os recursos associados ao DataTable (opcional)
                    dataTable = null;        // Define o DataTable como null para permitir coleta de lixo (GC)
                }

                // Reseta o texto das Labels e outros controles de exibição
                lbTotalNfe.Text = string.Empty;
                lbQtdNotas.Text = string.Empty;
                lblResultado.Text = string.Empty;

                // Reseta o valor da barra de progresso para 0
                progressBarSalvando.Value = 0;
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção ao tentar limpar os dados
                MessageBox.Show($"Erro ao limpar os dados: {ex.Message}");
            }
        }

        // Manipulador de evento para o clique do botão 'btnRelXMLPDF' que gera um relatório em PDF dos dados no DataGridView 'dataGridView1'.
        private void btnRelXMLPDF_Click_1(object sender, EventArgs e)
        {
            // Cria uma nova instância de SaveFileDialog para permitir ao usuário selecionar onde salvar o arquivo PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Define o filtro para mostrar apenas arquivos PDF e define o título da caixa de diálogo
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                // Define um nome de arquivo padrão para o arquivo PDF a ser salvo
                saveFileDialog.FileName = "Relatório PDF dos XML NFCE Baixados.pdf";

                // Verifica se o usuário clicou em 'OK' na caixa de diálogo de salvar arquivo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Armazena o caminho completo do arquivo PDF escolhido pelo usuário
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        // Modifica o cabeçalho da coluna "num_caixa" para "Caixa" no DataGridView
                        dataGridView1.Columns["num_caixa"].HeaderText = "Caixa";
                        // Remove as colunas não desejadas do DataGridView antes de gerar o relatório
                        dataGridView1.Columns.Remove("hora");
                        dataGridView1.Columns.Remove("n14");
                        dataGridView1.Columns.Remove("nfe_cstat");
                        dataGridView1.Columns.Remove("nfe_chave");
                        dataGridView1.Columns.Remove("nfe_canc");
                        dataGridView1.Columns.Remove("arquivo");
                        // Modifica o cabeçalho da coluna "c07" para "COO" no DataGridView
                        dataGridView1.Columns["c07"].HeaderText = "COO";

                        // Criação do documento PDF usando a biblioteca iTextSharp
                        using (Document doc = new Document())
                        {
                            // Inicializa o escritor de PDF para criar o arquivo no local especificado
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            // Abre o documento para edição
                            doc.Open();

                            // Cria um título para o documento PDF com formatação
                            Paragraph titulo = new Paragraph("Relatório PDF dos XML NFCE Baixados",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER; // Centraliza o título no documento
                            doc.Add(titulo); // Adiciona o título ao documento

                            doc.Add(new Paragraph("\n")); // Adiciona uma linha em branco para espaçamento

                            // Cria uma tabela PDF com o número de colunas igual ao número de colunas no DataGridView
                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                            // Define a largura de cada coluna na tabela (os valores podem ser ajustados conforme necessário)
                            float[] columnWidths = new float[] { 1f, 2f, 2f, 2f, 7f }; // Exemplo de larguras personalizadas
                            table.SetWidths(columnWidths);

                            // Adiciona os cabeçalhos das colunas à tabela PDF
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                // Cria uma célula de cabeçalho com o texto do cabeçalho da coluna do DataGridView
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Define a cor de fundo do cabeçalho para cinza claro
                                table.AddCell(cell); // Adiciona a célula de cabeçalho à tabela
                            }

                            // Adiciona as linhas de dados do DataGridView à tabela PDF
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    // Adiciona cada célula do DataGridView à tabela PDF
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }
                            }

                            // Adiciona a tabela preenchida ao documento PDF
                            doc.Add(table);

                            // Adiciona o total ao final do documento
                            Paragraph total = new Paragraph($"TOTAL = {lblResultado.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER; // Centraliza o parágrafo de total no documento
                            doc.Add(total); // Adiciona o total ao documento

                            // Adiciona o total de XML ao final do documento
                            Paragraph totalNotas = new Paragraph($"TOTAL de XML = {lbQtdNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            totalNotas.Alignment = Element.ALIGN_CENTER; // Centraliza o parágrafo de total de notas no documento
                            doc.Add(totalNotas); // Adiciona o total de notas ao documento

                            doc.Close(); // Fecha o documento para salvar todas as alterações
                        }

                        // Exibe uma mensagem informando que o relatório PDF foi gerado com sucesso
                        MessageBox.Show("Relatório PDF dos XML NFCE Baixados gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        // Exibe uma mensagem de erro se ocorrer uma exceção durante a criação do PDF
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}");
                    }
                }
            }
        }

        private void btnRelXMLPDF2_Click(object sender, EventArgs e)
        {
            // Abrir diálogo para salvar o arquivo PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configurações do diálogo de salvamento
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "Relatório PDF dos XML NFE Baixados.pdf";

                // Verifica se o usuário clicou em "OK" no diálogo de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName; // Obtém o caminho do arquivo selecionado

                    try
                    {
                        // Ajustes nas colunas do DataGridView antes de exportar
                        dataGridView1.Columns.Remove("arquivo"); // Remove a coluna "arquivo"
                        dataGridView1.Columns["caixa"].HeaderText = "Serie"; // Renomeia o cabeçalho da coluna "caixa" para "Serie"

                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            // Cria um escritor para o documento PDF
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open(); // Abre o documento para escrita

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório PDF dos XML NFE Baixados",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER; // Alinha o título ao centro
                            doc.Add(titulo); // Adiciona o título ao documento

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                            // Definir largura das colunas
                            float[] columnWidths = new float[] { 7f, 2f, 2f }; // Larguras personalizadas das colunas
                            table.SetWidths(columnWidths);

                            // Adicionar cabeçalhos das colunas
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Define cor de fundo para o cabeçalho
                                table.AddCell(cell); // Adiciona a célula à tabela
                            }

                            // Adicionar linhas de dados
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    // Adiciona o valor de cada célula à tabela
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }
                            }

                            // Adicionar a tabela ao documento
                            doc.Add(table);

                            // Adicionar o total ao final do relatório
                            Paragraph total = new Paragraph($"TOTAL = {lblResultado.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER;
                            doc.Add(total);

                            Paragraph totalNotas = new Paragraph($"TOTAL de XML = {lbQtdNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            totalNotas.Alignment = Element.ALIGN_CENTER;
                            doc.Add(totalNotas);

                            doc.Close(); // Fecha o documento PDF
                        }

                        MessageBox.Show("Relatório PDF dos XML NFCE Baixados gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}"); // Mensagem de erro em caso de exceção
                    }
                }
            }
        }

        private void btnRelXMLEXCEL_Click_1(object sender, EventArgs e)
        {
            // Abrir diálogo para salvar o arquivo Excel
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configurações do diálogo de salvamento
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Salvar Relatório em Excel";
                saveFileDialog.FileName = "Relatório dos XML NFCE Baixados.xlsx";

                // Verifica se o usuário clicou em "OK" no diálogo de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Ajustes nas colunas do DataGridView antes de exportar
                        dataGridView1.Columns["num_caixa"].HeaderText = "Caixa";
                        dataGridView1.Columns.Remove("hora");
                        dataGridView1.Columns.Remove("n14");
                        dataGridView1.Columns.Remove("nfe_cstat");
                        dataGridView1.Columns.Remove("nfe_chave");
                        dataGridView1.Columns.Remove("nfe_canc");
                        dataGridView1.Columns.Remove("arquivo");
                        dataGridView1.Columns["c07"].HeaderText = "COO";

                        string caminhoExcel = saveFileDialog.FileName; // Obtém o caminho do arquivo selecionado

                        // Criar o Workbook Excel
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Relatório dos XML NFCE Baixados");

                        // Adicionar cabeçalhos das colunas
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
                        MessageBox.Show($"Erro ao salvar o arquivo Excel: {ex.Message}"); // Mensagem de erro em caso de exceção
                    }
                }
            }
        }


        private void btnRelFaltntesLPDF_Click(object sender, EventArgs e)
        {
            // Abrir diálogo para salvar o arquivo PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configurações do diálogo de salvamento
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "Relatório dos XMLs Faltantes.pdf";

                // Verifica se o usuário clicou em "OK" no diálogo de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName; // Obtém o caminho do arquivo selecionado

                    try
                    {
                        // Criar documento PDF
                        using (Document doc = new Document())
                        {
                            // Cria um escritor para o documento PDF
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open(); // Abre o documento para escrita

                            // Adicionar título ao documento com formatação
                            Paragraph titulo = new Paragraph("Relatório dos XMLs Faltantes",
                                FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER; // Alinha o título ao centro
                            doc.Add(titulo); // Adiciona o título ao documento

                            doc.Add(new Paragraph("\n")); // Adicionar espaço em branco

                            // Criar tabela PDF com o número de colunas correspondente ao DataGridView
                            PdfPTable table = new PdfPTable(dataGridView2.Columns.Count);

                            // Definir largura das colunas
                            float[] columnWidths = new float[] { 2f, 1f }; // Larguras personalizadas das colunas
                            table.SetWidths(columnWidths);

                            // Adicionar cabeçalhos das colunas
                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY; // Define cor de fundo para o cabeçalho
                                table.AddCell(cell); // Adiciona a célula à tabela
                            }

                            // Adicionar linhas de dados
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    // Adiciona o valor de cada célula à tabela
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }
                            }

                            // Adicionar a tabela ao documento
                            doc.Add(table);

                            doc.Close(); // Fecha o documento PDF
                        }

                        MessageBox.Show("Relatório PDF dos XMLs Faltantes gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}"); // Mensagem de erro em caso de exceção
                    }
                }
            }
        }

        private void btnRelFaltntesLEXCEL_Click(object sender, EventArgs e)
        {
            // Abre um diálogo para salvar o arquivo Excel
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Define o filtro para mostrar apenas arquivos Excel no diálogo
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                // Define o título da janela do diálogo de salvamento
                saveFileDialog.Title = "Salvar Relatório em Excel";
                // Define o nome padrão do arquivo que será salvo
                saveFileDialog.FileName = "Relatório dos XMLs Faltantes.xlsx";

                // Verifica se o usuário clicou em "OK" no diálogo de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Obtém o caminho do arquivo selecionado pelo usuário
                        string caminhoExcel = saveFileDialog.FileName;

                        // Cria um novo Workbook para o arquivo Excel usando ClosedXML
                        var workbook = new XLWorkbook();
                        // Adiciona uma nova planilha ao Workbook com o nome especificado
                        var worksheet = workbook.Worksheets.Add("Relatório dos XMLs Faltantes");

                        // Adiciona cabeçalhos às colunas da planilha a partir dos cabeçalhos do DataGridView
                        for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridView2.Columns[i].HeaderText;
                        }

                        // Adiciona os dados de cada célula do DataGridView à planilha Excel
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView2.Columns.Count; j++)
                            {
                                // Copia o valor da célula do DataGridView para a célula correspondente na planilha Excel
                                worksheet.Cell(i + 2, j + 1).Value = dataGridView2.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Salva o Workbook no caminho especificado pelo usuário
                        workbook.SaveAs(caminhoExcel);

                        // Exibe uma mensagem informando que o relatório Excel foi gerado com sucesso
                        MessageBox.Show("Relatório EXCEL dos XMLs Faltantes gerado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        // Captura qualquer exceção que ocorra durante o processo e exibe uma mensagem de erro
                        MessageBox.Show($"Erro ao salvar o arquivo Excel: {ex.Message}");
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Alterna o estado de habilitação do TextBox para senha com base no estado do TextBox para login.
            // Se textLogin estiver habilitado, textSenha será desabilitado e vice-versa. Repete para os outros textBox
            textBanco.Enabled = !textBanco.Enabled;
            textSenha.Enabled = !textLogin.Enabled;
            textServidor.Enabled = !textServidor.Enabled;
            textPorta.Enabled = !textPorta.Enabled;
            textLogin.Enabled = !textLogin.Enabled;
            btnTestarConexao.Visible = !btnTestarConexao.Visible;
            btnCarregaScantech.Visible = !btnCarregaScantech.Visible;
            materialButton2.Visible = !materialButton2.Visible;
            btnCarregarDados.Visible = !btnCarregarDados.Visible;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de envio de e-mail, passando a instância atual do formulário como parâmetro.
            FormEnviaEmail formEnviaEmail = new FormEnviaEmail(this);

            // Exibe o formulário de envio de e-mail como um diálogo modal.
            // Isso bloqueia a interação com o formulário pai até que o formulário de envio de e-mail seja fechado.
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
        private void btnCarregarDados_Click(object sender, EventArgs e)
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

                // Monta a string de conexão com os parâmetros fornecidos nos TextBoxes correspondentes
                string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=True;Encrypt=False";

                try
                {
                    // Cria uma nova conexão SQL usando a string de conexão especificada
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Tenta abrir a conexão
                        connection.Open();

                    }
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro se ocorrer uma exceção ao tentar abrir a conexão
                    MessageBox.Show($"Erro na conexão: {ex.Message}");
                }
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
                    labelTotalNotas.Text = dataGridView2.Rows.Count.ToString();

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
                    lbQtdNotas.Text = dataGridView1.Rows.Count.ToString();
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

        private void btnCarregaScantech_Click(object sender, EventArgs e)
        {

            // Executa a ação se "NFCE" estiver selecionado
            // Código para a ação se "NFCE" estiver selecionado

            // Inicia o cronômetro
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            LimparDados();


            // Monta a string de conexão com os parâmetros fornecidos nos TextBoxes correspondentes
            string connectionString = $"Data Source={textServidor.Text},{textPorta.Text};Initial Catalog={textDatabase.Text};User Id={textLogin.Text};Password={textSenha.Text};Integrated Security=False;Encrypt=False";

            try
            {
                // Cria uma nova conexão SQL usando a string de conexão especificada
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tenta abrir a conexão
                    connection.Open();

                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro se ocorrer uma exceção ao tentar abrir a conexão
                MessageBox.Show($"Erro na conexão: {ex.Message}");
            }

            string Caixa = textCaixas.Text;
            string[] caixas = Caixa.Split(',').Select(c => c.Trim()).ToArray(); // Definido aqui para estar disponível em todo o método

            DateTime dataInicio;
            DateTime dataFim;
            bool isDataInicioValida = DateTime.TryParseExact(textDataIni.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataInicio);
            bool isDataFimValida = DateTime.TryParseExact(textDataFim.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataFim);
            bool isFantasiaCapturada = false;

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
            //string query1 = "select conteudo, arquivo from repositorio_de_xml";

            //DataTable filteredDataTable = dataTable.Clone(); // Cria uma nova DataTable com a mesma estrutura

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    // Atribuição de valores às variáveis
            //    string conteudo = row["conteudo"].ToString();
            //    string arquivo = row["arquivo"].ToString();

            //    if (string.IsNullOrEmpty(conteudo))
            //    {
            //        continue; // Continua para o próximo registro
            //    }

            //    XDocument xmlDoc;
            //    try
            //    {
            //        xmlDoc = XDocument.Parse(conteudo);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Erro ao processar o XML do arquivo '{arquivo}': {ex.Message}");
            //        continue; // Continua para o próximo registro
            //    }

            //    XNamespace ns = xmlDoc.Root.GetDefaultNamespace();

            //    // Captura o valor da tag <xFant> somente no primeiro arquivo
            //    if (!isFantasiaCapturada)
            //    {
            //        foreach (var elemento in xmlDoc.Descendants(ns + "xFant"))
            //        {
            //            fantasia = elemento.Value;
            //            isFantasiaCapturada = true;
            //            break;
            //        }
            //    }
            //}

                // Conversão das datas para o formato "yyyy-MM-dd"
                string dataInicioFormatada = dataInicio.ToString("yyyy-MM-dd");
            string dataFimFormatada = dataFim.ToString("yyyy-MM-dd");

            string query = "SELECT " +
                            " fiscal_r04.loja," +
                            " fiscal_r04.num_caixa," +
                            " fiscal_r04.modelo," +
                            " fiscal_r04.data," +
                            " fiscal_r04.hora," +
                            " fiscal_r04.c07," +
                            " fiscal_r04.nfe_numero," +
                            " fiscal_r04.n14," +
                            " fiscal_r04.nfe_cstat," +
                            " fiscal_r04.nfe_chave," +
                            " fiscal_r04.nfe_canc," +
                            " CASE " +
                            "   WHEN (fiscal_r04.nfe_cstat = 100 OR fiscal_r04.nfe_cstat = 150) AND fiscal_r04.nfe_canc = '' THEN 'FATURADA' " +
                            "   WHEN (fiscal_r04.nfe_cstat = 100 OR fiscal_r04.nfe_cstat = 150) AND fiscal_r04.nfe_canc = 101 THEN 'CANCELADA' " +
                            "   ELSE 'PRE-NOTA' " +
                            " END AS Situacao," +
                            " CASE " +
                            "   WHEN fiscal_r04.modelo = 11 THEN 'NFC-e'" +
                            "   ELSE 'NF-e' " +
                            " END AS Modelo" +
                            " FROM dbo.fiscal_r04 " +
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

                // Variável para somar o total de todas as notas (campo n14)
                decimal somaTotalNotas = 0;
                int quantidadeArquivos = dataTable.Rows.Count;

                progressBarSalvando.Maximum = quantidadeArquivos;
                progressBarSalvando.Value = 0;

                // Armazenar as notas por caixa
                var notasPorCaixa = new Dictionary<string, List<decimal>>();

                foreach (DataRow row in dataTable.Rows)
                {
                    // Verifica se a coluna n14 não é nula ou vazia
                    if (row["n14"] != DBNull.Value && !string.IsNullOrEmpty(row["n14"].ToString()))
                    {
                        // Converte o valor da coluna n14 para decimal e soma
                        decimal valorN14;
                        if (decimal.TryParse(row["n14"].ToString(), out valorN14))
                        {
                            somaTotalNotas += valorN14;
                        }
                    }
                    // Atualiza o progresso da barra
                    progressBarSalvando.Value += 1;
                    Application.DoEvents();
                }

                if (dataGridView1.Columns.Contains("Chave"))
                {
                    dataGridView1.Columns.Remove("Chave");
                }
                if (dataGridView1.Columns.Contains("chavenfe"))
                {
                    dataGridView1.Columns.Remove("chavenfe");
                }

                // Para o cronômetro
                stopwatch.Stop();
                TimeSpan tempoTotal = stopwatch.Elapsed;

                // Atualiza o Label com o tempo total
                label10.Text = $"Tempo Total: {tempoTotal.TotalSeconds:F2} segundos";

                // Atualiza a interface com os resultados
                MessageBox.Show($"Finalizado com sucesso: {dataTable.Rows.Count} registros processados.");

                lbTotalNfce.Visible = true;
                lbTotalNfce.Text = dataTable.Rows.Count.ToString();
                lbQtdNotas.Visible = true;
                lbQtdNotas.Text = dataTable.Rows.Count.ToString();
                lblResultado.Visible = true;
                lbTotalNfe.Text = "0";
                progressBarSalvando.Value = 0;

                //decimal valorFormatado = somaTotalNotas / 100;
                lblResultado.Text = somaTotalNotas.ToString("N2", new CultureInfo("pt-BR"));

                dataGridView1.DataSource = dataTable;
                materialButton2.Enabled = true;
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "Relatório PDF das NFCE " + textDataIni.Text.Replace("/", "_") + "_" +/* fantasia.ToString()*/ ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoPDF = saveFileDialog.FileName;

                    try
                    {
                        dataGridView1.Columns["num_caixa"].HeaderText = "Caixa";
                        dataGridView1.Columns["n14"].HeaderText = "Valor";
                        dataGridView1.Columns["c07"].HeaderText = "COO";
                        dataGridView1.Columns["nfe_numero"].HeaderText = "Nota";
                        dataGridView1.Columns["Modelo1"].HeaderText = "Modelo";
                        dataGridView1.Columns.Remove("Modelo");
                        dataGridView1.Columns.Remove("nfe_cstat");
                        dataGridView1.Columns.Remove("nfe_chave");
                        dataGridView1.Columns.Remove("nfe_canc");
                       
                        if (dataGridView1.Columns.Contains("Chave"))
                        {
                            dataGridView1.Columns.Remove("Chave");
                        }
                        if (dataGridView1.Columns.Contains("chavenfe"))
                        {
                            dataGridView1.Columns.Remove("chavenfe");
                        }

                        // Configura o documento em modo paisagem
                        using (Document doc = new Document(PageSize.A4.Rotate()))
                        {
                            PdfWriter.GetInstance(doc, new FileStream(caminhoPDF, FileMode.Create));
                            doc.Open();

                            Paragraph titulo = new Paragraph("Relatório PDF das NFCE " + textDataIni.Text.Replace("/", "_") + ".pdf",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            titulo.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titulo);

                            doc.Add(new Paragraph("\n"));

                            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                            float[] columnWidths = new float[] { 1f, 1f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
                            table.SetWidths(columnWidths);

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Phrase(cell.Value?.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 08)));
                                }
                            }

                            doc.Add(table);

                            Paragraph total = new Paragraph($"TOTAL = {lblResultado.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD));
                            total.Alignment = Element.ALIGN_CENTER;
                            doc.Add(total);

                            Paragraph totalNotas = new Paragraph($"TOTAL de Notas = {lbQtdNotas.Text}",
                                FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD));
                            totalNotas.Alignment = Element.ALIGN_CENTER;
                            doc.Add(totalNotas);

                            doc.Close();
                        }

                        MessageBox.Show("Relatório PDF dos XML NFCE Baixados gerado com sucesso!");
                        LimparDados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo PDF: {ex.Message}");
                    }
                }
            }
        }
    }
}