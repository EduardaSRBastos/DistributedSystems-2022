using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_administração
{
    public partial class IP_Start : Form
    {
        public IP_Start()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtIp.Text == "")
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "O Ip nao pode estar vazio";
                return;
            }
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("https://" + txtIp.Text + ":5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            Program.client = new User.UserClient(channel);
            try
            {
                Program.listaGestor = new ListaAdministrador();
                Program.iP_Start.Hide();
                Program.listaGestor.Show();
            }catch (Exception)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "O servidor não respondeu";
                return;
            }
        }
    }
}
