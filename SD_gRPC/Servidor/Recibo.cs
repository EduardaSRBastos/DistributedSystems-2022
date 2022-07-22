using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Recibo
    {
        public int Id { get; set; }
        public ICollection<Bilhete> Bilhetes { get; set; }
        public int NumeroBilhetes { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public double gasto { get; set; }
    }
}
