using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Cliente
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<Bilhete> Bilhetes { get; set; }
        public double contaVirtual { get; set; }
    }
}
