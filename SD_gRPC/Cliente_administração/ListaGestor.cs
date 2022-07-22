using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_administração
{
    public partial class ListaGestor : Form
    {
        public TeatroList teatros;
        public EspetaculoList espetaculos;
        public SessaoList sessoes;
        public BilheteList Bilhetes;
        public UserList Clientes;
        public ListaGestor()
        {
            InitializeComponent();
            teatros = Program.client.RetrieveAllTeatros(new Empty());
            btnRemUser.Enabled = false;
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Nome + " - " + c.Localizacao);
            }
            Clientes = Program.client.RetrieveAllUsers(new Empty());
            foreach(var c in Clientes.Items)
            {
                lstUsers.Items.Add(c.Id);
            }
        }


        private void btnRemUser_Click(object sender, EventArgs e)
        {
            var rep = Program.client.DeleteUser(new UserLookupModel { UserName = Clientes.Items[lstUsers.SelectedIndex].Id });
            if (rep.IsOk)
            {
                DeleteLabel.ForeColor = System.Drawing.Color.Green;
                lstUsers.Items.RemoveAt(lstUsers.SelectedIndex);
            }
            else
                DeleteLabel.ForeColor = System.Drawing.Color.DarkRed;
            DeleteLabel.Text = rep.Result;
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
            var esp = Program.client.RetrieveAllEspetaculos(new Empty());
            espetaculos = new EspetaculoList();
            if (lstTeatros.SelectedIndex < 0)
                return;
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
            var sess = Program.client.RetrieveAllSessao(new Empty());
            sessoes = new SessaoList();
            if (lstEspetaculos.SelectedIndex < 0)
                return;
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
            var Bilh = Program.client.RetrieveAllBilhetesBought(new Empty());
            Bilhetes = new BilheteList();
            if (lstSessoes.SelectedIndex < 0)
                return;
            foreach ( var c in Bilh.Items)
            {
                if(c.Sessoes.Id == sessoes.Items[lstSessoes.SelectedIndex].Id)
                {
                    lstBilhetes.Items.Add("Bilhete:" + c.Id.ToString());
                    Bilhetes.Items.Add(c);
                }
            }
            
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex < 0)
                return;
            btnRemUser.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRemUser.Enabled = false;
            lstBilhetes.Items.Clear();
            lstEspetaculos.Items.Clear();
            lstSessoes.Items.Clear();
            lstTeatros.Items.Clear();
            lstUsers.Items.Clear();

            teatros = Program.client.RetrieveAllTeatros(new Empty());
            Clientes = Program.client.RetrieveAllUsers(new Empty());
            foreach (var c in teatros.Items)
            {
                lstTeatros.Items.Add(c.Nome + " - " + c.Localizacao);
            }
            foreach (var c in Clientes.Items)
            {
                lstUsers.Items.Add(c.Id);
            }
        }
    }
}
