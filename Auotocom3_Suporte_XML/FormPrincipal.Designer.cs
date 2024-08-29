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
            label1 = new Label();
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
            lbQtdNotas = new Label();
            label3 = new Label();
            btnRelXMLPDF = new MaterialSkin.Controls.MaterialButton();
            lbTotalNfe = new Label();
            label4 = new Label();
            lbTotalNfce = new Label();
            label5 = new Label();
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
            label7 = new Label();
            label8 = new Label();
            lblResultado = new MaterialSkin.Controls.MaterialLabel();
            dataGridView1 = new DataGridView();
            Chave = new DataGridViewTextBoxColumn();
            caixa = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            NotaFaltante = new DataGridViewTextBoxColumn();
            CaixaFaltante = new DataGridViewTextBoxColumn();
            progressBarSalvando = new ProgressBar();
            labelTotalNotas = new Label();
            btnCarregaDados2 = new MaterialSkin.Controls.MaterialButton();
            label10 = new Label();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            checkedListBoxNota = new CheckedListBox();
            btnRelXMLPDF2 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(591, 551);
            label1.Name = "label1";
            label1.Size = new Size(110, 23);
            label1.TabIndex = 33;
            label1.Text = "Valor Total:";
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
            materialLabel6.TabIndex = 3;
            materialLabel6.Text = "Caixas especificos";
            materialLabel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textCaixas
            // 
            textCaixas.Enabled = false;
            textCaixas.Location = new Point(19, 317);
            textCaixas.Name = "textCaixas";
            textCaixas.Size = new Size(250, 23);
            textCaixas.TabIndex = 4;
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
            btnCarregarDados.Location = new Point(375, 535);
            btnCarregarDados.Margin = new Padding(4, 6, 4, 6);
            btnCarregarDados.MouseState = MaterialSkin.MouseState.HOVER;
            btnCarregarDados.Name = "btnCarregarDados";
            btnCarregarDados.NoAccentTextColor = Color.Empty;
            btnCarregarDados.Size = new Size(101, 36);
            btnCarregarDados.TabIndex = 7;
            btnCarregarDados.Text = "XMLS NCFe";
            btnCarregarDados.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCarregarDados.UseAccentColor = false;
            btnCarregarDados.UseVisualStyleBackColor = true;
            btnCarregarDados.Visible = false;
            btnCarregarDados.Click += btnCarregarDados_Click;
            // 
            // textDatabase
            // 
            textDatabase.Location = new Point(280, 356);
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
            // lbQtdNotas
            // 
            lbQtdNotas.AutoSize = true;
            lbQtdNotas.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbQtdNotas.ForeColor = Color.Red;
            lbQtdNotas.Location = new Point(711, 447);
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
            label3.Location = new Point(588, 447);
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
            btnRelXMLPDF.Location = new Point(63, 453);
            btnRelXMLPDF.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLPDF.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLPDF.Name = "btnRelXMLPDF";
            btnRelXMLPDF.NoAccentTextColor = Color.Empty;
            btnRelXMLPDF.Size = new Size(64, 36);
            btnRelXMLPDF.TabIndex = 8;
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
            lbTotalNfe.Location = new Point(710, 480);
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
            label4.Location = new Point(588, 480);
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
            lbTotalNfce.Location = new Point(710, 516);
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
            label5.Location = new Point(588, 516);
            label5.Name = "label5";
            label5.Size = new Size(111, 23);
            label5.TabIndex = 44;
            label5.Text = "Total NCFe:";
            // 
            // btnTestarConexao
            // 
            btnTestarConexao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTestarConexao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTestarConexao.Depth = 0;
            btnTestarConexao.HighEmphasis = true;
            btnTestarConexao.Icon = null;
            btnTestarConexao.Location = new Point(408, 535);
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
            label2.Font = new Font("Arial Black", 5F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(72, 437);
            label2.Name = "label2";
            label2.Size = new Size(97, 10);
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
            btnRelXMLEXCEL.Location = new Point(176, 453);
            btnRelXMLEXCEL.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLEXCEL.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLEXCEL.Name = "btnRelXMLEXCEL";
            btnRelXMLEXCEL.NoAccentTextColor = Color.Empty;
            btnRelXMLEXCEL.Size = new Size(65, 36);
            btnRelXMLEXCEL.TabIndex = 9;
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
            btnRelFaltntesLEXCEL.Location = new Point(176, 511);
            btnRelFaltntesLEXCEL.Margin = new Padding(4, 6, 4, 6);
            btnRelFaltntesLEXCEL.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelFaltntesLEXCEL.Name = "btnRelFaltntesLEXCEL";
            btnRelFaltntesLEXCEL.NoAccentTextColor = Color.Empty;
            btnRelFaltntesLEXCEL.Size = new Size(65, 36);
            btnRelFaltntesLEXCEL.TabIndex = 11;
            btnRelFaltntesLEXCEL.Text = "EXCEL";
            btnRelFaltntesLEXCEL.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelFaltntesLEXCEL.UseAccentColor = false;
            btnRelFaltntesLEXCEL.UseVisualStyleBackColor = true;
            btnRelFaltntesLEXCEL.Click += btnRelFaltntesLEXCEL_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Black", 5F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(72, 495);
            label6.Name = "label6";
            label6.Size = new Size(104, 10);
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
            btnRelFaltntesLPDF.Location = new Point(63, 511);
            btnRelFaltntesLPDF.Margin = new Padding(4, 6, 4, 6);
            btnRelFaltntesLPDF.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelFaltntesLPDF.Name = "btnRelFaltntesLPDF";
            btnRelFaltntesLPDF.NoAccentTextColor = Color.Empty;
            btnRelFaltntesLPDF.Size = new Size(64, 36);
            btnRelFaltntesLPDF.TabIndex = 10;
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
            textAno.TabIndex = 1;
            textAno.Text = "2024";
            textAno.TextAlign = HorizontalAlignment.Center;
            // 
            // textMes
            // 
            textMes.Location = new Point(203, 258);
            textMes.Name = "textMes";
            textMes.Size = new Size(66, 23);
            textMes.TabIndex = 2;
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
            materialLabel8.Location = new Point(41, 348);
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
            textDataIni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textDataIni.Location = new Point(28, 367);
            textDataIni.Name = "textDataIni";
            textDataIni.Size = new Size(90, 23);
            textDataIni.TabIndex = 5;
            textDataIni.TextAlign = HorizontalAlignment.Center;
            textDataIni.ValidatingType = typeof(DateTime);
            // 
            // textDataFim
            // 
            textDataFim.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textDataFim.Location = new Point(168, 367);
            textDataFim.Name = "textDataFim";
            textDataFim.Size = new Size(89, 23);
            textDataFim.TabIndex = 6;
            textDataFim.TextAlign = HorizontalAlignment.Center;
            textDataFim.ValidatingType = typeof(DateTime);
            // 
            // materialLabel9
            // 
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel9.Location = new Point(176, 348);
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
            btnEnviarEmail.Location = new Point(625, 359);
            btnEnviarEmail.Margin = new Padding(4, 6, 4, 6);
            btnEnviarEmail.MouseState = MaterialSkin.MouseState.HOVER;
            btnEnviarEmail.Name = "btnEnviarEmail";
            btnEnviarEmail.NoAccentTextColor = Color.Empty;
            btnEnviarEmail.Size = new Size(152, 36);
            btnEnviarEmail.TabIndex = 12;
            btnEnviarEmail.Text = "Enviar por EMAIL";
            btnEnviarEmail.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEnviarEmail.UseAccentColor = false;
            btnEnviarEmail.UseVisualStyleBackColor = true;
            btnEnviarEmail.Click += btnEnviarEmail_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(32, 392);
            label7.Name = "label7";
            label7.Size = new Size(63, 12);
            label7.TabIndex = 60;
            label7.Text = "dd/MM/yyyy";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(173, 392);
            label8.Name = "label8";
            label8.Size = new Size(63, 12);
            label8.TabIndex = 61;
            label8.Text = "dd/MM/yyyy";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.BackColor = Color.Red;
            lblResultado.Depth = 0;
            lblResultado.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblResultado.Location = new Point(717, 550);
            lblResultado.MouseState = MaterialSkin.MouseState.HOVER;
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(43, 19);
            lblResultado.TabIndex = 62;
            lblResultado.Text = "Soma";
            lblResultado.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Chave, caixa });
            dataGridView1.Location = new Point(280, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(981, 286);
            dataGridView1.TabIndex = 32;
            // 
            // Chave
            // 
            Chave.DataPropertyName = "chavenfe";
            Chave.HeaderText = "Chave";
            Chave.Name = "Chave";
            Chave.Width = 300;
            // 
            // caixa
            // 
            caixa.DataPropertyName = "caixa";
            caixa.HeaderText = "Caixa";
            caixa.Name = "caixa";
            caixa.Width = 60;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { NotaFaltante, CaixaFaltante });
            dataGridView2.Location = new Point(843, 356);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(418, 218);
            dataGridView2.TabIndex = 64;
            // 
            // NotaFaltante
            // 
            NotaFaltante.DataPropertyName = "i";
            NotaFaltante.HeaderText = "Notas Faltantes";
            NotaFaltante.Name = "NotaFaltante";
            // 
            // CaixaFaltante
            // 
            CaixaFaltante.DataPropertyName = "caixaAtual";
            CaixaFaltante.HeaderText = "Caixa";
            CaixaFaltante.Name = "CaixaFaltante";
            // 
            // progressBarSalvando
            // 
            progressBarSalvando.ForeColor = Color.Purple;
            progressBarSalvando.Location = new Point(1, 580);
            progressBarSalvando.Name = "progressBarSalvando";
            progressBarSalvando.Size = new Size(1260, 18);
            progressBarSalvando.TabIndex = 65;
            // 
            // labelTotalNotas
            // 
            labelTotalNotas.AutoSize = true;
            labelTotalNotas.Location = new Point(536, 359);
            labelTotalNotas.Name = "labelTotalNotas";
            labelTotalNotas.Size = new Size(38, 15);
            labelTotalNotas.TabIndex = 66;
            labelTotalNotas.Text = "label9";
            labelTotalNotas.Visible = false;
            // 
            // btnCarregaDados2
            // 
            btnCarregaDados2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCarregaDados2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCarregaDados2.Depth = 0;
            btnCarregaDados2.HighEmphasis = true;
            btnCarregaDados2.Icon = null;
            btnCarregaDados2.Location = new Point(394, 535);
            btnCarregaDados2.Margin = new Padding(4, 6, 4, 6);
            btnCarregaDados2.MouseState = MaterialSkin.MouseState.HOVER;
            btnCarregaDados2.Name = "btnCarregaDados2";
            btnCarregaDados2.NoAccentTextColor = Color.Empty;
            btnCarregaDados2.Size = new Size(91, 36);
            btnCarregaDados2.TabIndex = 67;
            btnCarregaDados2.Text = "XMLS NFe";
            btnCarregaDados2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCarregaDados2.UseAccentColor = false;
            btnCarregaDados2.UseVisualStyleBackColor = true;
            btnCarregaDados2.Visible = false;
            btnCarregaDados2.Click += btnCarregaDados2_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(280, 550);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 69;
            label10.Text = "00:00:00";
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(625, 402);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(130, 36);
            materialButton1.TabIndex = 72;
            materialButton1.Text = "Carregar XML";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // checkedListBoxNota
            // 
            checkedListBoxNota.FormattingEnabled = true;
            checkedListBoxNota.Items.AddRange(new object[] { "NFCE", "NFE" });
            checkedListBoxNota.Location = new Point(280, 394);
            checkedListBoxNota.Name = "checkedListBoxNota";
            checkedListBoxNota.Size = new Size(142, 76);
            checkedListBoxNota.TabIndex = 73;
            checkedListBoxNota.ItemCheck += checkedListBoxNota_ItemCheck;
            // 
            // btnRelXMLPDF2
            // 
            btnRelXMLPDF2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelXMLPDF2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelXMLPDF2.Depth = 0;
            btnRelXMLPDF2.Enabled = false;
            btnRelXMLPDF2.HighEmphasis = true;
            btnRelXMLPDF2.Icon = null;
            btnRelXMLPDF2.Location = new Point(54, 453);
            btnRelXMLPDF2.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLPDF2.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLPDF2.Name = "btnRelXMLPDF2";
            btnRelXMLPDF2.NoAccentTextColor = Color.Empty;
            btnRelXMLPDF2.Size = new Size(64, 36);
            btnRelXMLPDF2.TabIndex = 74;
            btnRelXMLPDF2.Text = "PDF";
            btnRelXMLPDF2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelXMLPDF2.UseAccentColor = false;
            btnRelXMLPDF2.UseVisualStyleBackColor = true;
            btnRelXMLPDF2.Click += btnRelXMLPDF2_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1267, 601);
            Controls.Add(btnRelXMLPDF2);
            Controls.Add(checkedListBoxNota);
            Controls.Add(materialButton1);
            Controls.Add(label10);
            Controls.Add(btnCarregaDados2);
            Controls.Add(labelTotalNotas);
            Controls.Add(progressBarSalvando);
            Controls.Add(dataGridView2);
            Controls.Add(lblResultado);
            Controls.Add(label8);
            Controls.Add(label7);
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
            Controls.Add(lbTotalNfce);
            Controls.Add(label5);
            Controls.Add(lbTotalNfe);
            Controls.Add(label4);
            Controls.Add(btnRelXMLPDF);
            Controls.Add(lbQtdNotas);
            Controls.Add(label3);
            Controls.Add(btnTestarConexao);
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
            MaximizeBox = false;
            Name = "FormPrincipal";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Extrair XML - SUPORTE AUTOCOM3 - Versão: 1.1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private Label label1;
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
        private Label lbQtdNotas;
        private Label label3;
        private MaterialSkin.Controls.MaterialButton btnRelXMLPDF;
        private Label lbTotalNfe;
        private Label label4;
        private Label lbTotalNfce;
        private Label label5;
        private MaterialSkin.Controls.MaterialButton btnTestarConexao;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton btnRelXMLEXCEL;
        private MaterialSkin.Controls.MaterialButton btnRelFaltntesLEXCEL;
        private Label label6;
        private MaterialSkin.Controls.MaterialButton btnRelFaltntesLPDF;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private Button button1;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaskedTextBox textDataIni;
        private MaskedTextBox textDataFim;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialButton btnEnviarEmail;

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o som do "beep"
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private Label label7;
        private Label label8;
        private MaterialSkin.Controls.MaterialLabel lblResultado;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn NotaFaltante;
        private DataGridViewTextBoxColumn CaixaFaltante;
        private ProgressBar progressBarSalvando;
        private Label labelTotalNotas;
        private MaterialSkin.Controls.MaterialButton btnCarregaDados2;
        private Label label10;
        private DataGridViewTextBoxColumn Chave;
        private DataGridViewTextBoxColumn caixa;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxNFCE;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxNFE;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private CheckedListBox checkedListBoxNota;
        private MaterialSkin.Controls.MaterialButton btnRelXMLPDF2;
    }
}