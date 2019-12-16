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
    public partial class AgregarSubClienteWF : System.Web.UI.Page
    {
        public static Cliente _clienteSeleccionado { get; set; }
        public Cliente ClienteSeleccionado { get; set; }
        public static decimal Total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
                lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
                lblCuit.Text = ClienteSeleccionado.Cuit;
                try
                {
                    //CargarCombo();
                    Total = 0;
                }
                catch (Exception ex)
                { }
            }       
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Sico.Entidades.SubCliente> SubCliente = new List<Sico.Entidades.SubCliente>();
            var ApellidoNombre = txtApellido.Text;
            var Dni = txtDni.Text;
            var cuit = lblCuit.Text;
            SubCliente = ClienteNeg.BuscarSubClientePorApellidoNombre(ApellidoNombre, cuit);
            if (SubCliente.Count > 0)
            {
                this.gvSubClientes.Visible = true;
                lblMensaje.Visible = false;
                this.Session["usuarios"] = SubCliente;
                this.gvSubClientes.DataSource = SubCliente;
                this.gvSubClientes.DataBind();
                this.lblTotalRegistros.Text = SubCliente.Count.ToString();
                lblTotal.Visible = true;
                lblTotalRegistros.Visible = true;
            }
            else
            {
                txtApellido = null;
                string msg = "<script language=\"javascript\">";
                msg += "Atencion('" + "No se encontraron datos para el sub-cliente ingresado." + "');";
                msg += "</script>";
                Response.Write(msg);
            }
        }
        protected void gvSubClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                gvSubClientes.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                int idSubCliente = (int)gvSubClientes.SelectedValue;
                switch (e.CommandName)
                {
                    //case "Ver":
                    //    this.Ver(Convert.ToInt32(e.CommandArgument)); break;
                    //case "Editar":
                    //    this.Editar(Convert.ToInt32(e.CommandArgument)); break;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void gvSubClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvSubClientes.DataSource = this.Session["usuarios"];
                gvSubClientes.PageIndex = e.NewPageIndex;
                gvSubClientes.SelectedIndex = -1;
                gvSubClientes.DataBind(); ;
            }
            catch (Exception ex)
            {

            }
        }
    }
}