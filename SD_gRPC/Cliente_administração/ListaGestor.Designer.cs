
namespace Cliente_administração
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
            this.lstBilhetes = new System.Windows.Forms.ListBox();
            this.btnRemUser = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.DeleteLabel = new System.Windows.Forms.Label();
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
            // btnRemUser
            // 
            this.btnRemUser.Enabled = false;
            this.btnRemUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemUser.Location = new System.Drawing.Point(816, 258);
            this.btnRemUser.Name = "btnRemUser";
            this.btnRemUser.Size = new System.Drawing.Size(171, 82);
            this.btnRemUser.TabIndex = 25;
            this.btnRemUser.Text = "Remover Utilizador";
            this.btnRemUser.UseVisualStyleBackColor = true;
            this.btnRemUser.Click += new System.EventHandler(this.btnRemUser_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 28;
            this.lstUsers.Location = new System.Drawing.Point(816, 26);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(171, 200);
            this.lstUsers.TabIndex = 24;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // DeleteLabel
            // 
            this.DeleteLabel.AutoSize = true;
            this.DeleteLabel.Location = new System.Drawing.Point(753, 346);
            this.DeleteLabel.Name = "DeleteLabel";
            this.DeleteLabel.Size = new System.Drawing.Size(0, 20);
            this.DeleteLabel.TabIndex = 28;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(152, 421);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 51);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ListaGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 508);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.DeleteLabel);
            this.Controls.Add(this.btnRemUser);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.lstBilhetes);
            this.Controls.Add(this.lstSessoes);
            this.Controls.Add(this.lstEspetaculos);
            this.Controls.Add(this.lstTeatros);
            this.Controls.Add(this.btnVoltar);
            this.Name = "ListaGestor";
            this.Text = "Lista Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSessoes;
        private System.Windows.Forms.ListBox lstEspetaculos;
        private System.Windows.Forms.ListBox lstTeatros;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ListBox lstBilhetes;
        private System.Windows.Forms.Button btnRemUser;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label DeleteLabel;
        private System.Windows.Forms.Button btnRefresh;
    }
}