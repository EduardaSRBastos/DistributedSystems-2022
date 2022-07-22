using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_gestão
{
    public partial class AlterarEspetaculo : Form
    {
        public int EspetaculoId;
        public TeatroList Teatros;
        public AlterarEspetaculo(int Espetaculoid)
        {
            InitializeComponent();
            EspetaculoId = Espetaculoid;
            var rec = Program.client.GetEspetaculoInfo(new EspetaculoLookupModel { EspetaculoId = EspetaculoId });
            txtNome.Text = rec.Nome;
            txtSinopse.Text = rec.Sinopse;
            Teatros = Program.client.RetrieveAllTeatros(new Empty());
            int index = 0;
            foreach(var c in Teatros.Items)
            {
                cbTeatro.Items.Add(c.Localizacao);
                if (rec.Teatros.Id == c.Id)
                    cbTeatro.SelectedIndex = index;
                index++;
            }
            dataInicio.Value = DateTime.ParseExact(rec.DataInicio, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dataFim.Value = DateTime.ParseExact(rec.DataFim, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            txtPreco.Text = rec.Preco.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.listaGestor = new ListaGestor();
            Program.listaGestor.Show();
            Program.alterarEspetaculo.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "" || txtPreco.Text == "" || txtSinopse.Text == "" || cbTeatro.SelectedIndex < 0)
            {
                label7.ForeColor = System.Drawing.Color.DarkRed;
                label7.Text = "O campos não podem ser deixados em branco!";
                return;
            }
            var preco = double.Parse(txtPreco.Text);
            if (preco < 0)
            {
                label7.ForeColor = System.Drawing.Color.DarkRed;
                label7.Text = "O preço tem de ser um valor maior que 0";
                return;
            }

                
            var esp = new espetaculo();
            esp.Teatros = new teatro();
            esp.Teatros.Id = Teatros.Items[cbTeatro.SelectedIndex].Id;
            esp.DataFim = dataFim.Value.ToString("dd-MM-yyyy");
            esp.DataInicio = dataInicio.Value.ToString("dd-MM-yyyy");
            esp.Id = EspetaculoId;
            esp.Nome = txtNome.Text;
            esp.Preco = preco;
            esp.Sinopse = txtSinopse.Text;

            var rep = Program.client.UpdateEspetaculo(esp);
            if (rep.IsOk)
                label8.ForeColor = System.Drawing.Color.Green;
            else
                label8.ForeColor = System.Drawing.Color.DarkRed;
            label8.Text = rep.Result;
        }
    }
}
