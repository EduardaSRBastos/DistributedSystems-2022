
namespace Cliente_gestão
{
    partial class ListaGestor
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
            this.lstSessoes = new System.Windows.Forms.ListBox();
            this.lstEspetaculos = new System.Windows.Forms.ListBox();
            this.lstTeatros = new System.Windows.Forms.ListBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAddTeatro = new System.Windows.Forms.Button();
            this.btnAltTeatro = new System.Windows.Forms.Button();
            this.btnAltEspetaculo = new System.Windows.Forms.Button();
            this.btnAddEspetaculo = new System.Windows.Forms.Button();
            this.btnAddSessao = new System.Windows.Forms.Button();
            this.btnRemSessao = new System.Windows.Forms.Button();
            this.lstBilhetes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSessoes
            // 
            this.lstSessoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstSessoes.FormattingEnabled = true;
            this.lstSessoes.ItemHeight = 28;
            this.lstSessoes.Location = new System.Drawing.Point(420, 26);
            this.lstSessoes.Name = "lstSessoes";
            this.lstSessoes.Size = new System.Drawing.Size(171, 200);
            this.lstSessoes.TabIndex = 16;
            this.lstSessoes.SelectedIndexChanged += new System.EventHandler(this.lstSessoes_SelectedIndexChanged);
            // 
            // lstEspetaculos
            // 
            this.lstEspetaculos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstEspetaculos.FormattingEnabled = true;
            this.lstEspetaculos.ItemHeight = 28;
            this.lstEspetaculos.Location = new System.Drawing.Point(224, 26);
            this.lstEspetaculos.Name = "lstEspetaculos";
            this.lstEspetaculos.Size = new System.Drawing.Size(171, 200);
            this.lstEspetaculos.TabIndex = 15;
            this.lstEspetaculos.SelectedIndexChanged += new System.EventHandler(this.lstEspetaculos_SelectedIndexChanged);
            // 
            // lstTeatros
            // 
            this.lstTeatros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstTeatros.FormattingEnabled = true;
            this.lstTeatros.ItemHeight = 28;
            this.lstTeatros.Location = new System.Drawing.Point(28, 26);
            this.lstTeatros.Name = "lstTeatros";
            this.lstTeatros.Size = new System.Drawing.Size(171, 200);
            this.lstTeatros.TabIndex = 14;
            this.lstTeatros.SelectedIndexChanged += new System.EventHandler(this.lstTeatros_SelectedIndexChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVoltar.Location = new System.Drawing.Point(28, 421);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(102, 51);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAddTeatro
            // 
            this.btnAddTeatro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddTeatro.Location = new System.Drawing.Point(28, 302);
            this.btnAddTeatro.Name = "btnAddTeatro";
            this.btnAddTeatro.Size = new System.Drawing.Size(171, 38);
            this.btnAddTeatro.TabIndex = 17;
            this.btnAddTeatro.Text = "Adicionar Teatro";
            this.btnAddTeatro.UseVisualStyleBackColor = true;
            this.btnAddTeatro.Click += new System.EventHandler(this.btnAddTeatro_Click);
            // 
            // btnAltTeatro
            // 
            this.btnAltTeatro.Enabled = false;
            this.btnAltTeatro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAltTeatro.Location = new System.Drawing.Point(28, 258);
            this.btnAltTeatro.Name = "btnAltTeatro";
            this.btnAltTeatro.Size = new System.Drawing.Size(171, 38);
            this.btnAltTeatro.TabIndex = 18;
            this.btnAltTeatro.Text = "Alterar Teatro";
            this.btnAltTeatro.UseVisualStyleBackColor = true;
            this.btnAltTeatro.Click += new System.EventHandler(this.btnAltTeatro_Click);
            // 
            // btnAltEspetaculo
            // 
            this.btnAltEspetaculo.Enabled = false;
            this.btnAltEspetaculo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAltEspetaculo.Location = new System.Drawing.Point(224, 258);
            this.btnAltEspetaculo.Name = "btnAltEspetaculo";
            this.btnAltEspetaculo.Size = new System.Drawing.Size(171, 38);
            this.btnAltEspetaculo.TabIndex = 20;
            this.btnAltEspetaculo.Text = "Alterar Espetáculo";
            this.btnAltEspetaculo.UseVisualStyleBackColor = true;
            this.btnAltEspetaculo.Click += new System.EventHandler(this.btnAltEspetaculo_Click);
            // 
            // btnAddEspetaculo
            // 
            this.btnAddEspetaculo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddEspetaculo.Location = new System.Drawing.Point(224, 302);
            this.btnAddEspetaculo.Name = "btnAddEspetaculo";
            this.btnAddEspetaculo.Size = new System.Drawing.Size(171, 38);
            this.btnAddEspetaculo.TabIndex = 19;
            this.btnAddEspetaculo.Text = "Adicionar Espetáculo";
            this.btnAddEspetaculo.UseVisualStyleBackColor = true;
            this.btnAddEspetaculo.Click += new System.EventHandler(this.btnAddEspetaculo_Click);
            // 
            // btnAddSessao
            // 
            this.btnAddSessao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddSessao.Location = new System.Drawing.Point(420, 302);
            this.btnAddSessao.Name = "btnAddSessao";
            this.btnAddSessao.Size = new System.Drawing.Size(171, 38);
            this.btnAddSessao.TabIndex = 22;
            this.btnAddSessao.Text = "Adicionar Sessão";
            this.btnAddSessao.UseVisualStyleBackColor = true;
            this.btnAddSessao.Click += new System.EventHandler(this.btnAddSessao_Click);
            // 
            // btnRemSessao
            // 
            this.btnRemSessao.Enabled = false;
            this.btnRemSessao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemSessao.Location = new System.Drawing.Point(420, 258);
            this.btnRemSessao.Name = "btnRemSessao";
            this.btnRemSessao.Size = new System.Drawing.Size(171, 38);
            this.btnRemSessao.TabIndex = 21;
            this.btnRemSessao.Text = "Remover Sessão";
            this.btnRemSessao.UseVisualStyleBackColor = true;
            this.btnRemSessao.Click += new System.EventHandler(this.btnRemSessao_Click);
            // 
            // lstBilhetes
            // 
            this.lstBilhetes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstBilhetes.FormattingEnabled = true;
            this.lstBilhetes.ItemHeight = 28;
            this.lstBilhetes.Location = new System.Drawing.Point(617, 26);
            this.lstBilhetes.Name = "lstBilhetes";
            this.lstBilhetes.Size = new System.Drawing.Size(171, 200);
            this.lstBilhetes.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(617, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(617, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 82);
            this.button1.TabIndex = 27;
            this.button1.Text = "Adicionar Bilhetes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(162, 421);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 51);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ListaGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 508);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBilhetes);
            this.Controls.Add(this.btnAddSessao);
            this.Controls.Add(this.btnRemSessao);
            this.Controls.Add(this.btnAltEspetaculo);
            this.Controls.Add(this.btnAddEspetaculo);
            this.Controls.Add(this.btnAltTeatro);
            this.Controls.Add(this.btnAddTeatro);
            this.Controls.Add(this.lstSessoes);
            this.Controls.Add(this.lstEspetaculos);
            this.Controls.Add(this.lstTeatros);
            this.Controls.Add(this.btnVoltar);
            this.Name = "ListaGestor";
            this.Text = "Lista Gestor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSessoes;
        private System.Windows.Forms.ListBox lstEspetaculos;
        private System.Windows.Forms.ListBox lstTeatros;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAddTeatro;
        private System.Windows.Forms.Button btnAltTeatro;
        private System.Windows.Forms.Button btnAltEspetaculo;
        private System.Windows.Forms.Button btnAddEspetaculo;
        private System.Windows.Forms.Button btnAddSessao;
        private System.Windows.Forms.Button btnRemSessao;
        private System.Windows.Forms.ListBox lstBilhetes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
    }
}