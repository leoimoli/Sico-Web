using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ConsultaClientesWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Sico.Entidades.Cliente> ListaClientes = new List<Sico.Entidades.Cliente>();
            ListaClientes = Sico.Negocio.ClienteNeg.BuscarClientes();
            if (ListaClientes.Count > 0)
            {
                //GridView1.Columns.Add(new BoundField { DataField = "IdCliente", DataFormatString = "My Data is: {0}" });
                //GridView1.DataSource = ListaClientes; // where your datasource contains your additional records
                //GridView1.DataBind();
            }
        }

        public List<Sico.Entidades.Cliente> ListaClientes
        {
            set
            {
                if (value.Count > 0)
                {
                    GridView1.DataSource = value;
                    GridView1.Columns[0].HeaderText = "Id Movimiento";
                    GridView1.Columns[1].HeaderText = "Id Movimiento";
                    GridView1.Columns[2].HeaderText = "Id Movimiento";
                    GridView1.Columns[3].HeaderText = "Id Movimiento";
                    GridView1.Columns[4].HeaderText = "Id Movimiento";
                    GridView1.Columns[5].HeaderText = "Id Movimiento";
                    //GridView1.Columns[0].Width = 130;
                    //GridView1.Columns[0].HeaderCell.Style.BackColor = Color.DarkBlue;
                    //GridView1.Columns[0].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    //GridView1.Columns[0].HeaderCell.Style.ForeColor = Color.White;
                }
            }
        }
    }
}