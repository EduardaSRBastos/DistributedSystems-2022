using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Net.Client;

namespace Cliente_gestão
{
    static class Program
    {
        public static AdicionarEspetaculo adicionarEspetaculo;
        public static AdicionarSessao adicionarSessao;
        public static AdicionarTeatro adicionarTeatro;
        public static AlterarEspetaculo alterarEspetaculo;
        public static AlterarTeatro alterarTeatro;
        public static ListaGestor listaGestor;
        public static AdicionarBilhetes adicionarBilhetes;
        public static IP_Start iP_Start;
        public static User.UserClient client;


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

            iP_Start = new IP_Start();

            Application.Run(iP_Start);
        }
    }
}
