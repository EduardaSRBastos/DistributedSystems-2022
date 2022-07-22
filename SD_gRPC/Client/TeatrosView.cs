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
    public partial class TeatrosView : Form
    {
        public TeatrosView(teatro Teatro)
        {
            InitializeComponent();
            labelLocalizacao.Text = Teatro.Localizacao;
            labelMorada.Text = Teatro.Morada;
            labelNome.Text = Teatro.Nome;
            labelTelefone.Text = Teatro.Telefone.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Program.teatrosView.Hide();
        }
    }
}
