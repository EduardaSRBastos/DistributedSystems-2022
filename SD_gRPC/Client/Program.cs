using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Net.Client;

namespace Client
{
    static class Program
    {

        public static Login login;
        public static Fundos fundos;
        public static Inicial inicial;
        public static Listas listas;
        public static Recibo recibo;
        public static TeatrosView teatrosView;
        public static EspetaculoView espetaculoView;
        public static SessaoView sessaoView;
        public static User.UserClient client;

        //CONTROLLER
        public static Controller controller;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //channel = GrpcChannel.ForAddress("https://localhost:5001");
            //client = new User.UserClient(channel);

            login = new Login();

            controller = new Controller();
            Application.Run(login);
        }

       
    }
}
