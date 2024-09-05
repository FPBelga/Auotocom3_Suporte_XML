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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            label1 = new Label();
            materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            textCaixas = new TextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
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
            num_caixa = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            NotaFaltante = new DataGridViewTextBoxColumn();
            CaixaFaltante = new DataGridViewTextBoxColumn();
            progressBarSalvando = new ProgressBar();
            labelTotalNotas = new Label();
            label10 = new Label();
            btnCarregarDados = new MaterialSkin.Controls.MaterialButton();
            checkedListBoxNota = new CheckedListBox();
            btnRelXMLPDF2 = new MaterialSkin.Controls.MaterialButton();
            NFCE = new MaterialSkin.Controls.MaterialCheckbox();
            NFE = new MaterialSkin.Controls.MaterialCheckbox();
            NFCE2 = new MaterialSkin.Controls.MaterialCheckbox();
            NFE2 = new MaterialSkin.Controls.MaterialCheckbox();
            label9 = new Label();
            btnRelXMLEXCEL2 = new MaterialSkin.Controls.MaterialButton();
            btnCarregaScantech = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            textBanco = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(439, 551);
            label1.Name = "label1";
            label1.Size = new Size(110, 23);
            label1.TabIndex = 33;
            label1.Text = "Valor Total:";
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.Depth = 0;
            materialCheckbox1.Location = new Point(63, 313);
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
            materialLabel6.Location = new Point(-15, 327);
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
            textCaixas.Location = new Point(19, 348);
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
            materialLabel5.Location = new Point(0, 296);
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
            lbQtdNotas.Location = new Point(559, 447);
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
            label3.Location = new Point(436, 447);
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
            btnRelXMLPDF.Location = new Point(64, 453);
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
            lbTotalNfe.Location = new Point(558, 480);
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
            label4.Location = new Point(436, 480);
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
            lbTotalNfce.Location = new Point(558, 516);
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
            label5.Location = new Point(436, 516);
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
            btnTestarConexao.Location = new Point(275, 541);
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
            textAno.Location = new Point(59, 295);
            textAno.Name = "textAno";
            textAno.Size = new Size(59, 23);
            textAno.TabIndex = 1;
            textAno.Text = "2024";
            textAno.TextAlign = HorizontalAlignment.Center;
            // 
            // textMes
            // 
            textMes.Location = new Point(203, 295);
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
            materialLabel7.Location = new Point(137, 296);
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
            materialLabel8.Location = new Point(41, 372);
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
            textDataIni.Location = new Point(28, 391);
            textDataIni.Name = "textDataIni";
            textDataIni.Size = new Size(90, 23);
            textDataIni.TabIndex = 5;
            textDataIni.TextAlign = HorizontalAlignment.Center;
            textDataIni.ValidatingType = typeof(DateTime);
            // 
            // textDataFim
            // 
            textDataFim.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textDataFim.Location = new Point(168, 391);
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
            materialLabel9.Location = new Point(176, 372);
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
            btnEnviarEmail.Location = new Point(275, 443);
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
            label7.Location = new Point(32, 416);
            label7.Name = "label7";
            label7.Size = new Size(63, 12);
            label7.TabIndex = 60;
            label7.Text = "dd/MM/yyyy";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(173, 416);
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
            lblResultado.Location = new Point(565, 550);
            lblResultado.MouseState = MaterialSkin.MouseState.HOVER;
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(43, 19);
            lblResultado.TabIndex = 62;
            lblResultado.Text = "Soma";
            lblResultado.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.SelectionBackColor = Color.Indigo;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Chave, num_caixa });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(280, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.Purple;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(657, 286);
            dataGridView1.TabIndex = 32;
            // 
            // Chave
            // 
            Chave.DataPropertyName = "chavenfe";
            Chave.HeaderText = "Chave";
            Chave.Name = "Chave";
            Chave.Width = 300;
            // 
            // num_caixa
            // 
            num_caixa.DataPropertyName = "num_caixa";
            num_caixa.HeaderText = "Caixa";
            num_caixa.Name = "num_caixa";
            num_caixa.Width = 60;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { NotaFaltante, CaixaFaltante });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView2.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView2.Location = new Point(675, 359);
            dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.Indigo;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = Color.Indigo;
            dataGridView2.Size = new Size(262, 218);
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
            progressBarSalvando.Location = new Point(-151, 580);
            progressBarSalvando.Name = "progressBarSalvando";
            progressBarSalvando.Size = new Size(1088, 18);
            progressBarSalvando.TabIndex = 65;
            // 
            // labelTotalNotas
            // 
            labelTotalNotas.AutoSize = true;
            labelTotalNotas.Location = new Point(583, 359);
            labelTotalNotas.Name = "labelTotalNotas";
            labelTotalNotas.Size = new Size(38, 15);
            labelTotalNotas.TabIndex = 66;
            labelTotalNotas.Text = "label9";
            labelTotalNotas.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 562);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 69;
            label10.Text = "00:00:00";
            // 
            // btnCarregarDados
            // 
            btnCarregarDados.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCarregarDados.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCarregarDados.Depth = 0;
            btnCarregarDados.HighEmphasis = true;
            btnCarregarDados.Icon = null;
            btnCarregarDados.Location = new Point(275, 495);
            btnCarregarDados.Margin = new Padding(4, 6, 4, 6);
            btnCarregarDados.MouseState = MaterialSkin.MouseState.HOVER;
            btnCarregarDados.Name = "btnCarregarDados";
            btnCarregarDados.NoAccentTextColor = Color.Empty;
            btnCarregarDados.Size = new Size(130, 36);
            btnCarregarDados.TabIndex = 72;
            btnCarregarDados.Text = "Carregar XML";
            btnCarregarDados.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCarregarDados.UseAccentColor = false;
            btnCarregarDados.UseVisualStyleBackColor = true;
            btnCarregarDados.Click += btnCarregarDados_Click;
            // 
            // checkedListBoxNota
            // 
            checkedListBoxNota.BorderStyle = BorderStyle.None;
            checkedListBoxNota.CheckOnClick = true;
            checkedListBoxNota.FormattingEnabled = true;
            checkedListBoxNota.ImeMode = ImeMode.NoControl;
            checkedListBoxNota.Items.AddRange(new object[] { "NFCE", "NFE" });
            checkedListBoxNota.Location = new Point(280, 380);
            checkedListBoxNota.Name = "checkedListBoxNota";
            checkedListBoxNota.Size = new Size(142, 54);
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
            btnRelXMLPDF2.Location = new Point(64, 453);
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
            // NFCE
            // 
            NFCE.AutoSize = true;
            NFCE.Depth = 0;
            NFCE.Location = new Point(0, 0);
            NFCE.Margin = new Padding(0);
            NFCE.MouseLocation = new Point(-1, -1);
            NFCE.MouseState = MaterialSkin.MouseState.HOVER;
            NFCE.Name = "NFCE";
            NFCE.ReadOnly = false;
            NFCE.Ripple = true;
            NFCE.Size = new Size(10, 10);
            NFCE.TabIndex = 0;
            NFCE.Text = "NFCE";
            NFCE.UseVisualStyleBackColor = true;
            // 
            // NFE
            // 
            NFE.AutoSize = true;
            NFE.Depth = 0;
            NFE.Location = new Point(0, 0);
            NFE.Margin = new Padding(0);
            NFE.MouseLocation = new Point(-1, -1);
            NFE.MouseState = MaterialSkin.MouseState.HOVER;
            NFE.Name = "NFE";
            NFE.ReadOnly = false;
            NFE.Ripple = true;
            NFE.Size = new Size(10, 10);
            NFE.TabIndex = 0;
            NFE.Text = "NFE";
            NFE.UseVisualStyleBackColor = true;
            // 
            // NFCE2
            // 
            NFCE2.AutoSize = true;
            NFCE2.Checked = true;
            NFCE2.CheckState = CheckState.Checked;
            NFCE2.Depth = 0;
            NFCE2.Location = new Point(0, 0);
            NFCE2.Margin = new Padding(0);
            NFCE2.MouseLocation = new Point(-1, -1);
            NFCE2.MouseState = MaterialSkin.MouseState.HOVER;
            NFCE2.Name = "NFCE2";
            NFCE2.ReadOnly = false;
            NFCE2.Ripple = true;
            NFCE2.Size = new Size(10, 10);
            NFCE2.TabIndex = 0;
            NFCE2.Text = "materialCheckbox2";
            NFCE2.UseVisualStyleBackColor = true;
            // 
            // NFE2
            // 
            NFE2.AutoSize = true;
            NFE2.Checked = true;
            NFE2.CheckState = CheckState.Checked;
            NFE2.Depth = 0;
            NFE2.Location = new Point(0, 0);
            NFE2.Margin = new Padding(0);
            NFE2.MouseLocation = new Point(-1, -1);
            NFE2.MouseState = MaterialSkin.MouseState.HOVER;
            NFE2.Name = "NFE2";
            NFE2.ReadOnly = false;
            NFE2.Ripple = true;
            NFE2.Size = new Size(10, 10);
            NFE2.TabIndex = 0;
            NFE2.Text = "NFE";
            NFE2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Black", 5F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(280, 355);
            label9.Name = "label9";
            label9.Size = new Size(103, 10);
            label9.TabIndex = 75;
            label9.Text = "Selecione o tipo dos XML";
            // 
            // btnRelXMLEXCEL2
            // 
            btnRelXMLEXCEL2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRelXMLEXCEL2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRelXMLEXCEL2.Depth = 0;
            btnRelXMLEXCEL2.Enabled = false;
            btnRelXMLEXCEL2.HighEmphasis = true;
            btnRelXMLEXCEL2.Icon = null;
            btnRelXMLEXCEL2.Location = new Point(176, 453);
            btnRelXMLEXCEL2.Margin = new Padding(4, 6, 4, 6);
            btnRelXMLEXCEL2.MouseState = MaterialSkin.MouseState.HOVER;
            btnRelXMLEXCEL2.Name = "btnRelXMLEXCEL2";
            btnRelXMLEXCEL2.NoAccentTextColor = Color.Empty;
            btnRelXMLEXCEL2.Size = new Size(65, 36);
            btnRelXMLEXCEL2.TabIndex = 76;
            btnRelXMLEXCEL2.Text = "EXCEL";
            btnRelXMLEXCEL2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRelXMLEXCEL2.UseAccentColor = false;
            btnRelXMLEXCEL2.UseVisualStyleBackColor = true;
            btnRelXMLEXCEL2.Click += btnRelXMLEXCEL2_Click;
            // 
            // btnCarregaScantech
            // 
            btnCarregaScantech.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCarregaScantech.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCarregaScantech.Depth = 0;
            btnCarregaScantech.HighEmphasis = true;
            btnCarregaScantech.Icon = null;
            btnCarregaScantech.Location = new Point(439, 388);
            btnCarregaScantech.Margin = new Padding(4, 6, 4, 6);
            btnCarregaScantech.MouseState = MaterialSkin.MouseState.HOVER;
            btnCarregaScantech.Name = "btnCarregaScantech";
            btnCarregaScantech.NoAccentTextColor = Color.Empty;
            btnCarregaScantech.Size = new Size(98, 36);
            btnCarregaScantech.TabIndex = 77;
            btnCarregaScantech.Text = "SCANTECH";
            btnCarregaScantech.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCarregaScantech.UseAccentColor = false;
            btnCarregaScantech.UseVisualStyleBackColor = true;
            btnCarregaScantech.Visible = false;
            btnCarregaScantech.Click += btnCarregaScantech_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.Enabled = false;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(540, 388);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(129, 36);
            materialButton2.TabIndex = 78;
            materialButton2.Text = "PDF SCANTECH";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Visible = false;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialLabel10
            // 
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel10.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            materialLabel10.Location = new Point(6, 248);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.RightToLeft = RightToLeft.No;
            materialLabel10.Size = new Size(270, 17);
            materialLabel10.TabIndex = 80;
            materialLabel10.Text = "Banco";
            materialLabel10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBanco
            // 
            textBanco.Enabled = false;
            textBanco.Location = new Point(19, 266);
            textBanco.Name = "textBanco";
            textBanco.Size = new Size(250, 23);
            textBanco.TabIndex = 79;
            textBanco.Text = "Autocom3_Filial_Movimento_Mensal";
            textBanco.TextAlign = HorizontalAlignment.Center;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(940, 601);
            Controls.Add(materialLabel10);
            Controls.Add(textBanco);
            Controls.Add(materialButton2);
            Controls.Add(btnCarregaScantech);
            Controls.Add(btnRelXMLEXCEL2);
            Controls.Add(label9);
            Controls.Add(btnRelXMLPDF2);
            Controls.Add(checkedListBoxNota);
            Controls.Add(btnCarregarDados);
            Controls.Add(label10);
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
            Text = "Extrair XML - SUPORTE AUTOCOM3 - Versão: 1.3";
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
        private Label label10;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxNFCE;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxNFE;
        private MaterialSkin.Controls.MaterialButton btnCarregarDados;
        private CheckedListBox checkedListBoxNota;
        private MaterialSkin.Controls.MaterialButton btnRelXMLPDF2;
        private MaterialSkin.Controls.MaterialCheckbox NFCE;
        private MaterialSkin.Controls.MaterialCheckbox NFE;
        private MaterialSkin.Controls.MaterialCheckbox NFCE2;
        private MaterialSkin.Controls.MaterialCheckbox NFE2;
        private Label label9;
        private DataGridViewTextBoxColumn Chave;
        private DataGridViewTextBoxColumn num_caixa;
        private MaterialSkin.Controls.MaterialButton btnRelXMLEXCEL2;
        private MaterialSkin.Controls.MaterialButton btnCarregaScantech;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private TextBox textBanco;
    }
}