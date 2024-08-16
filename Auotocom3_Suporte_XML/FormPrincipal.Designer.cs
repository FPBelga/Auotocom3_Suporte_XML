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
            Caixa = new DataGridViewTextBoxColumn();
            Chave = new DataGridViewTextBoxColumn();
            Emissão = new DataGridViewTextBoxColumn();
            label1 = new Label();
            dataGridView1 = new DataGridView();
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
            btnTestarConexao = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.ForeColor = Color.Red;
            lblResultado.Location = new Point(379, 386);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(82, 31);
            lblResultado.TabIndex = 34;
            lblResultado.Text = "Soma";
            // 
            // Caixa
            // 
            Caixa.DataPropertyName = "caixa";
            Caixa.HeaderText = "caixa";
            Caixa.Name = "Caixa";
            Caixa.Width = 60;
            // 
            // Chave
            // 
            Chave.DataPropertyName = "chavenfe";
            Chave.HeaderText = "chavenfe";
            Chave.Name = "Chave";
            Chave.Width = 300;
            // 
            // Emissão
            // 
            Emissão.DataPropertyName = "data";
            Emissão.HeaderText = "data";
            Emissão.Name = "Emissão";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(290, 386);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 33;
            label1.Text = "Total:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Emissão, Chave, Caixa });
            dataGridView1.Location = new Point(283, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(500, 316);
            dataGridView1.TabIndex = 32;
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.Depth = 0;
            materialCheckbox1.Location = new Point(64, 295);
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
            materialLabel6.Location = new Point(-15, 305);
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
            textCaixas.Location = new Point(19, 327);
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
            materialLabel5.Location = new Point(-15, 252);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.RightToLeft = RightToLeft.No;
            materialLabel5.Size = new Size(321, 17);
            materialLabel5.TabIndex = 28;
            materialLabel5.Text = "Nome Banco";
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
            btnCarregarDados.Location = new Point(19, 381);
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
            textDatabase.Location = new Point(19, 270);
            textDatabase.Name = "textDatabase";
            textDatabase.Size = new Size(250, 23);
            textDatabase.TabIndex = 22;
            textDatabase.Text = "Autocom3_Filial_Movimento_Mensal_2024_07";
            textDatabase.TextAlign = HorizontalAlignment.Center;
            // 
            // textPorta
            // 
            textPorta.Location = new Point(19, 222);
            textPorta.Name = "textPorta";
            textPorta.Size = new Size(250, 23);
            textPorta.TabIndex = 21;
            textPorta.Text = "1433";
            textPorta.TextAlign = HorizontalAlignment.Center;
            // 
            // textServidor
            // 
            textServidor.Location = new Point(19, 174);
            textServidor.Name = "textServidor";
            textServidor.Size = new Size(250, 23);
            textServidor.TabIndex = 20;
            textServidor.Text = "127.0.0.1";
            textServidor.TextAlign = HorizontalAlignment.Center;
            // 
            // textSenha
            // 
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
            textLogin.Location = new Point(19, 82);
            textLogin.Name = "textLogin";
            textLogin.Size = new Size(250, 23);
            textLogin.TabIndex = 18;
            textLogin.Text = "sa";
            textLogin.TextAlign = HorizontalAlignment.Center;
            // 
            // btnTestarConexao
            // 
            btnTestarConexao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTestarConexao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTestarConexao.Depth = 0;
            btnTestarConexao.HighEmphasis = true;
            btnTestarConexao.Icon = null;
            btnTestarConexao.Location = new Point(136, 381);
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
            btnTestarConexao.Click += btnTestarConexao_Click;
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
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(789, 638);
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
            Text = "Extrair XML - SUPORTE AUTOCOM3";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResultado;
        private DataGridViewTextBoxColumn Caixa;
        private DataGridViewTextBoxColumn Chave;
        private DataGridViewTextBoxColumn Emissão;
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
        private MaterialSkin.Controls.MaterialButton btnTestarConexao;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}