namespace Autocom3_Suporte_XML
{
    partial class FormEnviaEmail
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
            btnEnviarEmail = new MaterialSkin.Controls.MaterialButton();
            btnCancelar = new MaterialSkin.Controls.MaterialButton();
            textDestinatario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textRemetente = new TextBox();
            label3 = new Label();
            textSenha = new MaskedTextBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnEnviarEmail
            // 
            btnEnviarEmail.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEnviarEmail.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEnviarEmail.Depth = 0;
            btnEnviarEmail.HighEmphasis = true;
            btnEnviarEmail.Icon = null;
            btnEnviarEmail.Location = new Point(74, 171);
            btnEnviarEmail.Margin = new Padding(4, 6, 4, 6);
            btnEnviarEmail.MouseState = MaterialSkin.MouseState.HOVER;
            btnEnviarEmail.Name = "btnEnviarEmail";
            btnEnviarEmail.NoAccentTextColor = Color.Empty;
            btnEnviarEmail.Size = new Size(120, 36);
            btnEnviarEmail.TabIndex = 0;
            btnEnviarEmail.Text = "Enviar Email";
            btnEnviarEmail.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEnviarEmail.UseAccentColor = false;
            btnEnviarEmail.UseVisualStyleBackColor = true;
            btnEnviarEmail.Click += btnEnviarEmail_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = true;
            btnCancelar.Icon = null;
            btnCancelar.Location = new Point(258, 171);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(96, 36);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // textDestinatario
            // 
            textDestinatario.Location = new Point(90, 49);
            textDestinatario.Name = "textDestinatario";
            textDestinatario.Size = new Size(333, 23);
            textDestinatario.TabIndex = 2;
            
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 53);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Destinatário:";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 91);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 5;
            label2.Text = "Remetente:";
            // 
            // textRemetente
            // 
            textRemetente.Location = new Point(90, 88);
            textRemetente.Name = "textRemetente";
            textRemetente.Size = new Size(132, 23);
            textRemetente.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 131);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Senha:";
            // 
            // textSenha
            // 
            textSenha.Location = new Point(89, 123);
            textSenha.Name = "textSenha";
            textSenha.Size = new Size(133, 23);
            textSenha.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(134, 5);
            label4.Name = "label4";
            label4.Size = new Size(175, 26);
            label4.TabIndex = 9;
            label4.Text = "Dados do Envio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 93);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 10;
            label5.Text = "@autocom3.com.br";
            // 
            // FormEnviaEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 217);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textSenha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textRemetente);
            Controls.Add(label1);
            Controls.Add(textDestinatario);
            Controls.Add(btnCancelar);
            Controls.Add(btnEnviarEmail);
            FormStyle = FormStyles.StatusAndActionBar_None;
            MaximizeBox = false;
            Name = "FormEnviaEmail";
            Padding = new Padding(3, 0, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enviando Email";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnEnviarEmail;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private TextBox textDestinatario;
        private Label label1;
        private Label label2;
        private TextBox textRemetente;
        private Label label3;
        private MaskedTextBox textSenha;
        private Label label4;
        private Label label5;

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o som do "beep"
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}