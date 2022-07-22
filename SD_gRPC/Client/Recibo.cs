using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Recibo : Form
    {
        public Recibo(recibo rec)
        {
            InitializeComponent();
            labelPreco.Text = rec.Dinheirogasto.ToString();
            labelQuantidade.Text = rec.NumBilhetes.ToString();
            LabelId.Text = rec.Id.ToString();
            labelUtilizador.Text = rec.ClienteId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.recibo.Hide();
            return;
        }
    }
}
