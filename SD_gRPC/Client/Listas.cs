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

namespace Client
{
    public partial class Listas : Form
    {
        public TeatroList teatros, teatrosSearch;
        public EspetaculoList espetaculos, espetaculosSearch;
        public SessaoList sessoes, sessoesSearch;
        public Listas()
        {
            InitializeComponent();
            btnComprar.Enabled = false;
            var user = Program.client.GetUserInfo(new UserLookupModel { UserName = Controller.username });
            txtTotal.Text = user.ContaVirtual.ToString();
            teatros = Program.client.RetrieveAllTeatros(new Empty());
            teatrosSearch = new TeatroList();
            espetaculosSearch = new EspetaculoList();
            sessoesSearch = new SessaoList();
            SessoesPick.Checked = false;
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Localizacao + " - " + c.Nome);
                teatrosSearch.Items.Add(c);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        { 
            if (Program.teatrosView != null)
                Program.teatrosView.Hide();
            if (Program.espetaculoView != null)
                Program.espetaculoView.Hide();
            if (Program.sessaoView != null)
                Program.sessaoView.Hide();
            Program.inicial = new Inicial();
            Program.inicial.Show();
            Program.listas.Hide();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
           var reply = Program.client.ComprarBilhete(new ComprarBilheteModel { 
                Quantidade = Int32.Parse(numeroBilhetes.Text), 
                SessaoId = sessoes.Items[lstSessoes.SelectedIndex].Id, 
                Username = Controller.username 
            });
            if (reply.IsOk)
                label3.ForeColor = System.Drawing.Color.Green;
            else
                label3.ForeColor = System.Drawing.Color.DarkRed;
            label3.Text = reply.Result;
            txtTotal.Text = Program.client.GetUserInfo(new UserLookupModel { UserName = Controller.username }).ContaVirtual.ToString();
            if (reply.IsOk)
            {
                Program.recibo = new Recibo(reply);
                Program.recibo.Show();
            }
        }

        private void lstTeatros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTeatros.SelectedIndex < 0)
                return;
            if (EspetaculoSearch.Text != "")
            {
                EspetaculoSearch.Text = "";
                return;
            }
            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            btnComprar.Enabled = false;
            EspetaculoSearch.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            espetaculosSearch.Items.Clear();
            sessoesSearch.Items.Clear();
            SessoesPick.Checked = false;
            if (Program.teatrosView != null)
                Program.teatrosView.Hide();
            if (Program.espetaculoView != null)
                Program.espetaculoView.Hide();
            if (Program.sessaoView != null)
                Program.sessaoView.Hide();
            Program.teatrosView = new TeatrosView(teatrosSearch.Items[lstTeatros.SelectedIndex]);
            Program.teatrosView.Show();
            espetaculos = Program.client.RetrieveAllEspetaculos(new Empty());
            foreach (var c in espetaculos.Items)
            {
                if (c.Teatros.Id == teatrosSearch.Items[lstTeatros.SelectedIndex].Id)
                {
                    lstEspetaculos.Items.Add(c.Nome);
                    espetaculosSearch.Items.Add(c);
                }
            }
        }

        private void lstEspetaculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEspetaculos.SelectedIndex < 0)
                return;
            lstSessoes.Items.Clear();
            btnComprar.Enabled = false;
            textBox2.Text = "";
            SessoesPick.Enabled = true;
            sessoesSearch.Items.Clear();
            SessoesPick.Checked = false;
            textBox1.Text = espetaculosSearch.Items[lstEspetaculos.SelectedIndex].Preco.ToString() + "€";
            sessoes = Program.client.RetrieveFutureSessao(new Empty());
            if (Program.espetaculoView != null)
                Program.espetaculoView.Hide();
            if (Program.sessaoView != null)
                Program.sessaoView.Hide();
            Program.espetaculoView = new EspetaculoView(espetaculosSearch.Items[lstEspetaculos.SelectedIndex]);
            Program.espetaculoView.Show();
            foreach (var c in sessoes.Items)
            {
                if (c.Espetaculos.Id == espetaculosSearch.Items[lstEspetaculos.SelectedIndex].Id)
                {
                    lstSessoes.Items.Add(c.Data + ' ' + c.HoraInicio);
                    sessoesSearch.Items.Add(c);
                }
            }
        }

        private void lstSessoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstSessoes.SelectedIndex < 0)
            {
                btnComprar.Enabled = false; 
                return;
            }
            if (Program.sessaoView != null)
                Program.sessaoView.Hide();
            Program.sessaoView = new SessaoView(sessoesSearch.Items[lstSessoes.SelectedIndex]);
            Program.sessaoView.Show();
            var quantidade = Program.client.QuantidadeBilhetes(new SessaoLookupModel { SessaoId = sessoesSearch.Items[lstSessoes.SelectedIndex].Id });
            textBox2.Text = quantidade.QuantidadeBilh.ToString();
            if (lstSessoes.SelectedIndex >= 0 && Int32.Parse(numeroBilhetes.Text) > 0)
                btnComprar.Enabled = true; 
        }

        private void SessoesPick_ValueChanged(object sender, EventArgs e)
        {
            btnComprar.Enabled = false;
            lstSessoes.Items.Clear();
            sessoesSearch.Items.Clear();
            if (!SessoesPick.Checked)
            {
                foreach(var c in sessoes.Items)
                {
                    if (c.Espetaculos.Id == espetaculosSearch.Items[lstEspetaculos.SelectedIndex].Id)
                    {
                        lstSessoes.Items.Add(c.Data + ' ' + c.HoraInicio);
                        sessoesSearch.Items.Add(c);
                    }
                }
                return;
            }
            foreach( var c in sessoes.Items)
            {
                if(SessoesPick.Value.Date == DateTime.ParseExact(c.Data, "dd-MM-yyyy", CultureInfo.InvariantCulture) &&
                    c.Espetaculos.Id == espetaculosSearch.Items[lstEspetaculos.SelectedIndex].Id)
                {
                    lstSessoes.Items.Add(c.Data + ' ' + c.HoraInicio);
                    sessoesSearch.Items.Add(c);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnComprar.Enabled = false;
            EspetaculoSearch.Enabled = false;
            SessoesPick.Enabled = false;
            TeatrosSearch.Enabled = false;
            EspetaculoSearch.Text = "";
            TeatrosSearch.Text = "";
            TeatrosSearch.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            if (Program.teatrosView != null)
                Program.teatrosView.Hide();
            if (Program.espetaculoView != null)
                Program.espetaculoView.Hide();
            if (Program.sessaoView != null)
                Program.sessaoView.Hide();


            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            lstTeatros.Items.Clear();
            teatros = Program.client.RetrieveAllTeatros(new Empty());
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Localizacao + " - " + c.Nome);
                teatrosSearch.Items.Add(c);
            }
        }

        private void numeroBilhetes_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lstSessoes.SelectedIndex >= 0 && Int32.Parse(numeroBilhetes.Text) > 0)
                btnComprar.Enabled = true;
            else
                btnComprar.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            EspetaculoSearch.Text = "";
            EspetaculoSearch.Enabled = false;
            SessoesPick.Enabled = false;
            btnComprar.Enabled = false;
            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            lstTeatros.Items.Clear();
            teatrosSearch.Items.Clear();
            SessoesPick.Checked = false;
            if (TeatrosSearch.Text == "")
                foreach (var c in teatros.Items)
                {
                    teatrosSearch.Items.Add(c);
                    lstTeatros.Items.Add(c.Localizacao + " - " + c.Nome);
                }
            else
            {
                foreach (var c in teatros.Items)
                {
                    if (c.Nome.Contains(TeatrosSearch.Text))
                    {
                        lstTeatros.Items.Add(c.Localizacao + " - " + c.Nome);
                        teatrosSearch.Items.Add(c);
                    }
                    else if (c.Localizacao.Contains(TeatrosSearch.Text))
                    {
                        lstTeatros.Items.Add(c.Localizacao + " - " + c.Nome);
                        teatrosSearch.Items.Add(c);
                    }
                }
            }
        }

        private void EspetaculoSearch_TextChanged(object sender, EventArgs e)
        {
            lstSessoes.Items.Clear();
            lstEspetaculos.Items.Clear();
            SessoesPick.Enabled = false;
            btnComprar.Enabled = false;
            espetaculosSearch.Items.Clear();
            SessoesPick.Checked = false;
            if (EspetaculoSearch.Text == "")
            {
                foreach (var c in espetaculos.Items)
                {
                    if (c.Teatros.Id == teatrosSearch.Items[lstTeatros.SelectedIndex].Id)
                    {
                        lstEspetaculos.Items.Add(c.Nome);
                        espetaculosSearch.Items.Add(c);
                    }
                }
            }
            else
            {
                foreach(var c in espetaculos.Items)
                {
                    if (c.Nome.Contains(EspetaculoSearch.Text) && c.Teatros.Id == teatrosSearch.Items[lstTeatros.SelectedIndex].Id)
                    {
                        lstEspetaculos.Items.Add(c.Nome);
                        espetaculosSearch.Items.Add(c);
                    }
                }
            }
        }
    }
}
