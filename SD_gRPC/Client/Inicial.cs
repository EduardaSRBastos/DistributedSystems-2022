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
    public partial class Inicial : Form
    {
        public BilheteList Bilhetes;
        public Inicial()
        {
            InitializeComponent();
            Bilhetes = new BilheteList();

            var bilhetes = Program.client.GetBilheteUser(new UserLookupModel { UserName = Controller.username });
            foreach(var c in bilhetes.Items)
            {
                var bil = Program.client.GetBilheteInfo(new BilheteLookupModel { BilheteId = c.Id });
                var sessao = Program.client.GetSessaoInfo(new SessaoLookupModel { SessaoId = bil.Sessoes.Id });
                var espetaculo = Program.client.GetEspetaculoInfo(new EspetaculoLookupModel { EspetaculoId = sessao.Espetaculos.Id });
                if (c.Visto)
                    lstEspetaculo.Items.Add(espetaculo.Nome);
                else
                {
                    lstBilhetes.Items.Add(espetaculo.Nome + ' ' + sessao.Data);
                    Bilhetes.Items.Add(c);
                }
                
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Program.login = new Login();
            Program.login.Show();
            Program.inicial.Hide();
        }

        private void btnFundos_Click(object sender, EventArgs e)
        {
            Program.fundos = new Fundos();
            Program.fundos.Show();
            Program.inicial.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Program.listas = new Listas();
            Program.listas.Show();
            Program.inicial.Hide();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            var reply = Program.client.AnularBilhete(new BilheteLookupModel { BilheteId = Bilhetes.Items[lstBilhetes.SelectedIndex].Id });
            Bilhetes.Items.RemoveAt(lstBilhetes.SelectedIndex);
            if (reply.IsOk)
            {
                label1.ForeColor = System.Drawing.Color.Green;
                lstBilhetes.Items.RemoveAt(lstBilhetes.SelectedIndex);
                lstBilhetes.Update();
            }
            else
                label1.ForeColor = System.Drawing.Color.DarkRed;
            label1.Text = reply.Result;
            

        }

        private void lstBilhetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstBilhetes.SelectedIndex < 0)
            {
                btnAnular.Enabled = false;
                btnVisto.Enabled = false;
                return;
            }
            btnAnular.Enabled = true;
            btnVisto.Enabled = true;
        }

        private void btnVisto_Click(object sender, EventArgs e)
        {
            Program.client.VerBilhete(new BilheteLookupModel { BilheteId = Bilhetes.Items[lstBilhetes.SelectedIndex].Id });
            Program.inicial.Hide();
            Program.inicial = new Inicial();
            Program.inicial.Show();
       
        }
    }
}
