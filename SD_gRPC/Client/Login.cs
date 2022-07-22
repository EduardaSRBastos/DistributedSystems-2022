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

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
             if (txtUsername.Text == "" || txtPassword.Text == "" || txtIp.Text == "")
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "Username e password e Ip nao podem estar em branco";
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
                var request = new UserLogin
                {
                    Name = txtUsername.Text.ToLower(),
                    Password = txtPassword.Text
                };
                var Reply = Program.client.CheckLogin(request);
                if (Reply.IsOk)
                {
                    Controller.username = txtUsername.Text;
                    Program.inicial = new Inicial();
                    Program.inicial.Show();
                    Program.login.Hide();
                }
                else
                {
                    ErrorLabel.Text = Reply.Result;
                }
            }
            catch (Exception)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "O servidor não respondeu";
                return;
            }
        }

        private void BtnRegistar_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtIp.Text == "")
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "Username e password e Ip nao podem estar em branco";
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
                var rep = Program.client.InsertUser(new UserLogin { Name = txtUsername.Text, Password = txtPassword.Text });
                if (rep.IsOk)
                    ErrorLabel.ForeColor = System.Drawing.Color.Green;
                else
                    ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = rep.Result;
            }
            catch (Exception)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
                ErrorLabel.Text = "O servidor não respondeu";
                return;
            }
        }
    }
}
