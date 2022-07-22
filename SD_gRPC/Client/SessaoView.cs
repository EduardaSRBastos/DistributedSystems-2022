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
    public partial class SessaoView : Form
    {
        public SessaoView(sessao sessao)
        {
            InitializeComponent();
            labelData.Text = sessao.Data;
            labelHoraFim.Text = sessao.HoraFim;
            labelHoraInicio.Text = sessao.HoraInicio;
            labelLugarDisponivel.Text = sessao.LugarDisponivel.ToString();
            labelLugarTotal.Text = sessao.LugarTotal.ToString();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Program.sessaoView.Hide();
        }
    }
}
