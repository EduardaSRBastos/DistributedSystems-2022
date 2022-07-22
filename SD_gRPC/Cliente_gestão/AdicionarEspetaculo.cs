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
    public partial class AdicionarEspetaculo : Form
    {
        public TeatroList Teatros;
        public AdicionarEspetaculo()
        {
            InitializeComponent();
            Teatros = Program.client.RetrieveAllTeatros(new Empty());
            foreach (var c in Teatros.Items)
            {
                cbTeatro.Items.Add(c.Localizacao);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.listaGestor = new ListaGestor();
            Program.listaGestor.Show();
            Program.adicionarEspetaculo.Hide();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtPreco.Text == "" || txtSinopse.Text == "" || cbTeatro.SelectedIndex < 0)
            {
                label7.ForeColor = System.Drawing.Color.DarkRed;
                label7.Text = "Valores nao podem ser deixados em branco!";
                return;
            }
            var preco = double.Parse(txtPreco.Text);
            if (preco < 0)
            {
                label7.ForeColor = System.Drawing.Color.DarkRed;
                label7.Text = "O preço tem de ser um valor maior que 0!";
                return;
            }
            var esp = new Addespetaculo();
            esp.Teatros = new teatro();
            esp.Teatros.Id = Teatros.Items[cbTeatro.SelectedIndex].Id;
            esp.DataFim = dataFim.Value.ToString("dd-MM-yyyy");
            esp.DataInicio = dataInicio.Value.ToString("dd-MM-yyyy");
            esp.Nome = txtNome.Text;
            esp.Preco = preco;
            esp.Sinopse = txtSinopse.Text;

            var rep = Program.client.InsertEspetaculo(esp);
            if (rep.IsOk)
                label8.ForeColor = System.Drawing.Color.Green;
            else
                label8.ForeColor = System.Drawing.Color.DarkRed;
            label8.Text = rep.Result;
        }
    }
}
