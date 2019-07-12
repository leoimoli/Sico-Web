using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sico.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Sico.Dao
{
    public class ProveedorDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool InsertProveedor(Proveedor _proveedor)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaProveedor";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NombreRazonSocial_in", _proveedor.NombreRazonSocial);
            cmd.Parameters.AddWithValue("Cuit_in", _proveedor.Cuit);
            cmd.Parameters.AddWithValue("Factura_in", _proveedor.Factura);
            cmd.Parameters.AddWithValue("CondicionAntiAfip_in", _proveedor.CondicionAntiAfip);
            cmd.Parameters.AddWithValue("Telefono_in", _proveedor.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _proveedor.Email);
            cmd.Parameters.AddWithValue("Provincia_in", _proveedor.Provincia);
            cmd.Parameters.AddWithValue("Localidad_in", _proveedor.Localidad);
            cmd.Parameters.AddWithValue("Calle_in", _proveedor.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _proveedor.Altura);
            cmd.Parameters.AddWithValue("CodigoPostal_in", _proveedor.CodigoPostal);
            cmd.Parameters.AddWithValue("idUsuario_in", _proveedor.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool EditarProveedor(Proveedor _proveedor)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarProveedor";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NombreRazonSocial_in", _proveedor.NombreRazonSocial);
            cmd.Parameters.AddWithValue("Cuit_in", _proveedor.Cuit);
            cmd.Parameters.AddWithValue("Factura_in", _proveedor.Factura);
            cmd.Parameters.AddWithValue("CondicionAntiAfip_in", _proveedor.CondicionAntiAfip);
            cmd.Parameters.AddWithValue("Telefono_in", _proveedor.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _proveedor.Email);
            cmd.Parameters.AddWithValue("Provincia_in", _proveedor.Provincia);
            cmd.Parameters.AddWithValue("Localidad_in", _proveedor.Localidad);
            cmd.Parameters.AddWithValue("Calle_in", _proveedor.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _proveedor.Altura);
            cmd.Parameters.AddWithValue("CodigoPostal_in", _proveedor.CodigoPostal);
            cmd.Parameters.AddWithValue("idUsuario_in", _proveedor.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool ValidarProveedorExistente(string nombreRazonSocial, string cuit)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Proveedor> lista = new List<Proveedor>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("NombreRazonSocial_in", nombreRazonSocial),
            new MySqlParameter("Cuit_in", cuit)};
            string proceso = "ValidarProveedorExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "tProveedores");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<Proveedor> BuscarProveedorPorCuit(string cuit)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Proveedor> lista = new List<Entidades.Proveedor>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Cuit_in", cuit)};
            string proceso = "BuscarProveedorPorCuit";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Proveedor listaProveedor = new Proveedor();
                    listaProveedor.IdProveedor = Convert.ToInt32(item["idProveedor"].ToString());
                    listaProveedor.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    listaProveedor.Cuit = item["Cuit"].ToString();
                    listaProveedor.Factura = item["TipoFactura"].ToString();
                    listaProveedor.CondicionAntiAfip = item["CondicionAntiAfip"].ToString();
                    listaProveedor.Telefono = item["Telefono"].ToString();
                    listaProveedor.Email = item["Email"].ToString();
                    listaProveedor.Provincia = item["Provincia"].ToString();
                    listaProveedor.Localidad = item["Localidad"].ToString();
                    listaProveedor.Calle = item["Calle"].ToString();
                    listaProveedor.Altura = item["Altura"].ToString();
                    listaProveedor.CodigoPostal = item["CodigoPostal"].ToString();
                    lista.Add(listaProveedor);
                }
            }
            connection.Close();
            return lista;
        }

        public static List<Proveedor> BuscarProveedorPorNombreRazonSocial(string nombreRazonSocial)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Proveedor> lista = new List<Entidades.Proveedor>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("NombreRazonSocial_in", nombreRazonSocial)};
            string proceso = "BuscarProveedorPorNombreRazonSocial";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Proveedor listaProveedor = new Proveedor();
                    listaProveedor.IdProveedor = Convert.ToInt32(item["idProveedor"].ToString());
                    listaProveedor.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    listaProveedor.Cuit = item["Cuit"].ToString();
                    listaProveedor.Factura = item["TipoFactura"].ToString();
                    listaProveedor.CondicionAntiAfip = item["CondicionAntiAfip"].ToString();
                    listaProveedor.Telefono = item["Telefono"].ToString();
                    listaProveedor.Email = item["Email"].ToString();
                    listaProveedor.Provincia = item["Provincia"].ToString();
                    listaProveedor.Localidad = item["Localidad"].ToString();
                    listaProveedor.Calle = item["Calle"].ToString();
                    listaProveedor.Altura = item["Altura"].ToString();
                    listaProveedor.CodigoPostal = item["CodigoPostal"].ToString();
                    lista.Add(listaProveedor);
                }
            }
            connection.Close();
            return lista;
        }
    }
}
