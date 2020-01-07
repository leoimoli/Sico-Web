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
        public static int EsEditar;
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
            if (Dni != "")
            {
                SubCliente = ClienteNeg.BuscarSubClientePorDni(Dni, cuit);
            }
            if (ApellidoNombre != "")
            {
                SubCliente = ClienteNeg.BuscarSubClientePorApellido(ApellidoNombre, cuit);
            }
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
                    case "Ver":
                        this.Ver(Convert.ToInt32(e.CommandArgument)); break;
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
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                BloquearFiltrosDeBusqueda();
                HabilitarCamposNuevoSub();
            }
            catch (Exception ex)
            { }
        }
        private void BloquearFiltrosDeBusqueda()
        {
            txtDni.Enabled = false;
            txtApellido.Enabled = false;
            btnBuscar.Enabled = false;
        }
        private void HabilitarCamposNuevoSub()
        {
            lblDniNuevo.Visible = true;
            txtDniNuevo.Visible = true;
            lblApellidoNombreNuevo.Visible = true;
            txtApellidoNombreNuevo.Visible = true;
            lblCalleNuevo.Visible = true;
            txtCalle.Visible = true;
            lblAlturaNuevo.Visible = true;
            txtAltura.Visible = true;
            txtObservaciones.Visible = true;
            lblObservacionesNuevo.Visible = true;
            btnNuevo.Visible = true;
            btnLimpiar.Visible = true;
            btnGuardar.Visible = true;
            lblNuevoSubCliente.Visible = true;
            txtDniNuevo.Focus();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Sico.Entidades.SubCliente _subCliente = CargarEntidad();
                var cuit = lblCuit.Text;
               if(EsEditar == 1)
                {
                    bool Exito = ClienteNeg.EditarSubCliente(_subCliente, cuit);
                    if (Exito == true)
                    {

                        ShowMessage("Se Edito exitosamente el Sub-Cliente ingresado.", "Éxito");
                        //LimpiarCampos();
                    }
                    else
                    {

                    }
                }
                else
                {
                    bool Exito = ClienteNeg.GuardarNuevoSubCliente(_subCliente, cuit);
                    if (Exito == true)
                    {
                        ShowMessage("Se registro exitosamente el Sub-Cliente ingresado.", "Success");
                        //LimpiarCampos();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private SubCliente CargarEntidad()
        {
            SubCliente _subCliente = new SubCliente();
            _subCliente.Dni = txtDniNuevo.Text;
            _subCliente.ApellidoNombre = txtApellidoNombreNuevo.Text;
            _subCliente.Direccion = txtCalle.Text + " " + txtAltura.Text;
            _subCliente.Observacion = txtObservaciones.Text;
            return _subCliente;
        }
        private void Ver(int posicion)
        {
            IList<SubCliente> Subclientes = Session["usuarios"] as IList<SubCliente>;
            this.Session["usuarios"] = Subclientes[posicion];
            EsEditar = 1;
            txtDniNuevo.Text = Subclientes[posicion].Dni;
            txtApellidoNombreNuevo.Text = Subclientes[posicion].ApellidoNombre;
            /////// Separo el domicilio en 2 partes
            string dir = Subclientes[posicion].Direccion;
            var split3 = dir.Split(' ')[0];
            split3 = split3.Trim();

            string dir2 = Subclientes[posicion].Direccion;
            int cantidad2 = dir2.Split().Count();
            string valor2 = "";
            string valorFinal2 = "";
            for (int i = 1; i < cantidad2; i++)
            {
                var split4 = dir2.Split(' ')[i];

                string split = split4.Trim();

                valorFinal2 = valor2 + " " + split4;
                valor2 = split;
            }
            txtCalle.Text = split3;
            txtAltura.Text = valorFinal2;
            if (Subclientes[posicion].Observacion != "")
            {
                txtObservaciones.Text = Subclientes[posicion].Observacion;
            }
            HabilitarCamposNuevoSub();
        }
        protected void ShowMessage(string Message, string type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
    }
}