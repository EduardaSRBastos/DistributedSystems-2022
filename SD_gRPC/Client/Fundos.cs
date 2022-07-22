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
    public partial class Fundos : Form
    {
        public double ToAdd;
        public Fundos()
        {
            InitializeComponent();
            var user = Program.client.GetUserInfo(new UserLookupModel { UserName = Controller.username });
            txtTotal.Text = user.ContaVirtual.ToString();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Program.inicial = new Inicial();
            Program.inicial.Show();
            Program.fundos.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Program.client.AddFundos(new UserFundos { FundosAdicionar = ToAdd, UserName = Controller.username });
            Program.inicial = new Inicial();
            Program.inicial.Show();
            Program.fundos.Hide();
        }

        private void txtMontante_TextChanged(object sender, EventArgs e)
        {
            if (txtMontante.Text == "")
            {
                btnConfirmar.Enabled = false;
                return;
            }
            ToAdd = Convert.ToDouble(txtMontante.Text);
            if (ToAdd > 0)
                btnConfirmar.Enabled = true;
            else
                btnConfirmar.Enabled = false;
        }
    }
}
