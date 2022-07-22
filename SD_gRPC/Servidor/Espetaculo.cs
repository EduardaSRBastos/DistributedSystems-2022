using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Espetaculo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sinopse { get; set; }
        public int TeatroId { get; set; }
        public Teatro teatros { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public double preco { get; set; }
    }
}
