using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_gestão
{
    public partial class AdicionarBilhetes : Form
    {
        public int SessaoId;
        public AdicionarBilhetes(int Sessaoid)
        {
            InitializeComponent();
            SessaoId = Sessaoid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                label2.ForeColor = System.Drawing.Color.DarkRed;
                label2.Text = "Campos não podem ser deixados em branco";
                return;
            }
            if(Int32.Parse(textBox1.Text) <= 0)
            {
                label2.ForeColor = System.Drawing.Color.DarkRed;
                label2.Text = "Numero tem de ser maior que 0";
                return;
            }
            var rep = Program.client.AdicionarBilhetes(new CriarBilhetes { Quantidade = Int32.Parse(textBox1.Text), 
                SessaoId = SessaoId 
            });
            if(rep.IsOk)
                label2.ForeColor = System.Drawing.Color.Green;
            else
                label2.ForeColor = System.Drawing.Color.DarkRed;
            label2.Text = rep.Result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.listaGestor = new ListaGestor();
            Program.listaGestor.Show();
            Program.adicionarBilhetes.Hide();
        }
    }
}
