using Sico.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sico.Entidades;
using System.Windows.Forms;

namespace Sico.Negocio
{
    public class ComprasNeg
    {
        public static List<string> CargarComboTipoComprobante()
        {
            List<string> lista = new List<string>();
            lista = ComprasDao.CargarComboTipoComprobante();
            return lista;
        }

        public static List<string> CargarComboCodigoOperacion()
        {
            List<string> lista = new List<string>();
            lista = ComprasDao.CargarComboCodigoOperacion();
            return lista;
        }

        public static List<string> CargarComboTipoMoneda()
        {
            List<string> lista = new List<string>();
            lista = ComprasDao.CargarComboTipoMoneda();
            return lista;
        }

        public static List<EstadisticaCompra> BuscarComprasEstadisticasPorProveedor(string cuit, string periodo)
        {
            List<EstadisticaCompra> _listaFacturasCompras = new List<EstadisticaCompra>();
            try
            {
                _listaFacturasCompras = ComprasDao.BuscarComprasEstadisticasPorProveedor(cuit, periodo);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturasCompras;
        }

        public static List<EstadisticaCompraTorta> BuscarFacturacionTorta(string cuit, string periodoTorta)
        {
            List<EstadisticaCompraTorta> _listaFacturasSubCliente = new List<EstadisticaCompraTorta>();
            try
            {
                _listaFacturasSubCliente = ComprasDao.BuscarFacturacionTorta(cuit, periodoTorta);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturasSubCliente;
        }

        public static List<FacturaCompraAnual> FacturacionAnualPorPeriodos(string cuit, string año)
        {
            List<FacturaCompraAnual> _listaFacturacionCompraAnual = new List<FacturaCompraAnual>();
            try
            {
                _listaFacturacionCompraAnual = ComprasDao.FacturacionAnualPorPeriodos(cuit, año);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturacionCompraAnual;
        }

        public static List<FacturaCompra> BuscarTodasFacturasDeComprasDelCliente(string cuit)
        {
            List<FacturaCompra> _listaFacturasCompras = new List<FacturaCompra>();
            try
            {
                _listaFacturasCompras = ComprasDao.BuscarTodasFacturasDeComprasDelCliente(cuit);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturasCompras;
        }

        public static List<FacturaCompra> BuscarDetalleFacturaFacturaCompra(string idFactura)
        {
            List<FacturaCompra> _listaFacturasCompras = new List<FacturaCompra>();
            try
            {
                _listaFacturasCompras = ComprasDao.BuscarDetalleFacturaFacturaCompra(idFactura);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturasCompras;
        }

        public static List<FacturaCompra> BuscarDatosProveedor()
        {
            throw new NotImplementedException();
        }

        public static bool GuardarFacturaCompra(FacturaCompra _factura, string cuitCliente)
        {
            bool exito = false;
            try
            {
                ValidarDatosFactura(_factura);
                exito = ComprasDao.GuardarFacturaCompra(_factura, cuitCliente);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        private static void ValidarDatosFactura(FacturaCompra _factura)
        {
            if (String.IsNullOrEmpty(_factura.NroFactura))
            {
                const string message = "El campo Nro.Factura es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_factura.Periodo) || _factura.Periodo == "Seleccione")
            {
                const string message = "El campo Período es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }

        bool FacturaExiste =  ValidarFacturaProveedorYaExistente(_factura);
            if (FacturaExiste == true)
            {
                const string message = "Ya existe una factura con ese mismo Nro asociada al proveedor.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }

        private static bool ValidarFacturaProveedorYaExistente(FacturaCompra _factura)
        {
            bool existe = ComprasDao.ValidarFacturaProveedorYaExistente(_factura);
            return existe;
        }

        public static List<FacturaCompra> BuscarCompraPorProveedor(string apellidoNombre)
        {
            List<FacturaCompra> _listaCompras = new List<FacturaCompra>();
            try
            {
                _listaCompras = ComprasDao.BuscarCompraPorProveedor(apellidoNombre);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaCompras;
        }

        public static List<FacturaCompra> BuscarFacturacionTotal(string cuit, string Periodo)
        {
            List<FacturaCompra> _listaFacturasSubCliente = new List<FacturaCompra>();
            try
            {
                _listaFacturasSubCliente = ComprasDao.BuscarFacturacionTotal(cuit, Periodo);
            }
            catch (Exception ex)
            {
                const string message = "Error en el sistema. Intente nuevamente o comuniquese con el administrador.";
                const string caption = "Atención";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                throw new Exception();
            }
            return _listaFacturasSubCliente;
        }

        public static bool GuardarEdicionFacturaCompras(FacturaCompra _factura, string cuit, string idFactura)
        {
            bool exito = false;
            try
            {
                //ValidarDatosFactura(_subCliente);
                exito = ComprasDao.GuardarEdicionFacturaCompras(_factura, cuit, idFactura);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }
    }
}
