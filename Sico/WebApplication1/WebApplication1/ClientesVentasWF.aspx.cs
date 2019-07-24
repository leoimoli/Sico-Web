using Sico.Entidades;
using Sico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ClientesVentasWF : System.Web.UI.Page
    {
        public Cliente ClienteSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Sico.Entidades.SubCliente> ListaFacturas = new List<Sico.Entidades.SubCliente>();
            ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
            lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
            lblCuit.Text = ClienteSeleccionado.Cuit;
            if (!IsPostBack)
            {
                ListaFacturas = ClienteNeg.BuscarTodasFacturasSubCliente(ClienteSeleccionado.Cuit);
                if (ListaFacturas.Count > 0)
                {
                    this.Session["usuarios"] = ListaFacturas;
                    this.gvVentas.DataSource = ListaFacturas;
                    this.gvVentas.DataBind();
                    this.lblTotalRegistros.Text = ListaFacturas.Count.ToString();
                }
            }
        }
        protected void gvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                gvVentas.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                int idSubCliente = (int)gvVentas.SelectedValue;
                switch (e.CommandName)
                {
                    case "Ver":
                        this.Ver(Convert.ToInt32(e.CommandArgument)); break;
                    case "Editar":
                        this.Editar(Convert.ToInt32(e.CommandArgument)); break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Editar(int posicion)
        {
            IList<SubCliente> Subclientes = Session["usuarios"] as IList<SubCliente>;
            this.Session["usuarios"] = Subclientes[posicion];
            Response.Redirect("");
        }

        private void Ver(int posicion)
        {
            IList<SubCliente> Subclientes = Session["usuarios"] as IList<SubCliente>;
            this.Session["usuarios"] = Subclientes[posicion];
            Response.Redirect("~/ClientesWF.aspx");
        }
        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVentas.DataSource = this.Session["usuarios"];
                gvVentas.PageIndex = e.NewPageIndex;
                gvVentas.SelectedIndex = -1;
                gvVentas.DataBind(); ;
            }
            catch (Exception ex)
            {

            }
        }
    }
}