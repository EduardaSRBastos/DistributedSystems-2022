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
    public partial class EspetaculoView : Form
    {
        public EspetaculoView(espetaculo espetaculo)
        {
            InitializeComponent();
            labelDataFim.Text = espetaculo.DataFim;
            labelDataInicio.Text = espetaculo.DataInicio;
            labelNome.Text = espetaculo.Nome;
            labelPreco.Text = espetaculo.Preco.ToString() + "€";
            labelSinopse.Text = espetaculo.Sinopse;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Program.espetaculoView.Hide();
        }
    }
}
