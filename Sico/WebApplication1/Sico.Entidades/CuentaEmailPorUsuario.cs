using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Entidades
{
   public class CuentaEmailPorUsuario
    {
        public int IdUsuario { get; set; }
        public string CuentaEmail { get; set; }
        public string ClaveEmail { get; set; }
        public string FirmaEmail { get; set; }
    }
}
