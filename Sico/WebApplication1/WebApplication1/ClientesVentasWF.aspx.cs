using Sico.Entidades;
using Sico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WebApplication1
{
    public partial class ClientesVentasWF : System.Web.UI.Page
    {
        /// /////// Funciones
        //// 0 = Guardar
        //// 1 = Ver
        //// 2 = Editar
        //// 3 = Eliminar
        public static Cliente _clienteSeleccionado { get; set; }
        public Cliente ClienteSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteSeleccionado = (Cliente)HttpContext.Current.Session["usuarios"];
                lblCliente.Text = ClienteSeleccionado.NombreRazonSocial;
                lblCuit.Text = ClienteSeleccionado.Cuit;
                List<Sico.Entidades.SubCliente> ListaFacturas = new List<Sico.Entidades.SubCliente>();
                ListaFacturas = ClienteNeg.BuscarTodasFacturasSubCliente(ClienteSeleccionado.Cuit);
                if (ListaFacturas.Count > 0)
                {
                    this.Session["usuarios"] = ListaFacturas;
                    this.gvVentas.DataSource = ListaFacturas;
                    this.gvVentas.DataBind();
                    this.lblTotalRegistros.Text = ListaFacturas.Count.ToString();
                }
                _clienteSeleccionado = ClienteSeleccionado;
            }
            else
            {

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
            int idSub = Subclientes[posicion].idSubCliente;
            _clienteSeleccionado.Funcion = 2;
            _clienteSeleccionado.idSubCliente = idSub;
            this.Session["usuarios"] = _clienteSeleccionado;
            Response.Redirect("~/FacturacionWF.aspx");
        }
        private void Ver(int posicion)
        {
            IList<SubCliente> Subclientes = Session["usuarios"] as IList<SubCliente>;
            int idSub = Subclientes[posicion].idSubCliente;
            _clienteSeleccionado.Funcion = 1;
            _clienteSeleccionado.idSubCliente = idSub;
            this.Session["usuarios"] = _clienteSeleccionado;
            Response.Redirect("~/FacturacionWF.aspx");
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
        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            List<Sico.Entidades.SubCliente> ListaFacturas = new List<Sico.Entidades.SubCliente>();
            try
            {
                if (txtBuscarPorNombreRazonSocial.Text != "")
                {
                    var ApellidoNombre = txtBuscarPorNombreRazonSocial.Text;
                    ListaFacturas = ClienteNeg.BuscarSubClientePorApellidoNombre(txtBuscarPorNombreRazonSocial.Text, lblCuit.Text);
                    if (ListaFacturas.Count > 0)
                    {
                        this.Session["usuarios"] = ListaFacturas;
                        this.gvVentas.DataSource = ListaFacturas;
                        this.gvVentas.DataBind();
                        this.lblTotalRegistros.Text = ListaFacturas.Count.ToString();
                    }
                }
                if (txtNroFactura.Text != "" & txtBuscarPorNombreRazonSocial.Text == "")
                {
                    var ApellidoNombre = txtBuscarPorNombreRazonSocial.Text;
                    ListaFacturas = ClienteNeg.BuscarSubClientePorNroFactura(txtNroFactura.Text, lblCuit.Text);
                    if (ListaFacturas.Count > 0)
                    {
                        this.Session["usuarios"] = ListaFacturas;
                        this.gvVentas.DataSource = ListaFacturas;
                        this.gvVentas.DataBind();
                        this.lblTotalRegistros.Text = ListaFacturas.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnFacturaB_Click(object sender, EventArgs e)
        {
            string cuit = lblCuit.Text;
            ///// Indico la funcion que esta enviando. En este caso esta queriendo generar un nuevo comprobante.
            _clienteSeleccionado.Funcion = 0;
            this.Session["usuarios"] = _clienteSeleccionado;
            Response.Redirect("~/FacturacionWF.aspx");
        }
        protected void btnNotaDeCredito_Click(object sender, EventArgs e)
        {
            string cuit = lblCuit.Text;
            ///// Indico la funcion que esta enviando. En este caso esta queriendo generar un nuevo ota de Credito.
            _clienteSeleccionado.Funcion = 2;
            this.Session["usuarios"] = _clienteSeleccionado;
            Response.Redirect("~/FacturacionWF.aspx");
        }
    }
}