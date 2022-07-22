
namespace Client
{
    partial class Inicial
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
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnFundos = new System.Windows.Forms.Button();
            this.lstEspetaculo = new System.Windows.Forms.ListBox();
            this.lstBilhetes = new System.Windows.Forms.ListBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVisto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPesquisar.Location = new System.Drawing.Point(550, 147);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(186, 69);
            this.btnPesquisar.TabIndex = 0;
            this.btnPesquisar.Text = "Ver Teatros, Espetáculos e Sessões";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnFundos
            // 
            this.btnFundos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFundos.Location = new System.Drawing.Point(550, 25);
            this.btnFundos.Name = "btnFundos";
            this.btnFundos.Size = new System.Drawing.Size(186, 69);
            this.btnFundos.TabIndex = 2;
            this.btnFundos.Text = "Adicionar Fundos";
            this.btnFundos.UseVisualStyleBackColor = true;
            this.btnFundos.Click += new System.EventHandler(this.btnFundos_Click);
            // 
            // lstEspetaculo
            // 
            this.lstEspetaculo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstEspetaculo.FormattingEnabled = true;
            this.lstEspetaculo.ItemHeight = 28;
            this.lstEspetaculo.Location = new System.Drawing.Point(58, 25);
            this.lstEspetaculo.Name = "lstEspetaculo";
            this.lstEspetaculo.Size = new System.Drawing.Size(201, 312);
            this.lstEspetaculo.TabIndex = 3;
            // 
            // lstBilhetes
            // 
            this.lstBilhetes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstBilhetes.FormattingEnabled = true;
            this.lstBilhetes.ItemHeight = 28;
            this.lstBilhetes.Location = new System.Drawing.Point(307, 25);
            this.lstBilhetes.Name = "lstBilhetes";
            this.lstBilhetes.Size = new System.Drawing.Size(201, 312);
            this.lstBilhetes.TabIndex = 4;
            this.lstBilhetes.SelectedIndexChanged += new System.EventHandler(this.lstBilhetes_SelectedIndexChanged);
            // 
            // btnAnular
            // 
            this.btnAnular.Enabled = false;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnular.Location = new System.Drawing.Point(550, 269);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(186, 69);
            this.btnAnular.TabIndex = 5;
            this.btnAnular.Text = "Anular Bilhete";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVoltar.Location = new System.Drawing.Point(12, 420);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(103, 41);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(44, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 38);
            this.label2.TabIndex = 8;
            this.label2.Text = "Teatros ja Vistos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(285, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 38);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bilhetes comprados";
            // 
            // btnVisto
            // 
            this.btnVisto.Enabled = false;
            this.btnVisto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVisto.Location = new System.Drawing.Point(550, 375);
            this.btnVisto.Name = "btnVisto";
            this.btnVisto.Size = new System.Drawing.Size(186, 69);
            this.btnVisto.TabIndex = 10;
            this.btnVisto.Text = "Marcar como visto";
            this.btnVisto.UseVisualStyleBackColor = true;
            this.btnVisto.Click += new System.EventHandler(this.btnVisto_Click);
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.btnVisto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lstBilhetes);
            this.Controls.Add(this.lstEspetaculo);
            this.Controls.Add(this.btnFundos);
            this.Controls.Add(this.btnPesquisar);
            this.Name = "Inicial";
            this.Text = "Inicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnFundos;
        private System.Windows.Forms.ListBox lstEspetaculo;
        private System.Windows.Forms.ListBox lstBilhetes;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVisto;
    }
}