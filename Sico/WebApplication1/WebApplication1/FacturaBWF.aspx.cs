using Sico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FacturaBWF : System.Web.UI.Page
    {
        public Cliente ClienteSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
                lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
                lblCuit.Text = ClienteSeleccionado.Cuit;
            }
        }
    }
}