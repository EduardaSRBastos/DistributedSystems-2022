using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Bilhete
    {
        public int id { get; set; }
        public int sessaoId { get; set; }
        public Sessao sessoes { get; set; }
        public bool visto { get; set; }

        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public int? ReciboId { get; set; }
        public Recibo Recibo { get; set; }
    }
}
