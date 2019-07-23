using Sico.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Sico.Clases_Maestras;


namespace Sico.Dao
{
    public class ClienteDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
     
        public static List<string> CargarComboProvincia()
        {
            connection.Close();
            connection.Open();
            List<string> _listaProvincia = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListarProvincias";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _listaProvincia.Add(item["idProvincia"].ToString() + "," + item["txNombre"].ToString());
                }
            }
            connection.Close();
            return _listaProvincia;
        }

        public static List<Cliente> BuscarClientes()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter()};
            string proceso = "BuscarClientes";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Cliente listaCliente = new Cliente();
                    listaCliente.IdCliente = Convert.ToInt32(item["IdCliente"].ToString());
                    listaCliente.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    listaCliente.Cuit = item["Cuit"].ToString();
                    listaCliente.Actividad = item["Actividad"].ToString();
                    listaCliente.FechaDeInscripcion = Convert.ToDateTime(item["FechaInscripcion"].ToString());
                    listaCliente.CondicionAntiAfip = item["CondicionAntiAfip"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Provincia = item["Provincia"].ToString();
                    listaCliente.Localidad = item["Localidad"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.CodigoPostal = item["CodigoPostal"].ToString();
                    lista.Add(listaCliente);
                }
            }
            connection.Close();
            return lista;
        }

        public static string BuscarNroFactura(int idCliente)
        {
            string Factura = "";

            connection.Close();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
            string proceso = "BuscarNroFactura";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    string id = item["id"].ToString();
                    string FacturaVieja = item["NroFactura"].ToString();

                    ///// Primera parte del numero
                    var split1 = FacturaVieja.Split('-')[0];
                    split1 = split1.Trim();
                    ///// Segunda parte del numero
                    var split2 = FacturaVieja.Split('-')[1];
                    split2 = split2.Trim();

                    string prueba = string.Concat(split1, split2);
                    int Numero = Convert.ToInt32(prueba);
                    int Fac = Numero + 1;
                    string prueba2 = Convert.ToString(Fac);
                    Factura = string.Concat("0000", prueba2);

                }
            }

            connection.Close();
            return Factura;
        }
        public static int BuscarIdClientePorCuit(string cuit)
        {
            int idCliente = 0;
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Cuit_in", cuit)};
            string proceso = "BuscarIdClientePorCuit";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    idCliente = Convert.ToInt32(item["IdCliente"].ToString());
                }
            }
            connection.Close();
            return idCliente;
        }
        internal static bool GuardarFacturaSubCliente(FacturaCompra _factura)
        {
            throw new NotImplementedException();
        }
        public static List<SubCliente> BuscarDetalleFacturaSubCliente(string idsubCliente)
        {
            List<Entidades.SubCliente> lista = new List<Entidades.SubCliente>();

            int idsub = Convert.ToInt32(idsubCliente);
            connection.Close();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idsubCliente_in", idsub)};
            string proceso = "BuscarDetalleFacturaSubCliente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    SubCliente listaSubCliente = new SubCliente();
                    listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                    listaSubCliente.NroFactura = item["NroFactura"].ToString();
                    listaSubCliente.Fecha = item["Fecha"].ToString();
                    listaSubCliente.ApellidoNombre = item["ApellidoNombre"].ToString();
                    listaSubCliente.Dni = item["Dni"].ToString();
                    listaSubCliente.Direccion = item["Direccion"].ToString();
                    listaSubCliente.Observacion = item["Observacion"].ToString();
                    listaSubCliente.Monto = Convert.ToDecimal(item["Monto"].ToString());
                    listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                    listaSubCliente.Periodo = item["Periodo"].ToString();
                    //// Detalle de la factura
                    listaSubCliente.Total1 = Convert.ToDecimal(item["Total1"].ToString());
                    listaSubCliente.Total2 = Convert.ToDecimal(item["Total2"].ToString());
                    listaSubCliente.Total3 = Convert.ToDecimal(item["Total3"].ToString());
                    listaSubCliente.Neto1 = Convert.ToDecimal(item["Neto1"].ToString());
                    listaSubCliente.Neto2 = Convert.ToDecimal(item["Neto2"].ToString());
                    listaSubCliente.Neto3 = Convert.ToDecimal(item["Neto3"].ToString());
                    listaSubCliente.Alicuota1 = item["Alicuota1"].ToString();
                    listaSubCliente.Alicuota2 = item["Alicuota2"].ToString();
                    listaSubCliente.Alicuota3 = item["Alicuota3"].ToString();
                    listaSubCliente.Iva1 = Convert.ToDecimal(item["Iva1"].ToString());
                    listaSubCliente.Iva2 = Convert.ToDecimal(item["Iva2"].ToString());
                    listaSubCliente.Iva3 = Convert.ToDecimal(item["Iva3"].ToString());
                    listaSubCliente.TipoComprobante = item["TipoComprobante"].ToString();
                    listaSubCliente.CodigoMoneda = item["CodigoMoneda"].ToString();
                    listaSubCliente.TipoDeCambio = item["TipoDeCambio"].ToString();
                    listaSubCliente.CodigoTipoOperacion = item["CodigoOperacion"].ToString();
                    lista.Add(listaSubCliente);
                }
            }
            connection.Close();
            //}
            return lista;
        }
        public static List<string> CargarArchivos(string idsubCliente)
        {
            List<string> listarArchivos = new List<string>();
            connection.Close();
            connection.Open();
            List<Entidades.SubCliente> listaArchivos = new List<Entidades.SubCliente>();
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = connection;
            DataTable Tabla2 = new DataTable();
            MySqlParameter[] oParam2 = {
                                      new MySqlParameter("idsubCliente_in", idsubCliente)};
            string proceso2 = "BuscarArchivosFactura";
            MySqlDataAdapter dt2 = new MySqlDataAdapter(proceso2, connection);
            dt2.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt2.SelectCommand.Parameters.AddRange(oParam2);
            dt2.Fill(Tabla2);
            if (Tabla2.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla2.Rows)
                {
                    //int cantidadArchivos = lista[0].totalArchivos;
                    listarArchivos.Add(item["Archivos"].ToString());
                }
            }

            connection.Close();
            return listarArchivos;
        }
        public static bool GuardarNotaDeCredito(SubCliente _subCliente, string cuit)
        {
            int idUltimaFacturaSubCliente = 0;
            int idsubcliente = 0;
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;

            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "GuardarNotaDeCredito";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ApellidoNombre_in", _subCliente.ApellidoNombre);
            cmd.Parameters.AddWithValue("NroFacturaNotaDeCredito_in", _subCliente.NroFactura);
            cmd.Parameters.AddWithValue("Fecha_in", _subCliente.Fecha);
            cmd.Parameters.AddWithValue("Monto_in", _subCliente.Monto);
            cmd.Parameters.AddWithValue("idCliente_in", idCliente);
            cmd.Parameters.AddWithValue("Dni_in", _subCliente.Dni);
            cmd.Parameters.AddWithValue("Direccion_in", _subCliente.Direccion);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idUltimaFacturaSubCliente = Convert.ToInt32(r["ID"].ToString());
            }
            if (idUltimaFacturaSubCliente > 0)
            {
                exito = RegistrarDetalleFacturaSubCliente(_subCliente, idCliente, idUltimaFacturaSubCliente, idsubcliente);
            }
            connection.Close();
            return exito;
        }
        public static bool EditarSubCliente(SubCliente _subCliente, string cuit)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarSubCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _subCliente.Dni);
            cmd.Parameters.AddWithValue("ApellidoNombre_in", _subCliente.ApellidoNombre);
            cmd.Parameters.AddWithValue("Direccion_in", _subCliente.Direccion);
            cmd.Parameters.AddWithValue("Observacion_in", _subCliente.Observacion);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static string BuscarNuevoNroFacturaNotaDeCredito(string persona)
        {
            string Factura = "";

            connection.Close();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Persona_in", persona) };
            string proceso = "BuscarNuevoNroFacturaNotaDeCredito";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    string id = item["id"].ToString();
                    string FacturaVieja = item["NroFacturaNotaDeCredtio"].ToString();

                    ///// Primera parte del numero
                    var split1 = FacturaVieja.Split('-')[0];
                    split1 = split1.Trim();
                    ///// Segunda parte del numero
                    var split2 = FacturaVieja.Split('-')[1];
                    split2 = split2.Trim();
                    string prueba = string.Concat(split1, split2);
                    int Numero = Convert.ToInt32(prueba);
                    int Fac = Numero + 1;
                    string prueba2 = Convert.ToString(Fac);
                    Factura = string.Concat("000", prueba2);

                }
            }

            connection.Close();
            return Factura;
        }
        public static List<SubCliente> BuscarFacturacionTotal(string cuit, int mes, string año)
        {
            List<Entidades.SubCliente> lista = new List<Entidades.SubCliente>();
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            if (idCliente > 0)
            {
                string fecha = mes + "/" + año;
                connection.Close();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                            new MySqlParameter("fecha_in", fecha),
                                      new MySqlParameter("idCliente_in", idCliente)};
                string proceso = "BuscarFacturacionTotal";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        SubCliente listaSubCliente = new SubCliente();
                        listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                        listaSubCliente.NroFactura = item["NroFactura"].ToString();
                        listaSubCliente.Fecha = item["Fecha"].ToString();
                        listaSubCliente.ApellidoNombre = item["ApellidoNombre"].ToString();
                        listaSubCliente.Monto = Convert.ToDecimal(item["Monto"].ToString());
                        listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                        listaSubCliente.NroFacturaNotaDeCredtio = item["NroFacturaNotaDeCredtio"].ToString();

                        //// Detalle de la factura
                        listaSubCliente.Total1 = Convert.ToDecimal(item["Total1"].ToString());
                        listaSubCliente.Total2 = Convert.ToDecimal(item["Total2"].ToString());
                        listaSubCliente.Total3 = Convert.ToDecimal(item["Total3"].ToString());
                        listaSubCliente.Neto1 = Convert.ToDecimal(item["Neto1"].ToString());
                        listaSubCliente.Neto2 = Convert.ToDecimal(item["Neto2"].ToString());
                        listaSubCliente.Neto3 = Convert.ToDecimal(item["Neto3"].ToString());
                        listaSubCliente.Alicuota1 = item["Alicuota1"].ToString();
                        listaSubCliente.Alicuota2 = item["Alicuota2"].ToString();
                        listaSubCliente.Alicuota3 = item["Alicuota3"].ToString();
                        listaSubCliente.Iva1 = Convert.ToDecimal(item["Iva1"].ToString());
                        listaSubCliente.Iva2 = Convert.ToDecimal(item["Iva2"].ToString());
                        listaSubCliente.Iva3 = Convert.ToDecimal(item["Iva3"].ToString());
                        string dni = BuscarDniSubCliente(listaSubCliente.ApellidoNombre);
                        listaSubCliente.Dni = dni;
                        ////// Detalle Tipo Facturacion
                        //listaSubCliente.idTipoFactura = Convert.ToInt32(item["idTipoFacturacion"].ToString());
                        //listaSubCliente.idNotaDeCredito = Convert.ToInt32(item["idNotaDeCredito"].ToString());

                        lista.Add(listaSubCliente);
                    }
                }
            }
            connection.Close();
            return lista;
        }
        private static string BuscarDniSubCliente(string ApellidoNombre)
        {
            string DNI = "";
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("ApellidoNombre_in", ApellidoNombre)};
            string proceso = "BuscarDniSubCliente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item2 in Tabla.Rows)
                {
                    SubCliente listaSubCliente = new SubCliente();
                    listaSubCliente.Dni = item2["Dni"].ToString();
                    DNI = listaSubCliente.Dni;
                }
            }
            return DNI;
        }
        public static bool ValidarFacturaExistente(string nroFactura)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                                 new MySqlParameter("NroFactura_in", nroFactura)};
            string proceso = "ValidarFacturaExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "subcliente");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<SubCliente> BuscarTodasFacturasSubCliente(string cuit)
        {
            List<Entidades.SubCliente> lista = new List<Entidades.SubCliente>();
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            if (idCliente > 0)
            {
                connection.Close();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("idCliente_in", idCliente)};
                string proceso = "BuscarTodasFacturasSubCliente";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        SubCliente listaSubCliente = new SubCliente();
                        listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                        listaSubCliente.NroFactura = item["NroFactura"].ToString();
                        listaSubCliente.Fecha = item["Fecha"].ToString();
                        listaSubCliente.ApellidoNombre = item["ApellidoNombre"].ToString();
                        listaSubCliente.Dni = item["Dni"].ToString();
                        listaSubCliente.Direccion = item["Direccion"].ToString();
                        listaSubCliente.Monto = Convert.ToDecimal(item["Monto"].ToString());
                        listaSubCliente.idCliente = idCliente;
                        lista.Add(listaSubCliente);
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static List<SubCliente> BuscarDatosSubClientePorApellidoNombre(string apellidoNombre, string cuit)
        {
            List<Entidades.SubCliente> lista = new List<Entidades.SubCliente>();
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            if (idCliente > 0)
            {
                connection.Close();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("ApellidoNombre_in", apellidoNombre),
                new MySqlParameter("idCliente_in", idCliente)};
                string proceso = "BuscarDatosSubClientePorApellidoNombre";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        SubCliente listaSubCliente = new SubCliente();
                        listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                        listaSubCliente.NroFactura = item["NroFactura"].ToString();
                        listaSubCliente.Fecha = item["Fecha"].ToString();
                        listaSubCliente.ApellidoNombre = item["ApellidoNombre"].ToString();
                        listaSubCliente.Dni = item["Dni"].ToString();
                        listaSubCliente.Direccion = item["Direccion"].ToString();
                        listaSubCliente.Monto = Convert.ToDecimal(item["Monto"].ToString());
                        listaSubCliente.Observacion = item["Observacion"].ToString();
                        listaSubCliente.idCliente = idCliente;
                        lista.Add(listaSubCliente);
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static bool GuardarNuevoSubCliente(SubCliente _subCliente, string cuit)
        {
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            ///// creo valores ficticios para campos no null.
            _subCliente.Monto = 0000;
            _subCliente.NroFactura = "0000-00000000";

            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "GuardarNuevoSubCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _subCliente.Dni);
            cmd.Parameters.AddWithValue("ApellidoNombre_in", _subCliente.ApellidoNombre);
            cmd.Parameters.AddWithValue("Direccion_in", _subCliente.Direccion);
            cmd.Parameters.AddWithValue("Monto_in", _subCliente.Monto);
            cmd.Parameters.AddWithValue("NroFactura_in", _subCliente.NroFactura);
            cmd.Parameters.AddWithValue("idCliente_in", idCliente);
            cmd.Parameters.AddWithValue("Fecha_in", _subCliente.Fecha);
            cmd.Parameters.AddWithValue("Observacion_in", _subCliente.Observacion);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static string BuscarNuevoNroFactura(string persona)
        {
            string Factura = "";

            connection.Close();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("Persona_in", persona) };
            string proceso = "BuscarNuevoNroFactura";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    string id = item["id"].ToString();
                    string FacturaVieja = item["NroFactura"].ToString();

                    ///// Primera parte del numero
                    var split1 = FacturaVieja.Split('-')[0];
                    split1 = split1.Trim();
                    ///// Segunda parte del numero
                    var split2 = FacturaVieja.Split('-')[1];
                    split2 = split2.Trim();
                    string prueba = string.Concat(split1, split2);
                    int Numero = Convert.ToInt32(prueba);
                    int Fac = Numero + 1;
                    string prueba2 = Convert.ToString(Fac);
                    Factura = string.Concat("0000", prueba2);

                }
            }

            connection.Close();
            return Factura;
        }
        public static List<string> CargarComboPersonas(string cuit)
        {
            List<string> _listaPerosnas = new List<string>();
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            if (idCliente > 0)
            {
                connection.Close();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("idCliente_in", idCliente) };
                string proceso = "CargarComboPersonasSubCliente";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        _listaPerosnas.Add(item["ApellidoNombre"].ToString());
                    }
                }
            }
            connection.Close();
            return _listaPerosnas;
        }
        public static List<string> CargarComboLocalidadesPorIdProvincia(int idProvinciaSeleccionada)
        {
            connection.Close();
            connection.Open();
            List<string> _listaProvincia = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter("idProvincia_in", idProvinciaSeleccionada) };
            string proceso = "ListarLocalidadesPorIdProvincia";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _listaProvincia.Add(item["txNombre"].ToString());
                }
            }
            connection.Close();
            return _listaProvincia;
        }
        public static bool ValidarClienteExistente(string nombreRazonSocial, string cuit)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Usuario> lista = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("NombreRazonSocial_in", nombreRazonSocial),
            new MySqlParameter("Cuit_in", cuit)};
            string proceso = "ValidarClienteExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "tclientes");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static bool GuardarFacturaSubCliente(SubCliente _subCliente, string cuit)
        {
            bool exitoGuardarImagenes = false;
            if (_subCliente.Adjunto != "")
            {
                exitoGuardarImagenes = GuardarImagenesEnCarpeta(_subCliente);
            }

            int idNotaCredito = 0;
            int idUltimaFacturaSubCliente = 0;
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;

            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "GuardarFacturaSubCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ApellidoNombre_in", _subCliente.ApellidoNombre);
            cmd.Parameters.AddWithValue("NroFactura_in", _subCliente.NroFactura);
            cmd.Parameters.AddWithValue("Fecha_in", _subCliente.Fecha);
            cmd.Parameters.AddWithValue("Monto_in", _subCliente.Monto);
            cmd.Parameters.AddWithValue("idCliente_in", idCliente);
            cmd.Parameters.AddWithValue("Dni_in", _subCliente.Dni);
            cmd.Parameters.AddWithValue("Direccion_in", _subCliente.Direccion);
            cmd.Parameters.AddWithValue("Periodo_in", _subCliente.Periodo);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idUltimaFacturaSubCliente = Convert.ToInt32(r["ID"].ToString());
            }
            if (idUltimaFacturaSubCliente > 0)
            {
                exito = RegistrarDetalleFacturaSubCliente(_subCliente, idCliente, idUltimaFacturaSubCliente, idNotaCredito);
            }
            if (exito == true)
            {
                List<string> ListaArchivos = new List<string>();
                if (_subCliente.Adjunto != "")
                    ListaArchivos.Add(_subCliente.Adjunto);
                if (ListaArchivos.Count > 0)
                {
                    foreach (var item in ListaArchivos)
                    {
                        connection.Close();
                        connection.Open();
                        string proceso3 = "AltaArchivosFactura";
                        MySqlCommand cmd3 = new MySqlCommand(proceso3, connection);
                        cmd3.CommandType = CommandType.StoredProcedure;
                        cmd3.Parameters.AddWithValue("Archivo_in", item);
                        cmd3.Parameters.AddWithValue("idFacturaSubCliente_in", idUltimaFacturaSubCliente);
                        cmd3.ExecuteNonQuery();
                        exito = true;
                        connection.Close();
                    }
                }
            }
            connection.Close();
            return exito;
        }
        public static string Adj1;
        private static bool GuardarImagenesEnCarpeta(SubCliente _subCliente)
        {
            bool exito = false;
            bool exito1 = false;
            if (_subCliente.Adjunto != "")
            {
                string NombreArchivo = System.IO.Path.GetFileName(_subCliente.Adjunto);
                string sourcePath = System.IO.Path.GetDirectoryName(_subCliente.Adjunto);
                Adj1 = _subCliente.Adjunto;
                ////// Guardo el adjunto en la carpeta indicada.
                FacturaBCarpetaDestino carpeta = new FacturaBCarpetaDestino();
                string targetPath = carpeta.Carpeta;

                string sourceFile = System.IO.Path.Combine(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath, NombreArchivo);
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _subCliente.Adjunto = destFile;
                            exito1 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    // MessageBox.Show("Error");
                }
            }
            if (exito1 == true)
                exito = true;
            return exito;
        }
        public static bool GuardarEdicionFacturaSubCliente(SubCliente _subCliente, string cuit, string id)
        {
            int Idsub = Convert.ToInt32(id);
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarFacturaSubCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NroFactura_in", _subCliente.NroFactura);
            cmd.Parameters.AddWithValue("Fecha_in", _subCliente.Fecha);
            cmd.Parameters.AddWithValue("Monto_in", _subCliente.Monto);
            cmd.Parameters.AddWithValue("Idsub_in", Idsub);
            cmd.ExecuteNonQuery();
            exito = EditarDetalleFacturaSubCliente(_subCliente, Idsub);

            exito = true;
            connection.Close();
            return exito;
        }
        private static bool EditarDetalleFacturaSubCliente(SubCliente _subCliente, int Idsub)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarDetalleFacturaSubCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Total1_in", _subCliente.Total1);
            cmd.Parameters.AddWithValue("Total2_in", _subCliente.Total2);
            cmd.Parameters.AddWithValue("Total3_in", _subCliente.Total3);
            cmd.Parameters.AddWithValue("Neto1_in", _subCliente.Neto1);
            cmd.Parameters.AddWithValue("Neto2_in", _subCliente.Neto2);
            cmd.Parameters.AddWithValue("Neto3_in", _subCliente.Neto3);
            cmd.Parameters.AddWithValue("Alicuota1_in", _subCliente.Alicuota1);
            cmd.Parameters.AddWithValue("Alicuota2_in", _subCliente.Alicuota2);
            cmd.Parameters.AddWithValue("Alicuota3_in", _subCliente.Alicuota3);
            cmd.Parameters.AddWithValue("Iva1_in", _subCliente.Iva1);
            cmd.Parameters.AddWithValue("Iva2_in", _subCliente.Iva2);
            cmd.Parameters.AddWithValue("Iva3_in", _subCliente.Iva3);
            cmd.Parameters.AddWithValue("TipoComprobante_in", _subCliente.TipoComprobante);
            cmd.Parameters.AddWithValue("CodigoMoneda_in", _subCliente.CodigoMoneda);
            cmd.Parameters.AddWithValue("CodigoTipoOperacion_in", _subCliente.CodigoTipoOperacion);
            cmd.Parameters.AddWithValue("TipoDeCambio_in", _subCliente.TipoDeCambio);
            cmd.Parameters.AddWithValue("Idsub_in", Idsub);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        private static bool RegistrarDetalleFacturaSubCliente(SubCliente _subCliente, int idCliente, int idUltimaFacturaSubCliente, int idsubcliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "RegistrarDetalleFacturaSubCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Total1_in", _subCliente.Total1);
            cmd.Parameters.AddWithValue("Total2_in", _subCliente.Total2);
            cmd.Parameters.AddWithValue("Total3_in", _subCliente.Total3);
            cmd.Parameters.AddWithValue("Neto1_in", _subCliente.Neto1);
            cmd.Parameters.AddWithValue("Neto2_in", _subCliente.Neto2);
            cmd.Parameters.AddWithValue("Neto3_in", _subCliente.Neto3);
            cmd.Parameters.AddWithValue("Alicuota1_in", _subCliente.Alicuota1);
            cmd.Parameters.AddWithValue("Alicuota2_in", _subCliente.Alicuota2);
            cmd.Parameters.AddWithValue("Alicuota3_in", _subCliente.Alicuota3);
            cmd.Parameters.AddWithValue("Iva1_in", _subCliente.Iva1);
            cmd.Parameters.AddWithValue("Iva2_in", _subCliente.Iva2);
            cmd.Parameters.AddWithValue("Iva3_in", _subCliente.Iva3);
            cmd.Parameters.AddWithValue("idSubCliente_in", idUltimaFacturaSubCliente);
            cmd.Parameters.AddWithValue("idCliente_in", idCliente);
            cmd.Parameters.AddWithValue("TipoComprobante_in", _subCliente.TipoComprobante);
            cmd.Parameters.AddWithValue("CodigoMoneda_in", _subCliente.CodigoMoneda);
            cmd.Parameters.AddWithValue("TipoDeCambio_in", _subCliente.TipoDeCambio);
            cmd.Parameters.AddWithValue("CodigoTipoOperacion_in", _subCliente.CodigoTipoOperacion);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static bool InsertCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaCliente";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NombreRazonSocial_in", _cliente.NombreRazonSocial);
            cmd.Parameters.AddWithValue("Cuit_in", _cliente.Cuit);
            cmd.Parameters.AddWithValue("Actividad_in", _cliente.Actividad);
            cmd.Parameters.AddWithValue("FechaDeInscripcion_in", _cliente.FechaDeInscripcion);
            cmd.Parameters.AddWithValue("CondicionAntiAfip_in", _cliente.CondicionAntiAfip);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("Provincia_in", _cliente.Provincia);
            cmd.Parameters.AddWithValue("Localidad_in", _cliente.Localidad);
            cmd.Parameters.AddWithValue("Calle_in", _cliente.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _cliente.Altura);
            cmd.Parameters.AddWithValue("CodigoPostal_in", _cliente.CodigoPostal);
            cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<SubCliente> BuscarSubClientePorApellidoNombreCuit(string ApellidoNombre, string cuit)
        {
            List<Entidades.SubCliente> lista = new List<Entidades.SubCliente>();
            List<Entidades.Cliente> id = new List<Entidades.Cliente>();
            id = BuscarClientePorCuit(cuit);
            int idCliente = id[0].IdCliente;
            if (idCliente > 0)
            {
                connection.Close();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("ApellidoNombre_in", ApellidoNombre),
                new MySqlParameter("idCliente_in", idCliente)};
                string proceso = "BuscarSubClientePorApellidoNombreCuit";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        SubCliente listaSubCliente = new SubCliente();
                        listaSubCliente.idSubCliente = Convert.ToInt32(item["idSubCliente"].ToString());
                        listaSubCliente.NroFactura = item["NroFactura"].ToString();
                        listaSubCliente.Fecha = item["Fecha"].ToString();
                        listaSubCliente.ApellidoNombre = item["ApellidoNombre"].ToString();
                        listaSubCliente.Dni = item["Dni"].ToString();
                        listaSubCliente.Direccion = item["Direccion"].ToString();
                        listaSubCliente.Monto = Convert.ToDecimal(item["Monto"].ToString());
                        listaSubCliente.Observacion = item["Observacion"].ToString();
                        listaSubCliente.idCliente = idCliente;
                        lista.Add(listaSubCliente);
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static bool EditarCliente(Cliente _cliente)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarCliente";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("NombreRazonSocial_in", _cliente.NombreRazonSocial);
            cmd.Parameters.AddWithValue("Cuit_in", _cliente.Cuit);
            cmd.Parameters.AddWithValue("Actividad_in", _cliente.Actividad);
            cmd.Parameters.AddWithValue("FechaDeInscripcion_in", _cliente.FechaDeInscripcion);
            cmd.Parameters.AddWithValue("CondicionAntiAfip_in", _cliente.CondicionAntiAfip);
            cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
            cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
            cmd.Parameters.AddWithValue("Provincia_in", _cliente.Provincia);
            cmd.Parameters.AddWithValue("Localidad_in", _cliente.Localidad);
            cmd.Parameters.AddWithValue("Calle_in", _cliente.Calle);
            cmd.Parameters.AddWithValue("Altura_in", _cliente.Altura);
            cmd.Parameters.AddWithValue("CodigoPostal_in", _cliente.CodigoPostal);
            cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Cliente> BuscarClientePorCuit(string cuit)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Cuit_in", cuit)};
            string proceso = "BuscarClientePorCuit";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Cliente listaCliente = new Cliente();
                    listaCliente.IdCliente = Convert.ToInt32(item["IdCliente"].ToString());
                    listaCliente.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    listaCliente.Cuit = item["Cuit"].ToString();
                    listaCliente.Actividad = item["Actividad"].ToString();
                    listaCliente.FechaDeInscripcion = Convert.ToDateTime(item["FechaInscripcion"].ToString());
                    listaCliente.CondicionAntiAfip = item["CondicionAntiAfip"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Provincia = item["Provincia"].ToString();
                    listaCliente.Localidad = item["Localidad"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.CodigoPostal = item["CodigoPostal"].ToString();
                    lista.Add(listaCliente);
                }
            }
            connection.Close();
            return lista;
        }
        public static List<Cliente> BuscarClientePorNombreRazonSocial(string nombreRazonSocial)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("NombreRazonSocial_in", nombreRazonSocial)};
            string proceso = "BuscarClientePorNombreRazonSocial";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Cliente listaCliente = new Cliente();
                    listaCliente.IdCliente = Convert.ToInt32(item["IdCliente"].ToString());
                    listaCliente.NombreRazonSocial = item["NombreRazonSocial"].ToString();
                    listaCliente.Cuit = item["Cuit"].ToString();
                    listaCliente.Actividad = item["Actividad"].ToString();
                    listaCliente.FechaDeInscripcion = Convert.ToDateTime(item["FechaInscripcion"].ToString());
                    listaCliente.CondicionAntiAfip = item["CondicionAntiAfip"].ToString();
                    listaCliente.Telefono = item["Telefono"].ToString();
                    listaCliente.Email = item["Email"].ToString();
                    listaCliente.Provincia = item["Provincia"].ToString();
                    listaCliente.Localidad = item["Localidad"].ToString();
                    listaCliente.Calle = item["Calle"].ToString();
                    listaCliente.Altura = item["Altura"].ToString();
                    listaCliente.CodigoPostal = item["CodigoPostal"].ToString();
                    lista.Add(listaCliente);
                }
            }
            connection.Close();
            return lista;
        }
        public static List<string> CargarComboLocalidades()
        {
            connection.Close();
            connection.Open();
            List<string> _listaProvincia = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "ListarLocalidades";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _listaProvincia.Add(item["idLocalidad"].ToString() + "," + item["txNombre"].ToString());
                }
            }
            connection.Close();
            return _listaProvincia;
        }
    }
}
