using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Client
{
    class Controller
    {
        public readonly User.UserClient client = new User.UserClient(GrpcChannel.ForAddress("https://localhost:5001"));
        public static string username;
    }
}
