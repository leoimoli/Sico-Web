using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Clases_Maestras
{
    public class ValoresConstantes
    {
        public static string[] Perfiles
        {
            get
            {
                return new string[] { "ADMINISTRADOR", "OPERADOR" };
            }
        }
        public static string[] Sexo
        {
            get
            {
                return new string[] { "MASCULINO", "FEMENINO" };
            }
        }

        public static string[] TipoDePago
        {
            get
            {
                return new string[] { "SELECCIONE", "EFECTIVO", "CHEQUE" };
            }
        }
        public static string[] CondicionAntiAfip
        {
            get
            {
                return new string[] { "Seleccione", "Monotributo", "Responsable inscripto", "Exento", "Consumidor final" };
            }
        }

        public static string[] Meses
        {
            get
            {
                return new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            }
        }

        public static string[] Años
        {
            get
            {
                return new string[] { "Seleccione", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"};
            }
        }

        public static string[] TipoFactura
        {
            get
            {
                return new string[] { "Factura A", "Factura B", "Factura C", "Cuenta Corriente" };
            }
        }

        public static string[] Tribunal
        {
            get
            {
                return new string[] { "Tribunal de trabajo N°1", "Tribunal de trabajo N°2", "Tribunal de trabajo N°3", "Tribunal de trabajo N°4", "Tribunal de trabajo N°5" };
            }
        }
        public static string[] EstadosPericia
        {
            get
            {
                return new string[] { "Iniciada", "Presentada", "Presentada firme", "Concluida" };
            }
        }

        public static string[] TipoDocumento
        {
            get
            {
                return new string[] { "Cuit", "Dni" };
            }
        }

        public static string[] Transacción
        {
            get
            {
                return new string[] { "Seleccione", "Compras", "Ventas" };
            }
        }
    }
}
