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
    public partial class ListaGestor : Form
    {
        public TeatroList teatros;
        public EspetaculoList espetaculos;
        public SessaoList sessoes;
        public BilheteList Bilhetes;
        public ListaGestor()
        {
            InitializeComponent();
            teatros = Program.client.RetrieveAllTeatros(new Empty());
            btnAltTeatro.Enabled = false;
            btnAltEspetaculo.Enabled = false;
            btnRemSessao.Enabled = false;
            btnAddEspetaculo.Enabled = true;
            btnAddSessao.Enabled = true;
            button1.Enabled = false;
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Nome + " - " + c.Localizacao);
            }
        }

        private void btnAltTeatro_Click(object sender, EventArgs e)
        {
            Program.alterarTeatro = new AlterarTeatro(teatros.Items[lstTeatros.SelectedIndex].Id);
            Program.alterarTeatro.Show();
            Program.listaGestor.Hide();
        }

        private void btnAddTeatro_Click(object sender, EventArgs e)
        {
            Program.adicionarTeatro = new AdicionarTeatro();
            Program.adicionarTeatro.Show();
            Program.listaGestor.Hide();
        }

        private void btnAltEspetaculo_Click(object sender, EventArgs e)
        {
            Program.alterarEspetaculo = new AlterarEspetaculo(espetaculos.Items[lstEspetaculos.SelectedIndex].Id);
            Program.alterarEspetaculo.Show();
            Program.listaGestor.Hide();
        }

        private void btnAddEspetaculo_Click(object sender, EventArgs e)
        {
            Program.adicionarEspetaculo = new AdicionarEspetaculo();
            Program.adicionarEspetaculo.Show();
            Program.listaGestor.Hide();
        }

        private void btnRemSessao_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var rep = Program.client.DeleteSessao(new SessaoLookupModel { SessaoId = sessoes.Items[lstSessoes.SelectedIndex].Id });
            if (rep.IsOk)
            {
                label1.ForeColor = System.Drawing.Color.Green;
                sessoes.Items.RemoveAt(lstSessoes.SelectedIndex);
                lstSessoes.Items.RemoveAt(lstSessoes.SelectedIndex);
            }
            else
                label1.ForeColor = System.Drawing.Color.DarkRed;
            label1.Text = rep.Result;
        }

        private void btnAddSessao_Click(object sender, EventArgs e)
        {
            Program.adicionarSessao = new AdicionarSessao();
            Program.adicionarSessao.Show();
            Program.listaGestor.Hide();
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.iP_Start = new IP_Start();
            Program.listaGestor.Hide();
            Program.iP_Start.Show();
        }

        private void lstTeatros_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            lstBilhetes.Items.Clear();
            btnAltEspetaculo.Enabled = false;
            btnRemSessao.Enabled = false;
            button1.Enabled = false;
            var esp = Program.client.RetrieveAllEspetaculos(new Empty());
            espetaculos = new EspetaculoList();
            if (lstTeatros.SelectedIndex < 0)
                return;
            btnAltTeatro.Enabled = true;
            btnAddEspetaculo.Enabled = true;
            foreach (var c in esp.Items)
            {
                if (c.Teatros.Id == teatros.Items[lstTeatros.SelectedIndex].Id)
                {
                    lstEspetaculos.Items.Add(c.Nome);
                    espetaculos.Items.Add(c);
                }
            }
        }

        private void lstEspetaculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSessoes.Items.Clear();
            lstBilhetes.Items.Clear();
            btnRemSessao.Enabled = false;
            button1.Enabled = false;
            var sess = Program.client.RetrieveAllSessao(new Empty());
            sessoes = new SessaoList();
            if (lstEspetaculos.SelectedIndex < 0)
                return;
            btnAltEspetaculo.Enabled = true;
            btnAddSessao.Enabled = true;
            foreach (var c in sess.Items)
            {
                if (c.Espetaculos.Id == espetaculos.Items[lstEspetaculos.SelectedIndex].Id)
                {
                    lstSessoes.Items.Add(c.Data + ' ' + c.HoraInicio);
                    sessoes.Items.Add(c);
                }
            }
        }

        private void lstSessoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBilhetes.Items.Clear();
            var Bilh = Program.client.RetrieveAllBilhetes(new Empty());
            Bilhetes = new BilheteList();
            if (lstSessoes.SelectedIndex < 0)
                return;
            btnRemSessao.Enabled = true;
            button1.Enabled = true;
            foreach ( var c in Bilh.Items)
            {
                if(c.Sessoes.Id == sessoes.Items[lstSessoes.SelectedIndex].Id)
                {
                    lstBilhetes.Items.Add("Bilhete:" + c.Id.ToString());
                    Bilhetes.Items.Add(c);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.adicionarBilhetes = new AdicionarBilhetes(sessoes.Items[lstSessoes.SelectedIndex].Id);
            Program.adicionarBilhetes.Show();
            Program.listaGestor.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstBilhetes.Items.Clear();
            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            lstTeatros.Items.Clear();
            btnAltTeatro.Enabled = false;
            btnAltEspetaculo.Enabled = false;
            btnRemSessao.Enabled = false;


            teatros = Program.client.RetrieveAllTeatros(new Empty());
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Nome + " - " + c.Localizacao);
            }
        }
    }
}
