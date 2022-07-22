namespace Client
{
    partial class Listas
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
            this.btnComprar = new System.Windows.Forms.Button();
            this.lstTeatros = new System.Windows.Forms.ListBox();
            this.lstEspetaculos = new System.Windows.Forms.ListBox();
            this.lstSessoes = new System.Windows.Forms.ListBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numeroBilhetes = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TeatrosSearch = new System.Windows.Forms.TextBox();
            this.EspetaculoSearch = new System.Windows.Forms.TextBox();
            this.SessoesPick = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComprar
            // 
            this.btnComprar.Enabled = false;
            this.btnComprar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnComprar.Location = new System.Drawing.Point(585, 346);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(171, 64);
            this.btnComprar.TabIndex = 0;
            this.btnComprar.Text = "Comprar Bilhetes";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // lstTeatros
            // 
            this.lstTeatros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstTeatros.FormattingEnabled = true;
            this.lstTeatros.ItemHeight = 28;
            this.lstTeatros.Location = new System.Drawing.Point(12, 43);
            this.lstTeatros.Name = "lstTeatros";
            this.lstTeatros.Size = new System.Drawing.Size(171, 256);
            this.lstTeatros.TabIndex = 7;
            this.lstTeatros.SelectedIndexChanged += new System.EventHandler(this.lstTeatros_SelectedIndexChanged);
            // 
            // lstEspetaculos
            // 
            this.lstEspetaculos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstEspetaculos.FormattingEnabled = true;
            this.lstEspetaculos.ItemHeight = 28;
            this.lstEspetaculos.Location = new System.Drawing.Point(217, 43);
            this.lstEspetaculos.Name = "lstEspetaculos";
            this.lstEspetaculos.Size = new System.Drawing.Size(171, 256);
            this.lstEspetaculos.TabIndex = 8;
            this.lstEspetaculos.SelectedIndexChanged += new System.EventHandler(this.lstEspetaculos_SelectedIndexChanged);
            // 
            // lstSessoes
            // 
            this.lstSessoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstSessoes.FormattingEnabled = true;
            this.lstSessoes.ItemHeight = 28;
            this.lstSessoes.Location = new System.Drawing.Point(433, 43);
            this.lstSessoes.Name = "lstSessoes";
            this.lstSessoes.Size = new System.Drawing.Size(171, 256);
            this.lstSessoes.TabIndex = 9;
            this.lstSessoes.SelectedIndexChanged += new System.EventHandler(this.lstSessoes_SelectedIndexChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVoltar.Location = new System.Drawing.Point(12, 397);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(127, 41);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(302, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Número de Bilhetes:";
            // 
            // numeroBilhetes
            // 
            this.numeroBilhetes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeroBilhetes.Items.Add("0");
            this.numeroBilhetes.Items.Add("1");
            this.numeroBilhetes.Items.Add("2");
            this.numeroBilhetes.Items.Add("3");
            this.numeroBilhetes.Items.Add("4");
            this.numeroBilhetes.Items.Add("5");
            this.numeroBilhetes.Items.Add("6");
            this.numeroBilhetes.Items.Add("7");
            this.numeroBilhetes.Items.Add("8");
            this.numeroBilhetes.Items.Add("9");
            this.numeroBilhetes.Items.Add("10");
            this.numeroBilhetes.Location = new System.Drawing.Point(458, 344);
            this.numeroBilhetes.Name = "numeroBilhetes";
            this.numeroBilhetes.Size = new System.Drawing.Size(52, 34);
            this.numeroBilhetes.TabIndex = 14;
            this.numeroBilhetes.Text = "0";
            this.numeroBilhetes.SelectedItemChanged += new System.EventHandler(this.numeroBilhetes_SelectedItemChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(302, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fundo Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTotal.Location = new System.Drawing.Point(439, 385);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(71, 34);
            this.txtTotal.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(653, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(94, 27);
            this.textBox1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(667, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 28);
            this.label4.TabIndex = 24;
            this.label4.Text = "Preço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(628, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 28);
            this.label5.TabIndex = 25;
            this.label5.Text = "Qtd de bilhetes";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(653, 146);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(94, 27);
            this.textBox2.TabIndex = 26;
            // 
            // TeatrosSearch
            // 
            this.TeatrosSearch.Location = new System.Drawing.Point(58, 10);
            this.TeatrosSearch.Name = "TeatrosSearch";
            this.TeatrosSearch.Size = new System.Drawing.Size(125, 27);
            this.TeatrosSearch.TabIndex = 27;
            this.TeatrosSearch.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // EspetaculoSearch
            // 
            this.EspetaculoSearch.Enabled = false;
            this.EspetaculoSearch.Location = new System.Drawing.Point(263, 10);
            this.EspetaculoSearch.Name = "EspetaculoSearch";
            this.EspetaculoSearch.Size = new System.Drawing.Size(125, 27);
            this.EspetaculoSearch.TabIndex = 28;
            this.EspetaculoSearch.TextChanged += new System.EventHandler(this.EspetaculoSearch_TextChanged);
            // 
            // SessoesPick
            // 
            this.SessoesPick.Enabled = false;
            this.SessoesPick.Location = new System.Drawing.Point(419, 8);
            this.SessoesPick.Name = "SessoesPick";
            this.SessoesPick.ShowCheckBox = true;
            this.SessoesPick.Size = new System.Drawing.Size(214, 27);
            this.SessoesPick.TabIndex = 29;
            this.SessoesPick.Value = new System.DateTime(2022, 6, 14, 19, 47, 14, 0);
            this.SessoesPick.ValueChanged += new System.EventHandler(this.SessoesPick_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(12, 340);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(127, 41);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refesh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Listas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.SessoesPick);
            this.Controls.Add(this.EspetaculoSearch);
            this.Controls.Add(this.TeatrosSearch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.numeroBilhetes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstSessoes);
            this.Controls.Add(this.lstEspetaculos);
            this.Controls.Add(this.lstTeatros);
            this.Controls.Add(this.btnComprar);
            this.Name = "Listas";
            this.Text = "Listas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.ListBox lstTeatros;
        private System.Windows.Forms.ListBox lstEspetaculos;
        private System.Windows.Forms.ListBox lstSessoes;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown numeroBilhetes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox TeatrosSearch;
        private System.Windows.Forms.TextBox EspetaculoSearch;
        private System.Windows.Forms.DateTimePicker SessoesPick;
        private System.Windows.Forms.Button btnRefresh;
    }
}