using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Entidades
{
    public class Pericias
    {
        public int idPericia { get; set; }
        public string Tribunal { get; set; }
        public DateTime Fecha { get; set; }
        public string NroCausa { get; set; }
        public string Causa { get; set; }
        public string Archivo1 { get; set; }
        public string Archivo2 { get; set; }
        public string Archivo3 { get; set; }
        public int Compartido { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int totalArchivos { get; set; }
        public int TotalEstados { get; set; }
        public string Archivo4 { get; set; }
        public string Archivo5 { get; set; }
        public string Archivo6 { get; set; }
        public string Archivo7 { get; set; }
        public string Archivo8 { get; set; }
        public string Archivo9 { get; set; }
        public string Archivo10 { get; set; }
        public int UsuarioLogin { get; set; }
    }
}
