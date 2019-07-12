using MySql.Data.MySqlClient;
//using Sico.Clases_Maestras;
using Sico.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
//using Newtonsoft.Json;
//using Google.Cloud.Storage.V1;
using System.Configuration;
using Sico.Clases_Maestras;

namespace Sico.Dao
{
    public class PericiaDao
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("DB"));
        public static bool ValidarPericiaExistente(string tribunal, string causa)
        {
            connection.Close();
            bool Existe = false;
            connection.Open();
            List<Pericias> lista = new List<Pericias>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Tribunal_in", tribunal),new MySqlParameter("Causa_in", causa) };
            string proceso = "ValidarPericiaExistente";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            DataSet ds = new DataSet();
            dt.Fill(ds, "pericia");
            if (Tabla.Rows.Count > 0)
            {
                Existe = true;
            }
            connection.Close();
            return Existe;
        }
        public static List<string> CargarArchivos(string idPericiaSeleccionada)
        {
            List<string> listarArchivos = new List<string>();
            connection.Close();
            connection.Open();
            List<Entidades.Pericias> listaArchivos = new List<Entidades.Pericias>();
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = connection;
            DataTable Tabla2 = new DataTable();
            MySqlParameter[] oParam2 = {
                                      new MySqlParameter("idPericia_in", idPericiaSeleccionada)};
            string proceso2 = "BuscarArchivosPericia";
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
        public static bool InsertPericia(Pericias _pericia)
        {

            bool exito = false;
            bool exitoGuardarImagenes = false;
            if (_pericia.Archivo1 != "" || _pericia.Archivo2 != "" || _pericia.Archivo3 != "" || _pericia.Archivo4 != "" || _pericia.Archivo5 != "" || _pericia.Archivo6 != "" || _pericia.Archivo7 != "" || _pericia.Archivo8 != "" || _pericia.Archivo9 != "" || _pericia.Archivo10 != "")
            {
                exitoGuardarImagenes = GuardarImagenesEnCarpeta(_pericia);
            }
            //if (exitoGuardarImagenes != false & _pericia.Archivo1 == "" || _pericia.Archivo2 == "" || _pericia.Archivo3 == "" || _pericia.Archivo4 == "" || _pericia.Archivo5 == "" || _pericia.Archivo6 == "" || _pericia.Archivo7 == "" || _pericia.Archivo8 == "" || _pericia.Archivo9 == "" || _pericia.Archivo10 == "")
            //{
            int idUltimaPericia = 0;
            connection.Close();
            connection.Open();
            string proceso = "AltaPericia";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Tribunal_in", _pericia.Tribunal);
            cmd.Parameters.AddWithValue("Fecha_in", _pericia.Fecha);
            cmd.Parameters.AddWithValue("NroCausa_in", _pericia.NroCausa);
            cmd.Parameters.AddWithValue("Causa_in", _pericia.Causa);
            cmd.Parameters.AddWithValue("Compartido_in", _pericia.Compartido);
            cmd.Parameters.AddWithValue("Email_in", _pericia.Email);
            cmd.Parameters.AddWithValue("Estado_in", _pericia.Estado);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                idUltimaPericia = Convert.ToInt32(r["ID"].ToString());
            }
            if (idUltimaPericia > 0)
            {
                connection.Close();
                connection.Open();
                string proceso2 = "AltaHistorialPericia";
                MySqlCommand cmd2 = new MySqlCommand(proceso2, connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("Descripcion_in", "Inicio de Pericia");
                cmd2.Parameters.AddWithValue("Estado_in", _pericia.Estado);
                cmd2.Parameters.AddWithValue("Fecha_in", _pericia.Fecha);
                cmd2.Parameters.AddWithValue("idPericia_in", idUltimaPericia);
                cmd2.ExecuteNonQuery();
                exito = true;
                connection.Close();

                if (exito == true)
                {
                    List<string> ListaArchivos = new List<string>();
                    if (_pericia.Archivo1 != "")
                        ListaArchivos.Add(_pericia.Archivo1);
                    if (_pericia.Archivo2 != "")
                        ListaArchivos.Add(_pericia.Archivo2);
                    if (_pericia.Archivo3 != "")
                        ListaArchivos.Add(_pericia.Archivo3);
                    if (_pericia.Archivo4 != "")
                        ListaArchivos.Add(_pericia.Archivo4);
                    if (_pericia.Archivo5 != "")
                        ListaArchivos.Add(_pericia.Archivo5);
                    if (_pericia.Archivo6 != "")
                        ListaArchivos.Add(_pericia.Archivo6);
                    if (_pericia.Archivo7 != "")
                        ListaArchivos.Add(_pericia.Archivo7);
                    if (_pericia.Archivo8 != "")
                        ListaArchivos.Add(_pericia.Archivo8);
                    if (_pericia.Archivo9 != "")
                        ListaArchivos.Add(_pericia.Archivo9);
                    if (_pericia.Archivo10 != "")
                        ListaArchivos.Add(_pericia.Archivo10);
                    if (ListaArchivos.Count > 0)
                    {
                        foreach (var item in ListaArchivos)
                        {
                            connection.Close();
                            connection.Open();
                            string proceso3 = "AltaArchivosPericia";
                            MySqlCommand cmd3 = new MySqlCommand(proceso3, connection);
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.AddWithValue("Archivo_in", item);
                            cmd3.Parameters.AddWithValue("idPericia_in", idUltimaPericia);
                            cmd3.ExecuteNonQuery();
                            exito = true;
                            connection.Close();
                        }
                    }
                    //}
                    if (exito == true & _pericia.Compartido == 1)
                    { bool EmailConExito = EnviarEmail(_pericia); }
                }
            }
            return exito;
        }
        public static List<Pericias> BuscarHistorialPericia(int idPer)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Pericias> lista = new List<Entidades.Pericias>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("idPericia_in", idPer)};
            string proceso = "BuscarHistorialPericia";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Pericias listaUsuario = new Pericias();
                    listaUsuario.idPericia = Convert.ToInt32(item["idPericia"].ToString());
                    listaUsuario.Tribunal = item["Tribunal"].ToString();
                    listaUsuario.NroCausa = item["NroCausa"].ToString();
                    listaUsuario.Causa = item["Causa"].ToString();
                    listaUsuario.Compartido = Convert.ToInt32(item["Compartir"].ToString());
                    listaUsuario.Email = item["Email"].ToString();
                    listaUsuario.Descripcion = item["Descrip"].ToString();
                    listaUsuario.Estado = item["Est"].ToString();
                    listaUsuario.Fecha = Convert.ToDateTime(item["Fec"].ToString());
                    listaUsuario.totalArchivos = Convert.ToInt32(item["count(*)"].ToString());
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;

        }
        public static bool InsertHistorialPericia(Pericias _pericia)
        {
            bool exito = false;
            bool exitoGuardarImagenes = false;
            if (_pericia.Archivo1 != "" || _pericia.Archivo2 != "" || _pericia.Archivo3 != "" || _pericia.Archivo4 != "" || _pericia.Archivo5 != "" || _pericia.Archivo6 != "" || _pericia.Archivo7 != "" || _pericia.Archivo8 != "" || _pericia.Archivo9 != "" || _pericia.Archivo10 != "")
            {
                exitoGuardarImagenes = GuardarImagenesEnCarpeta(_pericia);
            }
            //if (exitoGuardarImagenes == false & _pericia.Archivo1 == "" || _pericia.Archivo2 == "" || _pericia.Archivo3 == "")
            //{
            connection.Close();
            connection.Open();
            string proceso2 = "AltaHistorialPericia";
            MySqlCommand cmd2 = new MySqlCommand(proceso2, connection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("Descripcion_in", _pericia.Descripcion);
            cmd2.Parameters.AddWithValue("Estado_in", _pericia.Estado);
            cmd2.Parameters.AddWithValue("Fecha_in", _pericia.Fecha);
            cmd2.Parameters.AddWithValue("idPericia_in", _pericia.idPericia);
            cmd2.ExecuteNonQuery();
            exito = true;
            connection.Close();
            if (exito == true)
            {
                List<string> ListaArchivos = new List<string>();
                if (_pericia.Archivo1 != "")
                    ListaArchivos.Add(_pericia.Archivo1);
                if (_pericia.Archivo2 != "")
                    ListaArchivos.Add(_pericia.Archivo2);
                if (_pericia.Archivo3 != "")
                    ListaArchivos.Add(_pericia.Archivo3);
                if (_pericia.Archivo4 != "")
                    ListaArchivos.Add(_pericia.Archivo4);
                if (_pericia.Archivo5 != "")
                    ListaArchivos.Add(_pericia.Archivo5);
                if (_pericia.Archivo6 != "")
                    ListaArchivos.Add(_pericia.Archivo6);
                if (_pericia.Archivo7 != "")
                    ListaArchivos.Add(_pericia.Archivo7);
                if (_pericia.Archivo8 != "")
                    ListaArchivos.Add(_pericia.Archivo8);
                if (_pericia.Archivo9 != "")
                    ListaArchivos.Add(_pericia.Archivo9);
                if (_pericia.Archivo10 != "")
                    ListaArchivos.Add(_pericia.Archivo10);
                foreach (var item in ListaArchivos)
                {
                    connection.Close();
                    connection.Open();
                    string proceso3 = "AltaArchivosPericia";
                    MySqlCommand cmd3 = new MySqlCommand(proceso3, connection);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("Archivo_in", item);
                    cmd3.Parameters.AddWithValue("idPericia_in", _pericia.idPericia);
                    cmd3.ExecuteNonQuery();
                    exito = true;
                    connection.Close();
                }

                exito = ActualizarEstadoPericia(_pericia);
            }
            if (exito == true & _pericia.Compartido == 1)
            { bool EmailConExito = EnviarEmail(_pericia); }


            return exito;
        }
        private static bool ActualizarEstadoPericia(Pericias _pericia)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            string Actualizar = "ActualizarEstadoPericia";
            MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idPericia_in", _pericia.idPericia);
            cmd.Parameters.AddWithValue("Estado_in", _pericia.Estado);
            cmd.ExecuteNonQuery();
            exito = true;
            connection.Close();
            return exito;
        }
        private static bool EnviarEmail(Pericias _pericia)
        {
            List<CuentaEmailPorUsuario> cuenta = new List<CuentaEmailPorUsuario>();
            cuenta = UsuarioDao.BuscarCuentaEmailPorUsuario(_pericia.UsuarioLogin);
            var Cuenta = cuenta.First();
            Variables _variables = new Variables();
            bool exito = false;
            string emisor = Cuenta.CuentaEmail;
            string pwd = Cuenta.ClaveEmail;
            string correo = "";
            if (_pericia.TotalEstados > 1)
            {
                correo = "Estimada/o, le informamos que se creo un nuevo movimiento en la pericia con Número de causa " + _pericia.NroCausa + ", referente a la causa " + _pericia.Causa + " <br />abierta en el " + _pericia.Tribunal + " con fecha de creación " + _pericia.Fecha + ". <br /> Se informa que lo siguiente respecto a la pericia: " + _pericia.Descripcion + "<br />" + Cuenta.FirmaEmail + "<br />.";

            }
            else { correo = "Estimada/o, le informamos que se inicio una nueva pericia con Número de causa " + _pericia.NroCausa + ", referente a la causa " + _pericia.Causa + " <br /> abierta en el " + _pericia.Tribunal + " con fecha de creación " + _pericia.Fecha + ". <br /> " + Cuenta.FirmaEmail + "."; }
            List<string> adjuntos = new List<string>();
            string adjunto1 = Adj1;
            if (adjunto1 != null)
                adjuntos.Add(adjunto1);
            string adjunto2 = Adj2;
            if (adjunto2 != null)
                adjuntos.Add(adjunto2);
            string adjunto3 = Adj3;
            if (adjunto3 != null)
                adjuntos.Add(adjunto3);
            string adjunto4 = Adj4;
            if (adjunto4 != null)
                adjuntos.Add(adjunto4);
            string adjunto5 = Adj5;
            if (adjunto5 != null)
                adjuntos.Add(adjunto5);
            string adjunto6 = Adj6;
            if (adjunto6 != null)
                adjuntos.Add(adjunto6);
            string adjunto7 = Adj7;
            if (adjunto7 != null)
                adjuntos.Add(adjunto7);
            string adjunto8 = Adj8;
            if (adjunto8 != null)
                adjuntos.Add(adjunto8);
            string adjunto9 = Adj9;
            if (adjunto9 != null)
                adjuntos.Add(adjunto9);
            string adjunto10 = Adj10;
            if (adjunto10 != null)
                adjuntos.Add(adjunto10);

            //if (adjuntos.Count > 1)
            //{ ComprimirArchivos(adjuntos); }

            MailMessage msg = new MailMessage();
            //Quien escribe al correo
            msg.From = new MailAddress(emisor);
            //A quien va dirigido
            msg.To.Add(new MailAddress(_pericia.Email));
            //Asunto
            msg.Subject = "Pericia " + _pericia.NroCausa + " por la causa " + _pericia.Causa + "";
            //Contenido del correo
            msg.Body = correo;
            msg.IsBodyHtml = true;
            //Adjuntamos archivo
            //string tempFileName = Oid.ToString();

            foreach (string attach in adjuntos)
            {
                Attachment attached = new Attachment(attach, System.Net.Mime.MediaTypeNames.Application.Octet);
                msg.Attachments.Add(attached);
            }
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(emisor, pwd);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atención si bien la pericia se guardo correctamente, Fallo el envio de email.");
            }
            return exito;
        }
        public static List<Pericias> BuscarPericiasPorCausa(string causa)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Pericias> lista = new List<Entidades.Pericias>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Causa_in", causa)};
            string proceso = "BuscarPericiasPorCausa";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Pericias listaUsuario = new Pericias();
                    listaUsuario.idPericia = Convert.ToInt32(item["idPericia"].ToString());
                    listaUsuario.Tribunal = item["Tribunal"].ToString();
                    listaUsuario.Fecha = Convert.ToDateTime(item["Fecha"].ToString());
                    listaUsuario.NroCausa = item["NroCausa"].ToString();
                    listaUsuario.Causa = item["Causa"].ToString();
                    //listaUsuario.Archivo1 = item["Archivo1"].ToString();
                    //listaUsuario.Archivo2 = item["Archivo2"].ToString();
                    //listaUsuario.Archivo3 = item["Archivo3"].ToString();
                    listaUsuario.Compartido = Convert.ToInt32(item["Compartir"].ToString());
                    listaUsuario.Email = item["Email"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static List<Pericias> BuscarPericiasPorTribunal(string tribunal)
        {
            connection.Close();
            connection.Open();
            List<Entidades.Pericias> lista = new List<Entidades.Pericias>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = {
                                      new MySqlParameter("Tribunal_in", tribunal)};
            string proceso = "BuscarPericiasPorTribunal";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    Pericias listaUsuario = new Pericias();
                    listaUsuario.idPericia = Convert.ToInt32(item["idPericia"].ToString());
                    listaUsuario.Tribunal = item["Tribunal"].ToString();
                    listaUsuario.Fecha = Convert.ToDateTime(item["Fecha"].ToString());
                    listaUsuario.NroCausa = item["NroCausa"].ToString();
                    listaUsuario.Causa = item["Causa"].ToString();
                    //listaUsuario.Archivo1 = item["Archivo1"].ToString();
                    //listaUsuario.Archivo2 = item["Archivo2"].ToString();
                    //listaUsuario.Archivo3 = item["Archivo3"].ToString();
                    listaUsuario.Compartido = Convert.ToInt32(item["Compartir"].ToString());
                    listaUsuario.Email = item["Email"].ToString();
                    listaUsuario.Estado = item["Estado"].ToString();
                    lista.Add(listaUsuario);
                }
            }
            connection.Close();
            return lista;
        }
        public static string Adj1;
        public static string Adj2;
        public static string Adj3;
        public static string Adj4;
        public static string Adj5;
        public static string Adj6;
        public static string Adj7;
        public static string Adj8;
        public static string Adj9;
        public static string Adj10;
        private static bool GuardarImagenesEnCarpeta(Pericias _pericia)
        {

            bool exito = false;
            bool exito1 = false;
            bool exito2 = false;
            bool exito3 = false;
            bool exito4 = false;
            bool exito5 = false;
            bool exito6 = false;
            bool exito7 = false;
            bool exito8 = false;
            bool exito9 = false;
            bool exito10 = false;
            if (_pericia.Archivo1 != "")
            {
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo1);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo1);
                Adj1 = _pericia.Archivo1;
                CarpetaDestino carpeta = new CarpetaDestino();
                string targetPath = carpeta.Carpeta;
                //string targetPath = @"C:\Sico\Archivos";
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
                            _pericia.Archivo1 = destFile;
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
            if (_pericia.Archivo2 != "")
            {
                exito2 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo2);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo2);
                Adj2 = _pericia.Archivo2;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo2 = destFile;
                            exito2 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                }
            }

            if (_pericia.Archivo3 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo3);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo3);
                Adj3 = _pericia.Archivo3;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo3 = destFile;
                            exito3 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo4 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo4);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo4);
                Adj4 = _pericia.Archivo4;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo4 = destFile;
                            exito4 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo5 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo5);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo5);
                Adj5 = _pericia.Archivo5;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo5 = destFile;
                            exito5 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo6 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo6);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo6);
                Adj6 = _pericia.Archivo6;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo6 = destFile;
                            exito6 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo7 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo7);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo7);
                Adj7 = _pericia.Archivo7;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo7 = destFile;
                            exito7 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo8 != "")
            {
                exito3 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo8);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo8);
                Adj8 = _pericia.Archivo8;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo8 = destFile;
                            exito8 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo9 != "")
            {
                exito9 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo9);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo9);
                Adj9 = _pericia.Archivo9;
                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo9 = destFile;
                            exito9 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (_pericia.Archivo10 != "")
            {
                exito10 = false;
                string NombreArchivo = System.IO.Path.GetFileName(_pericia.Archivo10);
                string sourcePath = System.IO.Path.GetDirectoryName(_pericia.Archivo10);
                Adj10 = _pericia.Archivo10;

                CarpetaDestino carpeta = new CarpetaDestino();
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
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        if (fileName == NombreArchivo)
                        {
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            _pericia.Archivo10 = destFile;
                            exito10 = true;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
            }
            if (exito1 == true || exito2 == true || exito3 == true || exito4 == true || exito5 == true || exito6 == true || exito7 == true || exito8 == true || exito9 == true || exito10 == true)
                exito = true;
            return exito;
        }
    }
}




