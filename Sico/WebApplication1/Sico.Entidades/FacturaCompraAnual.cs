using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Entidades
{
    public class FacturaCompraAnual
    {
        public string Periodo { get; set; }
        public Decimal Monto { get; set; }
        public decimal Total1 { get; set; }
        public decimal Total2 { get; set; }
        public decimal Total3 { get; set; }
        public decimal Neto1 { get; set; }
        public decimal Neto2 { get; set; }
        public decimal Neto3 { get; set; }
        public decimal Iva1 { get; set; }
        public decimal Iva2 { get; set; }
        public decimal Iva3 { get; set; }
        public decimal PercepIngBrutos { get; set; }
        public decimal NoGravado { get; set; }
        public decimal PercepIva { get; set; }
        public int idCliente { get; set; }
    }
}
