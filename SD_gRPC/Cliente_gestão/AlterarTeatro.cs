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
    public partial class AlterarTeatro : Form
    {
        public int TeatroId;
        public AlterarTeatro(int Teatroid)
        {
            InitializeComponent();
            TeatroId = Teatroid;
            var rec = Program.client.GetTeatroInfo(new TeatroLookupModel { TeatroId = TeatroId });
            txtNome.Enabled = true;
            txtLocalizacao.Enabled = true;
            txtMorada.Enabled = true;
            txtTelefone.Enabled = true;
            txtNome.Text = rec.Nome;
            txtLocalizacao.Text = rec.Localizacao;
            txtMorada.Text = rec.Morada;
            txtTelefone.Text = rec.Telefone.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.listaGestor = new ListaGestor();
            Program.listaGestor.Show();
            Program.alterarTeatro.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtLocalizacao.Text == "" || txtMorada.Text == "" || txtNome.Text == "" || txtTelefone.Text == "")
            {
                label5.ForeColor = System.Drawing.Color.DarkRed;
                label5.Text = "Os campos não podem ser deixados em branco!";
                return;
            }
            if (txtTelefone.Text.Length != 9)
            {
                label5.ForeColor = System.Drawing.Color.DarkRed;
                label5.Text = "Numero tem de ter 9 digitos!";
                return;
            }
            var rep = Program.client.UpdateTeatro(new teatro
            {
                Id = TeatroId,
                Localizacao = txtLocalizacao.Text,
                Morada = txtMorada.Text,
                Nome = txtNome.Text,
                Telefone = Int32.Parse(txtTelefone.Text)
            });
            if (rep.IsOk)
                label6.ForeColor = System.Drawing.Color.Green;
            else
                label6.ForeColor = System.Drawing.Color.DarkRed;
            label6.Text = rep.Result;
        }
    }
}
