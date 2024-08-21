namespace Auotocom3_Suporte_XML
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            lblResultado = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Chave = new DataGridViewTextBoxColumn();
            Caixa = new DataGridViewTextBoxColumn();
            materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            textCaixas = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            btnCarregarDados = new MaterialSkin.Controls.MaterialButton();
            textDatabase = new TextBox();
            textPorta = new TextBox();
            textServidor = new TextBox();
            textSenha = new TextBox();
            textLogin = new TextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            novoDataGridView = new DataGridView();
            nota = new DataGridViewTextBoxColumn();
            serie = new DataGridViewTextBoxColumn();
            lbQtdNotas = new Label();
            label3 = new Label();
            btnRelXMLPDF = new MaterialSkin.Controls.MaterialButton();
            lbTotalNfe = new Label();
            label4 = new Label();
            lbTotalNfce = new Label();
            label5 = new Label();
            progressBarSalvando = new ProgressBar();
            btnTestarConexao = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            btnRelXMLEXCEL = new MaterialSkin.Controls.MaterialButton();
            btnRelFaltntesLEXCEL = new MaterialSkin.Controls.MaterialButton();
            label6 = new Label();
            btnRelFaltntesLPDF = new MaterialSkin.Controls.MaterialButton();
            textAno = new TextBox();
            textMes = new TextBox();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            button1 = new Button();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            textDataIni = new MaskedTextBox();
            textDataFim = new MaskedTextBox();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            btnEnviarEmail = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)novoDataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.ForeColor = Color.Red;
            lblResultado.Location = new Point(408, 504);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(60, 23);
            lblResultado.TabIndex = 34;
            lblResultado.Text = "Soma";
            lblResultado.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(286, 504);
            label1.Name = "label1";
            label1.Size = new Size(110, 23);
            label1.TabIndex = 33;
            label1.Text = "Valor Total:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Chave, Caixa });
            dataGridView1.Location = new Point(283, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(497, 286);
            dataGridView1.TabIndex = 32;
            // 
            // Chave
            // 
            Chave.DataPropertyName = "chavenfe";
            Chave.HeaderText = "chavenfe";
            Chave.Name = "Chave";
            Chave.Width = 300;
            // 
            // Caixa
            // 
            Caixa.DataPropertyName = "caixa";
            Caixa.HeaderText = "caixa";
            Caixa.Name = "Caixa";
            Caixa.Width = 60;
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.Depth = 0;
            materialCheckbox1.Location = new Point(64, 285);
            materialCheckbox1.Margin = new Padding(0);
            materialCheckbox1.MouseLocation = new Point(-1, -1);
            materialCheckbox1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox1.Name = "materialCheckbox1";
            materialCheckbox1.ReadOnly = false;
            materialCheckbox1.Ripple = true;
            materialCheckbox1.Size = new Size(31, 31);
            materialCheckbox1.TabIndex = 31;
            materialCheckbox1.UseVisualStyleBackColor = true;
            materialCheckbox1.CheckedChanged += materialCheckbox1_CheckedChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel6.Location = new Point(-15, 295);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.RightToLeft = RightToLeft.No;
            materialLabel6.Size = new Size(342, 17);
            materialLabel6.TabIndex = 30;
            materialLabel6.Text = "Caixas especificos";
            materialLabel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textCaixas
            // 
            textCaixas.Enabled = false;
            textCaixas.Location = new Point(19, 317);
            textCaixas.Name = "textCaixas";
            textCaixas.Size = new Size(250, 23);
            textCaixas.TabIndex = 29;
            textCaixas.TextAlign = HorizontalAlignment.Center;
            // 
            // materialLabel5
            // 
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel5.Location = new Point(0, 259);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.RightToLeft = RightToLeft.No;
            materialLabel5.Size = new Size(65, 22);
            materialLabel5.TabIndex = 28;
            materialLabel5.Text = "Ano";
            materialLabel5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel4
            // 
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel4.Location = new Point(-15, 204);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.RightToLeft = RightToLeft.No;
            materialLabel4.Size = new Size(319, 17);
            materialLabel4.TabIndex = 27;
            materialLabel4.Text = "Porta";
            materialLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel3
            // 
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel3.Location = new Point(-15, 154);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.RightToLeft = RightToLeft.No;
            materialLabel3.Size = new Size(321, 17);
            materialLabel3.TabIndex = 26;
            materialLabel3.Text = "Ip";
            materialLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel2
            // 
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel2.Location = new Point(-15, 108);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.RightToLeft = RightToLeft.No;
            materialLabel2.Size = new Size(321, 17);
            materialLabel2.TabIndex = 25;
            materialLabel2.Text = "Senha";
            materialLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCarregarDados
            // 
            btnCarregarDados.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCarregarDados.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCarregarDados.Depth = 0;
            btnCarregarDados.HighEmphasis = true;
            btnCarregarDados.Icon = null;
            btnCarregarDados.Location = new Point(87, 410);
            btnCarregarDados.Margin = new Padding(4, 6, 4, 6);
            btnCarregarDados.MouseState = MaterialSkin.MouseState.HOVER;
            btnCarregarDados.Name = "btnCarregarDados";
            btnCarregarDados.NoAccentTextColor = Color.Empty;
            btnCarregarDados.Size = new Size(110, 36);
            btnCarregarDados.TabIndex = 23;
            btnCarregarDados.Text = "Gerar XMLS";
            btnCarregarDados.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCarregarDados.UseAccentColor = false;
            btnCarregarDados.UseVisualStyleBackColor = true;
            btnCarregarDados.Click += btnCarregarDados_Click;
            // 
            // textDatabase
            // 
            textDatabase.Location = new Point(336, 359);
            textDatabase.Name = "textDatabase";
            textDatabase.Size = new Size(250, 23);
            textDatabase.TabIndex = 22;
            textDatabase.TextAlign = HorizontalAlignment.Center;
            textDatabase.Visible = false;
            // 
            // textPorta
            // 
            textPorta.Enabled = false;
            textPorta.Location = new Point(19, 222);
            textPorta.Name = "textPorta";
            textPorta.Size = new Size(250, 23);
            textPorta.TabIndex = 21;
            textPorta.Text = "1433";
            textPorta.TextAlign = HorizontalAlignment.Center;
            // 
            // textServidor
            // 
            textServidor.Enabled = false;
            textServidor.Location = new Point(19, 174);
            textServidor.Name = "textServidor";
            textServidor.Size = new Size(250, 23);
            textServidor.TabIndex = 20;
            textServidor.Text = "127.0.0.1";
            textServidor.TextAlign = HorizontalAlignment.Center;
            // 
            // textSenha
            // 
            textSenha.Enabled = false;
            textSenha.Location = new Point(19, 126);
            textSenha.Name = "textSenha";
            textSenha.PasswordChar = '*';
            textSenha.RightToLeft = RightToLeft.No;
            textSenha.Size = new Size(250, 23);
            textSenha.TabIndex = 19;
            textSenha.Text = "call1234";
            textSenha.TextAlign = HorizontalAlignment.Center;
            // 
            // textLogin
            // 
            textLogin.Enabled = false;
            textLogin.Location = new Point(19, 82);
            textLogin.Name = "textLogin";
            textLogin.Size = new Size(250, 23);
            textLogin.TabIndex = 18;
            textLogin.Text = "sa";
            textLogin.TextAlign = HorizontalAlignment.Center;
            // 
            // materialLabel1
            // 
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel1.Location = new Point(72, 64);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.RightToLeft = RightToLeft.No;
            materialLabel1.Size = new Size(144, 21);
            materialLabel1.TabIndex = 36;
            materialLabel1.Text = "Login";
            materialLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // novoDataGridView
            // 
            novoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            novoDataGridView.Columns.AddRange(new DataGridViewColumn[] { nota, serie });
            novoDataGridView.Location = new Point(574, 400);
            novoDataGridView.Name = "novoDataGridView";
            novoDataGridView.RowTemplate.Height = 25;
            novoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            novoDataGridView.Size = new Size(206, 173);
            novoDataGridView.TabIndex = 37;
            // 
            // nota
            // 
            nota.HeaderText = "Nota Faltantes";
            nota.Name = "nota";
            // 
            // serie
            // 
            serie.HeaderText = "Caixa";
            serie.MaxInputLength = 10;
            serie.Name = "serie";
            serie.SortMode = DataGridViewColumnSortMode.NotSortable;
            serie.Width = 60;
            // 
            // lbQtdNotas
            // 
            lbQtdNotas.AutoSize = true;
            lbQtdNotas.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbQtdNotas.ForeColor = Color.Red;
            lbQtdNotas.Location = new Point(406, 400);
            lbQtdNotas.Name = "lbQtdNotas";
            lbQtdNotas.Size = new Size(62, 23);
            lbQtdNotas.TabIndex = 39;
            lbQtdNotas.Text = "Notas";
            lbQtdNotas.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(283, 400);
            label3.Name = "label3";
            label3.Size = new Size(109, 23);
            label3.TabIndex = 38;
            label3.Text = "QTD Notas:";
            // 
            // btnRelXMLPDF
            // 
            btnRelXMLPDF.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelXMLPDF.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelXMLPDF.Depth = 0;
            btnRelXMLPDF.Enabled = false;
            btnRelXMLPDF.HighEmphasis = true;
            btnRelXMLPDF.Icon = null;
            btnRelXMLPDF.Location = new Point(46, 477);
            btnRelXMLPDF.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLPDF.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLPDF.Name = "btnRelXMLPDF";
            btnRelXMLPDF.NoAccentTextColor = Color.Empty;
            btnRelXMLPDF.Size = new Size(64, 36);
            btnRelXMLPDF.TabIndex = 40;
            btnRelXMLPDF.Text = "PDF";
            btnRelXMLPDF.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelXMLPDF.UseAccentColor = false;
            btnRelXMLPDF.UseVisualStyleBackColor = true;
            btnRelXMLPDF.Click += btnRelXMLPDF_Click_1;
            // 
            // lbTotalNfe
            // 
            lbTotalNfe.AutoSize = true;
            lbTotalNfe.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbTotalNfe.ForeColor = Color.Red;
            lbTotalNfe.Location = new Point(405, 433);
            lbTotalNfe.Name = "lbTotalNfe";
            lbTotalNfe.Size = new Size(99, 23);
            lbTotalNfe.TabIndex = 43;
            lbTotalNfe.Text = "Soma NFe";
            lbTotalNfe.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(283, 433);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 42;
            label4.Text = "Total NFe:";
            // 
            // lbTotalNfce
            // 
            lbTotalNfce.AutoSize = true;
            lbTotalNfce.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbTotalNfce.ForeColor = Color.Red;
            lbTotalNfce.Location = new Point(405, 469);
            lbTotalNfce.Name = "lbTotalNfce";
            lbTotalNfce.Size = new Size(111, 23);
            lbTotalNfce.TabIndex = 45;
            lbTotalNfce.Text = "Soma NCFe";
            lbTotalNfce.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(283, 469);
            label5.Name = "label5";
            label5.Size = new Size(111, 23);
            label5.TabIndex = 44;
            label5.Text = "Total NCFe:";
            // 
            // progressBarSalvando
            // 
            progressBarSalvando.Location = new Point(2, 582);
            progressBarSalvando.Name = "progressBarSalvando";
            progressBarSalvando.Size = new Size(784, 17);
            progressBarSalvando.TabIndex = 46;
            // 
            // btnTestarConexao
            // 
            btnTestarConexao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTestarConexao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTestarConexao.Depth = 0;
            btnTestarConexao.HighEmphasis = true;
            btnTestarConexao.Icon = null;
            btnTestarConexao.Location = new Point(405, 537);
            btnTestarConexao.Margin = new Padding(4, 6, 4, 6);
            btnTestarConexao.MouseState = MaterialSkin.MouseState.HOVER;
            btnTestarConexao.Name = "btnTestarConexao";
            btnTestarConexao.NoAccentTextColor = Color.Empty;
            btnTestarConexao.Size = new Size(147, 36);
            btnTestarConexao.TabIndex = 35;
            btnTestarConexao.Text = "TESTAR CONEXÃO";
            btnTestarConexao.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTestarConexao.UseAccentColor = false;
            btnTestarConexao.UseVisualStyleBackColor = true;
            btnTestarConexao.Visible = false;
            btnTestarConexao.Click += btnTestarConexao_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(37, 452);
            label2.Name = "label2";
            label2.Size = new Size(220, 23);
            label2.TabIndex = 47;
            label2.Text = "Relatório XML Baixados";
            // 
            // btnRelXMLEXCEL
            // 
            btnRelXMLEXCEL.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelXMLEXCEL.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelXMLEXCEL.Depth = 0;
            btnRelXMLEXCEL.Enabled = false;
            btnRelXMLEXCEL.HighEmphasis = true;
            btnRelXMLEXCEL.Icon = null;
            btnRelXMLEXCEL.Location = new Point(183, 477);
            btnRelXMLEXCEL.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLEXCEL.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLEXCEL.Name = "btnRelXMLEXCEL";
            btnRelXMLEXCEL.NoAccentTextColor = Color.Empty;
            btnRelXMLEXCEL.Size = new Size(65, 36);
            btnRelXMLEXCEL.TabIndex = 48;
            btnRelXMLEXCEL.Text = "EXCEL";
            btnRelXMLEXCEL.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelXMLEXCEL.UseAccentColor = false;
            btnRelXMLEXCEL.UseVisualStyleBackColor = true;
            btnRelXMLEXCEL.Click += btnRelXMLEXCEL_Click_1;
            // 
            // btnRelFaltntesLEXCEL
            // 
            btnRelFaltntesLEXCEL.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelFaltntesLEXCEL.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelFaltntesLEXCEL.Depth = 0;
            btnRelFaltntesLEXCEL.Enabled = false;
            btnRelFaltntesLEXCEL.HighEmphasis = true;
            btnRelFaltntesLEXCEL.Icon = null;
            btnRelFaltntesLEXCEL.Location = new Point(183, 538);
            btnRelFaltntesLEXCEL.Margin = new Padding(4, 6, 4, 6);
            btnRelFaltntesLEXCEL.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelFaltntesLEXCEL.Name = "btnRelFaltntesLEXCEL";
            btnRelFaltntesLEXCEL.NoAccentTextColor = Color.Empty;
            btnRelFaltntesLEXCEL.Size = new Size(65, 36);
            btnRelFaltntesLEXCEL.TabIndex = 51;
            btnRelFaltntesLEXCEL.Text = "EXCEL";
            btnRelFaltntesLEXCEL.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelFaltntesLEXCEL.UseAccentColor = false;
            btnRelFaltntesLEXCEL.UseVisualStyleBackColor = true;
            btnRelFaltntesLEXCEL.Click += btnRelFaltntesLEXCEL_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(28, 513);
            label6.Name = "label6";
            label6.Size = new Size(236, 23);
            label6.TabIndex = 50;
            label6.Text = "Relatório Notas Faltantes";
            // 
            // btnRelFaltntesLPDF
            // 
            btnRelFaltntesLPDF.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelFaltntesLPDF.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelFaltntesLPDF.Depth = 0;
            btnRelFaltntesLPDF.Enabled = false;
            btnRelFaltntesLPDF.HighEmphasis = true;
            btnRelFaltntesLPDF.Icon = null;
            btnRelFaltntesLPDF.Location = new Point(46, 538);
            btnRelFaltntesLPDF.Margin = new Padding(4, 6, 4, 6);
            btnRelFaltntesLPDF.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelFaltntesLPDF.Name = "btnRelFaltntesLPDF";
            btnRelFaltntesLPDF.NoAccentTextColor = Color.Empty;
            btnRelFaltntesLPDF.Size = new Size(64, 36);
            btnRelFaltntesLPDF.TabIndex = 49;
            btnRelFaltntesLPDF.Text = "PDF";
            btnRelFaltntesLPDF.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelFaltntesLPDF.UseAccentColor = false;
            btnRelFaltntesLPDF.UseVisualStyleBackColor = true;
            btnRelFaltntesLPDF.Click += btnRelFaltntesLPDF_Click;
            // 
            // textAno
            // 
            textAno.Location = new Point(59, 258);
            textAno.Name = "textAno";
            textAno.Size = new Size(59, 23);
            textAno.TabIndex = 52;
            textAno.Text = "2024";
            textAno.TextAlign = HorizontalAlignment.Center;
            // 
            // textMes
            // 
            textMes.Location = new Point(203, 258);
            textMes.Name = "textMes";
            textMes.Size = new Size(66, 23);
            textMes.TabIndex = 54;
            textMes.Text = "08";
            textMes.TextAlign = HorizontalAlignment.Center;
            // 
            // materialLabel7
            // 
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel7.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel7.Location = new Point(137, 259);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.RightToLeft = RightToLeft.No;
            materialLabel7.Size = new Size(60, 22);
            materialLabel7.TabIndex = 53;
            materialLabel7.Text = "Mês";
            materialLabel7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(0, 64);
            button1.Name = "button1";
            button1.Size = new Size(14, 11);
            button1.TabIndex = 55;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // materialLabel8
            // 
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel8.Location = new Point(35, 348);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.RightToLeft = RightToLeft.No;
            materialLabel8.Size = new Size(60, 17);
            materialLabel8.TabIndex = 56;
            materialLabel8.Text = "Início";
            materialLabel8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textDataIni
            // 
            textDataIni.Location = new Point(19, 367);
            textDataIni.Name = "textDataIni";
            textDataIni.Size = new Size(100, 23);
            textDataIni.TabIndex = 57;
            textDataIni.ValidatingType = typeof(DateTime);
            // 
            // textDataFim
            // 
            textDataFim.Location = new Point(169, 367);
            textDataFim.Name = "textDataFim";
            textDataFim.Size = new Size(100, 23);
            textDataFim.TabIndex = 58;
            textDataFim.ValidatingType = typeof(DateTime);
            // 
            // materialLabel9
            // 
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel9.Location = new Point(188, 348);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.RightToLeft = RightToLeft.No;
            materialLabel9.Size = new Size(60, 17);
            materialLabel9.TabIndex = 59;
            materialLabel9.Text = "Fim";
            materialLabel9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEnviarEmail
            // 
            btnEnviarEmail.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnviarEmail.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEnviarEmail.Depth = 0;
            btnEnviarEmail.Enabled = false;
            btnEnviarEmail.HighEmphasis = true;
            btnEnviarEmail.Icon = null;
            btnEnviarEmail.Location = new Point(635, 359);
            btnEnviarEmail.Margin = new Padding(4, 6, 4, 6);
            btnEnviarEmail.MouseState = MaterialSkin.MouseState.HOVER;
            btnEnviarEmail.Name = "btnEnviarEmail";
            btnEnviarEmail.NoAccentTextColor = Color.Empty;
            btnEnviarEmail.Size = new Size(152, 36);
            btnEnviarEmail.TabIndex = 60;
            btnEnviarEmail.Text = "Enviar por EMAIL";
            btnEnviarEmail.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEnviarEmail.UseAccentColor = false;
            btnEnviarEmail.UseVisualStyleBackColor = true;
            btnEnviarEmail.Click += btnEnviarEmail_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(789, 601);
            Controls.Add(btnEnviarEmail);
            Controls.Add(materialLabel9);
            Controls.Add(textDataFim);
            Controls.Add(textDataIni);
            Controls.Add(materialLabel8);
            Controls.Add(button1);
            Controls.Add(textMes);
            Controls.Add(materialLabel7);
            Controls.Add(textAno);
            Controls.Add(btnRelFaltntesLEXCEL);
            Controls.Add(label6);
            Controls.Add(btnRelFaltntesLPDF);
            Controls.Add(btnRelXMLEXCEL);
            Controls.Add(label2);
            Controls.Add(progressBarSalvando);
            Controls.Add(lbTotalNfce);
            Controls.Add(label5);
            Controls.Add(lbTotalNfe);
            Controls.Add(label4);
            Controls.Add(btnRelXMLPDF);
            Controls.Add(lbQtdNotas);
            Controls.Add(label3);
            Controls.Add(novoDataGridView);
            Controls.Add(btnTestarConexao);
            Controls.Add(lblResultado);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(materialCheckbox1);
            Controls.Add(materialLabel6);
            Controls.Add(textCaixas);
            Controls.Add(materialLabel5);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(btnCarregarDados);
            Controls.Add(textDatabase);
            Controls.Add(textPorta);
            Controls.Add(textServidor);
            Controls.Add(textSenha);
            Controls.Add(textLogin);
            Controls.Add(materialLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Extrair XML - SUPORTE AUTOCOM3 - Versão: 1.0";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)novoDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResultado;
        private Label label1;
        private DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private TextBox textCaixas;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton btnCarregarDados;
        private TextBox textDatabase;
        private TextBox textPorta;
        private TextBox textServidor;
        private TextBox textSenha;
        private TextBox textLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private DataGridView novoDataGridView;
        private Label lbQtdNotas;
        private Label label3;
        private MaterialSkin.Controls.MaterialButton btnRelXMLPDF;
        private Label lbTotalNfe;
        private Label label4;
        private Label lbTotalNfce;
        private Label label5;
        private ProgressBar progressBarSalvando;
        private MaterialSkin.Controls.MaterialButton btnTestarConexao;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton btnRelXMLEXCEL;
        private MaterialSkin.Controls.MaterialButton btnRelFaltntesLEXCEL;
        private Label label6;
        private MaterialSkin.Controls.MaterialButton btnRelFaltntesLPDF;
        private DataGridViewTextBoxColumn Chave;
        private DataGridViewTextBoxColumn Caixa;
       // private TextBox textAno;
        //private TextBox textMes;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private Button button1;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaskedTextBox textDataIni;
        private MaskedTextBox textDataFim;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialButton btnEnviarEmail;
        private DataGridViewTextBoxColumn nota;
        private DataGridViewTextBoxColumn serie;
    }
}