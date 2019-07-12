using MySql.Data.MySqlClient;
//using Sico.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;


namespace Sico.Clases_Maestras
{
    public class AutoCompleteSubCliente
    {
        //public static DataTable Datos(int idCliente)
        //{
        //    DataTable dt = new DataTable();
        //    MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.db);
        //    conexion.Open();
        //    int id = idCliente;
        //    string consulta = "Select ApellidoNombre from subcliente where idCliente = '"+ id +"'";
        //    MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        //    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //    adap.Fill(dt);
        //    conexion.Close();
        //    return dt;
        //}
        //public static AutoCompleteStringCollection Autocomplete(string cuit)
        //{
        //    int idCliente = ClienteDao.BuscarIdClientePorCuit(cuit);
        //    DataTable DT = Datos(idCliente);
        //    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
        //    foreach (DataRow row in DT.Rows)
        //    {
        //        coleccion.Add(Convert.ToString(row["ApellidoNombre"]));
        //    }
        //    return coleccion;
        //}
    }
}
