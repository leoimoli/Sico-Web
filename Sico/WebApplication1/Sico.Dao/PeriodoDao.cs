using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Sico.Entidades;

namespace Sico.Dao
{
    public class PeriodoDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool GuardarPeriodo(string cuit, string nombre, string Año)
        {
            bool exito = false;
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            bool YaExiste = ValidadPeriodoExistente(nombre, idCliente, Año);
            if (YaExiste == false)
            {
                connection.Close();
                connection.Open();
                string proceso = "GuardarPeriodo";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente_in", idCliente);
                cmd.Parameters.AddWithValue("Ano_in", Año);
                cmd.Parameters.AddWithValue("Nombre_in", nombre);
                cmd.ExecuteNonQuery();
                exito = true;
                connection.Close();
                return exito;
            }
            else
            {
                const string message = "Ya existe un Periodo con el mismo nombre para el cliente seleccionado.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                exito = false;
                return exito;
            }
        }
        public static List<string> CargarComboPeriodoVenta(string cuit)
        {
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            connection.Close();
            connection.Open();
            List<string> _TipoMoneda = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
            string proceso = "ListarPeriodoVenta";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _TipoMoneda.Add(item["Nombre"].ToString());
                }
            }
            connection.Close();
            return _TipoMoneda;
        }
        public static List<Periodo> BuscarPeriodosExistentePorTransaccionAño(string transaccion, string cuit, string Año)
        {
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            List<Periodo> _periodo = new List<Periodo>();
            connection.Close();
            connection.Open();
            if (transaccion == "Ventas")
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente),
                new MySqlParameter("Año_in", Año)};
                string proceso = "BuscarPeriodosVentasExistentePorTransaccionAño";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        Periodo _listaPeriodo = new Periodo();
                        _listaPeriodo.idPeriodo = Convert.ToInt32(item["idPeriodoVenta"].ToString());
                        _listaPeriodo.NombrePeriodo = item["Nombre"].ToString();
                        _listaPeriodo.Ano = item["ano"].ToString();
                        _periodo.Add(_listaPeriodo);
                    }
                }
                connection.Close();
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente),
                new MySqlParameter("Año_in", Año)};
                string proceso = "BuscarPeriodosComprasExistentePorTransaccionAño";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        Periodo _listaPeriodo = new Periodo();
                        _listaPeriodo.idPeriodo = Convert.ToInt32(item["idPeriodoCompra"].ToString());
                        _listaPeriodo.NombrePeriodo = item["Nombre"].ToString();
                        _listaPeriodo.Ano = item["ano"].ToString();
                        _periodo.Add(_listaPeriodo);
                    }
                }
                connection.Close();
            }
            return _periodo;
        }
        public static List<Periodo> BuscarPeriodosExistentePorTransaccion(string transaccion, string cuit)
        {
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            List<Periodo> _periodo = new List<Periodo>();
            connection.Close();
            connection.Open();
            if (transaccion == "Ventas")
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
                string proceso = "BuscarPeriodosVentasExistentePorTransaccion";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        Periodo _listaPeriodo = new Periodo();
                        _listaPeriodo.idPeriodo = Convert.ToInt32(item["idPeriodoVenta"].ToString());
                        _listaPeriodo.NombrePeriodo = item["Nombre"].ToString();
                        _listaPeriodo.Ano = item["ano"].ToString();
                        _periodo.Add(_listaPeriodo);
                    }
                }
                connection.Close();
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
                string proceso = "BuscarPeriodosComprasExistentePorTransaccion";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        Periodo _listaPeriodo = new Periodo();
                        _listaPeriodo.idPeriodo = Convert.ToInt32(item["idPeriodoCompra"].ToString());
                        _listaPeriodo.NombrePeriodo = item["Nombre"].ToString();
                        _listaPeriodo.Ano = item["ano"].ToString();
                        _periodo.Add(_listaPeriodo);
                    }
                }
                connection.Close();
            }
            return _periodo;
        }
        public static bool GuardarPeriodoVenta(string cuit, string nombre, string Año)
        {
            bool exito = false;
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            bool YaExiste = ValidadPeriodoVentaExistente(nombre, idCliente, Año);
            string NombrePeriodo = nombre + Año;
            if (YaExiste == false)
            {
                connection.Close();
                connection.Open();
                string proceso = "GuardarPeriodoVenta";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente_in", idCliente);
                cmd.Parameters.AddWithValue("Ano_in", Año);
                cmd.Parameters.AddWithValue("Nombre_in", NombrePeriodo);
                cmd.ExecuteNonQuery();
                exito = true;
                connection.Close();
                return exito;
            }
            else
            {
                const string message = "Ya existe un Periodo de Venta con el mismo nombre para el cliente seleccionado.";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation);
                throw new Exception();
                exito = false;
                return exito;
            }
        }
        private static bool ValidadPeriodoVentaExistente(string nombre, int idCliente, string Año)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            string NombrePeriodo = nombre + Año;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", NombrePeriodo),
                                      new MySqlParameter("Ano_in", Año),
            new MySqlParameter("idCliente_in", idCliente)};
            string proceso = "ValidadPeriodoVentaExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "tPeriodosVentas");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        private static bool ValidadPeriodoExistente(string nombre, int idCliente, string Año)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre),
                                      new MySqlParameter("Ano_in", Año),
            new MySqlParameter("idCliente_in", idCliente)};
            string proceso = "ValidadPeriodoExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "tPeriodosCompras");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<string> CargarComboPeriodo(string cuit)
        {
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = ClienteDao.BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            connection.Close();
            connection.Open();
            List<string> _TipoMoneda = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
            string proceso = "ListarPeriodo";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _TipoMoneda.Add(item["Nombre"].ToString());
                }
            }
            connection.Close();
            return _TipoMoneda;
        }
    }
}
