using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Entidades
{
    public class Periodo
    {
        public int idPeriodo { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Ano { get; set; }
        public string NombrePeriodo { get; set; }
    }
}
