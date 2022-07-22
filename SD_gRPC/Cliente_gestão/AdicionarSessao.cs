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
    public partial class AdicionarSessao : Form
    {
        public EspetaculoList espetaculos;
        public AdicionarSessao()
        {
            InitializeComponent();
            espetaculos = Program.client.RetrieveAllEspetaculos(new Empty());
            foreach (var c in espetaculos.Items)
                cbEspetaculo.Items.Add(c.Nome);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            if(txtDisponivel.Text == "" || txtTotal.Text == "" || cbEspetaculo.SelectedIndex < 0)
            {
                label2.ForeColor = System.Drawing.Color.DarkRed;
                label2.Text = "Valores não podem ser deixados em branco";
                return;
            }
            if (Int32.Parse(txtDisponivel.Text) > Int32.Parse(txtTotal.Text))
            {
                label2.ForeColor = System.Drawing.Color.DarkRed;
                label2.Text = "Lugares disponiveis tem de ser mais baixo que lugares totais";
                return;
            }

            var Espetaculo = Program.client.GetEspetaculoInfo(new EspetaculoLookupModel { 
                EspetaculoId = espetaculos.Items[cbEspetaculo.SelectedIndex].Id 
            });
            if(data.Value.Date < DateTime.ParseExact(Espetaculo.DataInicio, "dd-MM-yyyy", CultureInfo.InvariantCulture).Date ||
                data.Value.Date > DateTime.ParseExact(Espetaculo.DataFim, "dd-MM-yyyy", CultureInfo.InvariantCulture).Date)
            {
                label2.ForeColor = System.Drawing.Color.DarkRed;
                label2.Text = "Data fora dos limites";
                return;
            }

            var esp = new Addsessao();
            esp.Espetaculos = new espetaculo();
            esp.Espetaculos.Id = espetaculos.Items[cbEspetaculo.SelectedIndex].Id;
            esp.Data = data.Value.ToString("dd-MM-yyyy");
            esp.HoraInicio = horaInicio.Value.ToString("HH:mm");
            esp.HoraFim = horaFim.Value.ToString("HH:mm");
            esp.LugarTotal = Int32.Parse(txtTotal.Text);
            esp.LugarDisponivel = Int32.Parse(txtDisponivel.Text);

            var rep = Program.client.InsertSessao(esp);
            if (rep.IsOk)
                label8.ForeColor = System.Drawing.Color.Green;
            else
                label8.ForeColor = System.Drawing.Color.DarkRed;
            label8.Text = rep.Result;
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.listaGestor = new ListaGestor();
            Program.listaGestor.Show();
            Program.adicionarSessao.Hide();
        }
    }
}
