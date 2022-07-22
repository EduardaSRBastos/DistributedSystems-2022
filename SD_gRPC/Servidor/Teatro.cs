using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Teatro
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string localizacao { get; set; }
        public string morada { get; set; }
        public int telefone { get; set; }
    }
}
