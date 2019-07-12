using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sico.Clases_Maestras
{
    class GenerarExcelCiti
    {
        //int contadorFila = 5;
        //Microsoft.Office.Interop.Excel.Application ExApp;
        //ExApp = new Microsoft.Office.Interop.Excel.Application();
        //Microsoft.Office.Interop.Excel._Workbook oWBook;
        //Microsoft.Office.Interop.Excel._Worksheet oSheet;
        //oWBook = ExApp.Workbooks.Open("C:\\Users\\limoli\\Desktop\\Prueba2.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWBook.ActiveSheet;


        //int totalElementos = Lista.Count - 1;
        //int contadorDeLista = 0;
        //foreach (var item in Lista)
        //{
        //    if (item.Fecha != null)
        //    {
        //        //////Fecha
        //        oSheet.Cells[contadorFila, 2] = item.Fecha;
        //        //////Tipo Comprobante
        //        oSheet.Cells[contadorFila, 3] = "006";

        //        string var = item.NroFactura;
        //        var split1 = var.Split('-')[0];
        //        split1 = split1.Trim();
        //        //////Punto de Venta
        //        oSheet.Cells[contadorFila, 4] = split1;

        //        string Factura = item.NroFactura;
        //        var FacturaSegundaParte = var.Split('-')[1];
        //        FacturaSegundaParte = FacturaSegundaParte.Trim();
        //        //////"Número de Comprobante"
        //        oSheet.Cells[contadorFila, 5] = FacturaSegundaParte;
        //        //////"Número de Comprobante Hasta"
        //        oSheet.Cells[contadorFila, 6] = FacturaSegundaParte;
        //        //////""Código de Documento del comprador
        //        oSheet.Cells[contadorFila, 7] = "96";
        //        //////""Número de Identificación del comprador"
        //        oSheet.Cells[contadorFila, 8] = item.Dni;
        //        //////"Apellido y Nombre"
        //        oSheet.Cells[contadorFila, 9] = item.ApellidoNombre;
        //        //////"Importe total de la de la operacion"
        //        oSheet.Cells[contadorFila, 10] = item.Monto;
        //        //////"importe total de concepto que no integran"
        //        oSheet.Cells[contadorFila, 11] = "0";
        //        ////// Percepcion a no categorizados
        //        oSheet.Cells[contadorFila, 12] = "0";
        //        ////// Importe de operaciones exentas.
        //        oSheet.Cells[contadorFila, 13] = "0";
        //        ////// Importe percepciones o pagos a cuenta de impuestos 
        //        oSheet.Cells[contadorFila, 14] = "0";
        //        ////// Importe percepciones ingresos bruto
        //        oSheet.Cells[contadorFila, 15] = "0";
        //        ////// Importe percepciones de impuesto municipales
        //        oSheet.Cells[contadorFila, 16] = "0";
        //        ////// Importe  de impuesto internos
        //        oSheet.Cells[contadorFila, 17] = "0";
        //        ////// Codigo de moneda
        //        oSheet.Cells[contadorFila, 18] = "PES";
        //        ////// Tipo de Cambio
        //        oSheet.Cells[contadorFila, 19] = "1";

        //        int cantidadAlicuotas = 0;
        //        if (item.Neto1 > 0)
        //        {
        //            cantidadAlicuotas = cantidadAlicuotas + 1;
        //        }
        //        if (item.Neto2 > 0)
        //        {
        //            cantidadAlicuotas = cantidadAlicuotas + 1;
        //        }
        //        if (item.Neto3 > 0)
        //        {
        //            cantidadAlicuotas = cantidadAlicuotas + 1;
        //        }
        //        //////Cantida Alicuotas
        //        oSheet.Cells[contadorFila, 20] = cantidadAlicuotas;
        //        //////Código Operación
        //        oSheet.Cells[contadorFila, 21] = "0";
        //        //////Otro Tributo
        //        oSheet.Cells[contadorFila, 22] = "0";
        //        ////// Fecha de vencimiento
        //        oSheet.Cells[contadorFila, 23] = item.Fecha;


        //        decimal Neto = 0;
        //        if (item.Neto1 > 0)
        //        {
        //            Neto = item.Neto1;
        //        }
        //        if (item.Neto2 > 0)
        //        {
        //            Neto = item.Neto2;
        //        }
        //        if (item.Neto3 > 0)
        //        {
        //            Neto = item.Neto3;
        //        }
        //        ////// Importe Neto  gravado
        //        oSheet.Cells[contadorFila, 24] = Neto;


        //        ///// Alicuota de Iva
        //        string CodigoIva = "0";
        //        if (item.Iva1 > 0)
        //        {
        //            CodigoIva = "10,50%";
        //        }
        //        if (item.Iva2 > 0)
        //        {
        //            CodigoIva = "21%";
        //        }
        //        if (item.Iva3 > 0)
        //        {
        //            CodigoIva = "27%";
        //        }
        //        oSheet.Cells[contadorFila, 25] = CodigoIva;


        //        ///// Iva liquidado
        //        decimal Iva = 0;
        //        if (item.Iva1 > 0)
        //        {
        //            Iva = item.Iva1;
        //        }
        //        if (item.Iva2 > 0)
        //        {
        //            Iva = item.Iva2;
        //        }
        //        if (item.Iva3 > 0)
        //        {
        //            Iva = item.Iva3;
        //        }
        //        oSheet.Cells[contadorFila, 26] = CodigoIva;
        //        contadorFila = contadorFila + 1;
        //        contadorDeLista++;
        //    }
        //}
        //ExApp.Visible = false;
        //ExApp.UserControl = true;
        //oWBook.Save();
        //ExApp.ActiveWorkbook.Close(true, oWBook, Type.Missing);
        //ExApp.Quit();
        //ExApp = null;
    }
}
