using Sico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ClientesWF : System.Web.UI.Page
    {
        public Cliente ClienteSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
            lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
            lblCuit.Text = ClienteSeleccionado.Cuit;
        }
        protected void btnVentas_Click1(object sender, EventArgs e)
        {
            this.Session["usuarios"] = ClienteSeleccionado;
            Response.Redirect("~/ClientesVentasWF.aspx");
        }
    }
}
