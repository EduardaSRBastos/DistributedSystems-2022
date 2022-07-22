
namespace Client
{
    partial class SessaoView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.labelLugarDisponivel = new System.Windows.Forms.Label();
            this.labelLugarTotal = new System.Windows.Forms.Label();
            this.labelHoraFim = new System.Windows.Forms.Label();
            this.labelHoraInicio = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hora Fim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lugar Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lugar Disponivel:";
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(85, 200);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(94, 29);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // labelLugarDisponivel
            // 
            this.labelLugarDisponivel.AutoSize = true;
            this.labelLugarDisponivel.Location = new System.Drawing.Point(160, 157);
            this.labelLugarDisponivel.Name = "labelLugarDisponivel";
            this.labelLugarDisponivel.Size = new System.Drawing.Size(0, 20);
            this.labelLugarDisponivel.TabIndex = 6;
            // 
            // labelLugarTotal
            // 
            this.labelLugarTotal.AutoSize = true;
            this.labelLugarTotal.Location = new System.Drawing.Point(160, 128);
            this.labelLugarTotal.Name = "labelLugarTotal";
            this.labelLugarTotal.Size = new System.Drawing.Size(0, 20);
            this.labelLugarTotal.TabIndex = 7;
            // 
            // labelHoraFim
            // 
            this.labelHoraFim.AutoSize = true;
            this.labelHoraFim.Location = new System.Drawing.Point(160, 95);
            this.labelHoraFim.Name = "labelHoraFim";
            this.labelHoraFim.Size = new System.Drawing.Size(0, 20);
            this.labelHoraFim.TabIndex = 8;
            // 
            // labelHoraInicio
            // 
            this.labelHoraInicio.AutoSize = true;
            this.labelHoraInicio.Location = new System.Drawing.Point(160, 61);
            this.labelHoraInicio.Name = "labelHoraInicio";
            this.labelHoraInicio.Size = new System.Drawing.Size(0, 20);
            this.labelHoraInicio.TabIndex = 9;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(160, 27);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(0, 20);
            this.labelData.TabIndex = 10;
            // 
            // SessaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 257);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelHoraInicio);
            this.Controls.Add(this.labelHoraFim);
            this.Controls.Add(this.labelLugarTotal);
            this.Controls.Add(this.labelLugarDisponivel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SessaoView";
            this.Text = "SessaoView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label labelLugarDisponivel;
        private System.Windows.Forms.Label labelLugarTotal;
        private System.Windows.Forms.Label labelHoraFim;
        private System.Windows.Forms.Label labelHoraInicio;
        private System.Windows.Forms.Label labelData;
    }
}