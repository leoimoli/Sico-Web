using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sico.Entidades;
using System.Windows.Forms;
using Sico.Dao;

namespace Sico.Negocio
{
    public class ProveedorNeg
    {
        public static bool EditarProvvedor(Proveedor _proveedor)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_proveedor);
                exito = ProveedorDao.EditarProveedor(_proveedor);
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        public static bool GurdarProveedor(Proveedor _proveedor)
        {
            bool exito = false;
            try
            {
                ValidarDatos(_proveedor);
                bool UsuarioExistente = ValidarProveedorExistente(_proveedor.NombreRazonSocial, _proveedor.Cuit);
                if (UsuarioExistente == true)
                {
                    const string message = "Ya existe un proveedor registrado con el Nombre/Razón Social y Cuit ingresado.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                               MessageBoxIcon.Exclamation);
                    throw new Exception();
                }
                else
                {
                    exito = ProveedorDao.InsertProveedor(_proveedor);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        private static bool ValidarProveedorExistente(string nombreRazonSocial, string cuit)
        {
            bool existe = ProveedorDao.ValidarProveedorExistente(nombreRazonSocial, cuit);
            return existe;
        }

        private static void ValidarDatos(Proveedor _proveedor)
        {
            if (String.IsNullOrEmpty(_proveedor.NombreRazonSocial))
            {
                const string message = "El campo Nombre/Razón Social es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_proveedor.Cuit))
            {
                const string message = "El campo Cuit es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_proveedor.Factura))
            {
                const string message = "El campo Actividad es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
            if (String.IsNullOrEmpty(_proveedor.CondicionAntiAfip))
            {
                const string message = "El campo condición AntiAfip es obligatorio.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
            }
        }

        public static List<Proveedor> BuscarProveedorPorCuit(string cuit)
        {
            List<Proveedor> _listaProveedores = new List<Proveedor>();
            try
            {
                _listaProveedores = ProveedorDao.BuscarProveedorPorCuit(cuit);
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
            return _listaProveedores;
        }

        public static List<Proveedor> BuscarProveedorPorNombreRazonSocial(string nombreRazonSocial)
        {
            List<Proveedor> _listaProveedores = new List<Proveedor>();
            try
            {
                _listaProveedores = ProveedorDao.BuscarProveedorPorNombreRazonSocial(nombreRazonSocial);
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
            return _listaProveedores;
        }
    }
}
