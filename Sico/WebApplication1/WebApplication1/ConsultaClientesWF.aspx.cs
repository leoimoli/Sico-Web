using Sico.Entidades;
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
            if (!IsPostBack)
            {
                List<Sico.Entidades.Cliente> ListaClientes = new List<Sico.Entidades.Cliente>();
                ListaClientes = Sico.Negocio.ClienteNeg.BuscarClientes();
                if (ListaClientes.Count > 0)
                {
                    this.Session["usuarios"] = ListaClientes;
                    this.gvClientes.DataSource = ListaClientes;
                    this.gvClientes.DataBind();
                    this.lblTotalRegistros.Text = ListaClientes.Count.ToString();
                }
            }
        }
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                gvClientes.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                int idusuario = (int)gvClientes.SelectedValue;
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
            IList<Cliente> clientes = Session["usuarios"] as IList<Cliente>;
            this.Session["usuarios"] = clientes[posicion];
            Response.Redirect("");
        }
        private void Ver(int posicion)
        {
            IList<Cliente> clientes = Session["usuarios"] as IList<Cliente>;
            this.Session["usuarios"] = clientes[posicion];
            Response.Redirect("~/ClientesWF.aspx");
        }
        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvClientes.DataSource = this.Session["usuarios"];
                gvClientes.PageIndex = e.NewPageIndex;
                gvClientes.SelectedIndex = -1;
                gvClientes.DataBind(); ;
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarClienteWF.aspx");
        }
    }
}