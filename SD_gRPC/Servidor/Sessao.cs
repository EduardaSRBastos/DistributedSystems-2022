using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor
{
    public class Sessao
    {
        public int id { get; set; }
        public int EspetaculoId { get; set; }
        public Espetaculo espetaculos { get; set; }
        public string data { get; set; }
        public string horaInicio { get; set; }
        public string horaFim { get; set; }
        public int lugarTotal { get; set; }
        public int lugarDisponivel { get; set; }
    }
}
