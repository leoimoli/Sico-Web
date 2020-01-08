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
    public class UsuarioDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool InsertUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "AltaUsuario";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.Parameters.AddWithValue("Apellido_in", _usuario.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _usuario.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _usuario.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Contrasenia_in", _usuario.Contraseña);
            cmd.Parameters.AddWithValue("FechaDeAlta_in", _usuario.FechaDeAlta);
            cmd.Parameters.AddWithValue("FechaUltimaConexion_in", _usuario.FechaUltimaConexion);
            cmd.Parameters.AddWithValue("Perfil_in", _usuario.Perfil);
            cmd.Parameters.AddWithValue("Estado_in", _usuario.Estado);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }

        public static List<Usuario> BuscarUsuarios()
        {
            connection.Close();
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { };
            string proceso = "BuscarUsuarios";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Usuario listaUsuario = new Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechadeAlta"].ToString());
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = item["Perfil"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }

        public static List<CuentaEmailPorUsuario> BuscarCuentaEmailPorUsuario(int idusuarioLogueado)
        {
            connection.Close();
            connection.Open();
            List<Entidades.CuentaEmailPorUsuario> listaCuenta = new List<Entidades.CuentaEmailPorUsuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idUsuario_in", idusuarioLogueado)};
            string proceso = "BuscarCuentaEmailPorUsuario";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    CuentaEmailPorUsuario lista = new CuentaEmailPorUsuario();
                    lista.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    lista.CuentaEmail = item["CuentaEmail"].ToString();
                    lista.ClaveEmail = item["ClaveEmail"].ToString();
                    lista.FirmaEmail = item["FirmaEmail"].ToString();
                    listaCuenta.Add(lista);
                }
            }
            connection.Close();
            return listaCuenta;
        }
        public static bool InsertCuentaEmail(CuentaEmailPorUsuario _cuenta)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string proceso = "InsertCuentaEmail";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CuentaEmail_in", _cuenta.CuentaEmail);
            cmd.Parameters.AddWithValue("ClaveEmail_in", _cuenta.ClaveEmail);
            cmd.Parameters.AddWithValue("FirmaEmail_in", _cuenta.FirmaEmail);
            cmd.Parameters.AddWithValue("IdUsuario_in", _cuenta.IdUsuario);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        //public static bool LevantarBackup()
        //{
        //    string rutaPen = "";
        //    DriveInfo[] mydrives = DriveInfo.GetDrives();
        //    foreach (DriveInfo mydrive in mydrives)
        //    {
        //        //Check for removable devices like USB's
        //        if (mydrive.DriveType == DriveType.Removable)
        //        {
        //            //Check for that specific USB
        //            if (mydrive.IsReady == true)
        //            {
        //                if (mydrive.VolumeLabel.Equals("KINGSTON"))
        //                {
        //                    DirectoryInfo path = mydrive.RootDirectory;
        //                    Path.GetFullPath(path.ToString());
        //                    rutaPen = Path.GetFullPath(path.ToString());
        //                }
        //            }
        //        }
        //    }
        //    bool exito = false;
        //    connection.Close();
        //    string constring = "server=localhost;Port=3307;User Id=root;password=admin;database=sico_desarrollo;Persist Security Info=True;";

        //    // Important Additional Connection Options
        //    constring += "convertzerodatetime=true;";
        //    string file = ""+rutaPen+"backup.sql";
        //    //string file = "F:\\backup.sql";
        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            using (MySqlBackup mb = new MySqlBackup(cmd))
        //            {
        //                cmd.Connection = conn;
        //                conn.Open();
        //                mb.ImportFromFile(file);
        //                conn.Close();
        //                exito = true;
        //            }
        //        }
        //    }
        //    return exito;
        //}
        public static List<Usuario> LoginUsuario(string usuario, string contraseña)
        {
            connection.Close();
            string estado = "ACTIVO";
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", usuario),
                                       new MySqlParameter("Contrasenia_in", contraseña),
             new MySqlParameter("Estado_in", estado)};
            string proceso = "LoginUsuario";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Entidades.Usuario listaUsuario = new Entidades.Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = item["Perfil"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        //public static bool GenerarBackup()
        //{
        //    string rutaPen = "";
        //    DriveInfo[] mydrives = DriveInfo.GetDrives();
        //    foreach (DriveInfo mydrive in mydrives)
        //    {
        //        //Check for removable devices like USB's
        //        if (mydrive.DriveType == DriveType.Removable)
        //        {
        //            //Check for that specific USB
        //            if (mydrive.IsReady == true)
        //            {
        //                if (mydrive.VolumeLabel.Equals("KINGSTON"))
        //                {
        //                    DirectoryInfo path = mydrive.RootDirectory;
        //                    Path.GetFullPath(path.ToString());
        //                    rutaPen = Path.GetFullPath(path.ToString());
        //                }
        //            }
        //        }
        //    }
        //    bool exito = false;
        //    connection.Close();
        //    string constring = "server=localhost;Port=3307;User Id=root;password=admin;database=sico_desarrollo;Persist Security Info=True;";
        //    constring += "convertzerodatetime=true;";
        //    string file = "" + rutaPen + "backup.sql";
        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            using (MySqlBackup mb = new MySqlBackup(cmd))
        //            {
        //                cmd.Connection = conn;
        //                conn.Open();
        //                mb.ExportToFile(file);
        //                conn.Close();
        //                exito = true;
        //            }
        //        }
        //    }
        //    return exito;

        //}
        public static bool BajaUsuario(string dni)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "BajaUsuario";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            string Estado = "INACTIVO";
            cmd.Parameters.AddWithValue("Estado_in", Estado);
            cmd.Parameters.AddWithValue("Dni_in", dni);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        public static List<Usuario> BuscarUsuarioPorDNI(string dni)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("DNI_in", dni)};
            string proceso = "BuscarUsuarioPorDNI";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Usuario listaUsuario = new Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = item["Perfil"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool ValidarUsuarioExistente(string dni)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Usuario> lista = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", dni) };
            string proceso = "ValidarUsuarioExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "usuario");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<Usuario> BuscarUsuarioPorApellido(string apellido)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Apellido_in", apellido)};
            string proceso = "BuscarUsuarioPorApellido";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Usuario listaUsuario = new Usuario();
                    listaUsuario.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                    listaUsuario.Apellido = item["Apellido"].ToString();
                    listaUsuario.Nombre = item["Nombre"].ToString();
                    listaUsuario.Dni = item["Dni"].ToString();
                    listaUsuario.FechaDeNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                    listaUsuario.FechaDeAlta = Convert.ToDateTime(item["FechaDeAlta"].ToString());
                    listaUsuario.FechaUltimaConexion = Convert.ToDateTime(item["UltimoInicioSesion"].ToString());
                    listaUsuario.Contraseña = item["Contrasenia"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    listaUsuario.Perfil = item["Perfil"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static bool EditarUsuario(Usuario _usuario)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "EditarUsuario";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Apellido_in", _usuario.Apellido);
            cmd.Parameters.AddWithValue("Nombre_in", _usuario.Nombre);
            cmd.Parameters.AddWithValue("FechaDeNacimiento_in", _usuario.FechaDeNacimiento);
            cmd.Parameters.AddWithValue("Contrasenia_in", _usuario.Contraseña);
            cmd.Parameters.AddWithValue("Perfil_in", _usuario.Perfil);
            cmd.Parameters.AddWithValue("Estado_in", _usuario.Estado);
            cmd.Parameters.AddWithValue("Dni_in", _usuario.Dni);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
