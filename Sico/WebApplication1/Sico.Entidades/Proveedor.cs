using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Entidades
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreRazonSocial { get; set; }
        public string Cuit { get; set; }
        public DateTime FechaDeInscripcion { get; set; }
        public string CondicionAntiAfip { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string CodigoPostal { get; set; }
        public int idUsuario { get; set; }
        public string Factura { get; set; }
    }
}
