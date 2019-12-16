using Sico;
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
    public partial class AgregarClienteWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarComboCondicion();
                CargarComboProvincia();
            }
        }

        #region Funciones
        //private void FuncionesBotonHabilitarBuscar()
        //{
        //    btnHabilitarBuscar.Visible = false;
        //    groupBox3.Visible = true;
        //}
        //private void SoloNumeros(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back);
        //}
        //private void FuncionesBotonCancelar()
        //{
        //    txtNombreRazonSocial.Clear();
        //    txtCuit.Clear();
        //    txtActividad.Clear();
        //    DateTime fecha = DateTime.Now;
        //    dtFechaInscripcion.Value = fecha;
        //    CargarComboCondicion();
        //    groupBox1.Enabled = false;
        //    txtEmail.Clear();
        //    txtCalle.Clear();
        //    txtAltura.Clear();
        //    txtCodigoPostal.Clear();
        //    txtCodArea.Clear();
        //    txtTelefono.Clear();
        //    CargarComboProvincia();
        //    CargarComboLocalidad();
        //}
        //private void FuncionesBotonNuevoCliente()
        //{
        //    chcPorNombreRazonSocial.Checked = false;
        //    chcPorCuit.Checked = false;
        //    txtBuscar.Clear();
        //    groupBox3.Visible = false;
        //    LimpiarCamposBotonNuevoCliente();
        //    groupBox1.Enabled = true;
        //    txtNombreRazonSocial.Focus();
        //    groupBox1.Text = "Nuevo Usuario";
        //    btnHabilitarBuscar.Visible = true;
        //}
        //private void FuncionesBotonEditar()
        //{
        //    groupBox1.Enabled = true;
        //    groupBox1.Text = "Editar Usuario";
        //    txtActividad.Focus();
        //}
        //private void ProgressBar()
        //{
        //    progressBar1.Visible = true;
        //    progressBar1.Maximum = 100000;
        //    progressBar1.Step = 1;

        //    for (int j = 0; j < 100000; j++)
        //    {
        //        Caluculate(j);
        //        progressBar1.PerformStep();
        //    }
        //}
        //private void Caluculate(int i)
        //{
        //    double pow = Math.Pow(i, i);
        //}
        //private void chcPorCuit_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chcPorCuit.Checked == true)
        //    {
        //        txtBuscar.Clear();
        //        txtBuscar.Visible = false;
        //        txtCuitBuscar.Visible = true;
        //        chcPorNombreRazonSocial.Checked = false;
        //        lblDniOApellidoNombre.Text = "Buscar Por Cuit(*):";
        //        txtBuscar.Focus();
        //    }
        //}
        //private void chcPorNombreRazonSocial_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chcPorNombreRazonSocial.Checked == true)
        //    {
        //        txtCuitBuscar.Clear();
        //        txtCuitBuscar.Visible = false;
        //        txtBuscar.Visible = true;
        //        txtBuscar.AutoCompleteCustomSource = Clases_Maestras.AutoCompleteRazonSocial.Autocomplete();
        //        txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
        //        txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //        txtBuscar.Enabled = true;
        //        chcPorCuit.Checked = false;
        //        lblDniOApellidoNombre.Text = "Buscar Por Nombre o Razón Social(*):";
        //        txtBuscar.Focus();
        //    }
        //}
        //private void LimpiarCamposBotonNuevoCliente()
        //{
        //    txtNombreRazonSocial.Clear();
        //    txtCuit.Clear();
        //    txtActividad.Clear();
        //    DateTime fecha = DateTime.Now;
        //    dtFechaInscripcion.Value = fecha;
        //    CargarComboCondicion();
        //    progressBar1.Value = Convert.ToInt32(null);
        //    progressBar1.Visible = false;
        //    groupBox1.Enabled = false;
        //    txtEmail.Clear();
        //    txtCalle.Clear();
        //    txtAltura.Clear();
        //    txtCodigoPostal.Clear();
        //    txtCodArea.Clear();
        //    txtTelefono.Clear();
        //    CargarComboProvincia();
        //    //CargarComboLocalidad();
        //}
        private void CargarComboLocalidad()
        {
            List<string> Localidades = new List<string>();
            Localidades = ClienteNeg.CargarComboLocalidades();
            cmbLocalidad.Items.Clear();
            cmbLocalidad.Text = "Seleccione";
            cmbLocalidad.Items.Add("Seleccione");
            foreach (string item in Localidades)
            {
                cmbLocalidad.Text = "Seleccione";
                cmbLocalidad.Items.Add(item);
            }
        }
        private void CargarComboProvincia()
        {
            List<string> Provincia = new List<string>();
            Provincia = ClienteNeg.CargarComboProvincia();
            cmbProvincia.Items.Clear();
            //cmbProvincia.Text = "Seleccione";
            ListItem item = new ListItem("Seleccione", "0");
            cmbProvincia.Items.Add(item);
            foreach (var prov in Provincia)
            {
                string id = prov.Split(',')[0];
                string nombre = prov.Split(',')[1];
                item = new ListItem(nombre, id);
                cmbProvincia.Items.Add(item);
            }
        }
        private void CargarComboCondicion()
        {
            string[] Condicion = Sico.Clases_Maestras.ValoresConstantes.CondicionAntiAfip;
            cmbCondicionAntiAfip.Items.Add("Seleccione");
            cmbCondicionAntiAfip.Items.Clear();
            foreach (string item in Condicion)
            {
                cmbCondicionAntiAfip.Text = "Seleccione";
                cmbCondicionAntiAfip.Items.Add(item);
            }
        }
        private void LimpiarCampos()
        {
            txtNombreRazonSocial.Text = null;
            txtCuit.Text = null;
            txtActividad.Text = null;
            CargarComboCondicion();
            txtTelefono.Text = null;
            txtEmail.Text = null;
            txtCalle.Text = null;
            txtAltura.Text = null;
            txtCodigoPostal.Text = null;
            txtFecha.Text = null;
            CargarComboProvincia();
            cmbLocalidad.Text = "Seleccione";
        }
        private Cliente CargarEntidad()
        {
            Cliente _cliente = new Cliente();
            _cliente.NombreRazonSocial = txtNombreRazonSocial.Text;
            var cuit = txtCuit.Text;

            double number = Convert.ToDouble(cuit);
            string fmt = "00-00000000-0";
            string CuitFinal = number.ToString(fmt);
            _cliente.Cuit = CuitFinal;
            _cliente.Actividad = txtActividad.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            _cliente.FechaDeInscripcion = fecha;
            _cliente.CondicionAntiAfip = cmbCondicionAntiAfip.Text;
            //string telefono = txtCodArea.Text + "-" + txtTelefono.Text;
            string telefono = txtTelefono.Text;
            _cliente.Telefono = telefono;
            _cliente.Email = txtEmail.Text;
            ////// Datos del domicilio
            _cliente.Provincia = cmbProvincia.Text;
            _cliente.Localidad = cmbLocalidad.Text;
            _cliente.Calle = txtCalle.Text;
            _cliente.Altura = txtAltura.Text;
            _cliente.CodigoPostal = txtCodigoPostal.Text;
            _cliente.idUsuario = ((Usuario)HttpContext.Current.Session["loginUsuario"]).IdUsuario;
            return _cliente;
        }
        #endregion
        public void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string var = cmbProvincia.SelectedValue; //aca ya tenes el id
                if (var != "0")
                {
                    //var split1 = var.Split(',')[0];
                    //split1 = split1.Trim();
                    int idProvinciaSeleccionada = Convert.ToInt32(var);
                    List<string> Localidades = new List<string>();
                    Localidades = ClienteNeg.CargarComboLocalidadesPorIdProvincia(idProvinciaSeleccionada);
                    cmbLocalidad.Items.Clear();
                    cmbLocalidad.Text = "Seleccione";
                    cmbLocalidad.Items.Add("Seleccione");
                    foreach (string item in Localidades)
                    {
                        cmbLocalidad.Text = "Seleccione";
                        cmbLocalidad.Items.Add(item);
                    }
                    this.cmbLocalidad.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            Sico.Entidades.Cliente _cliente = CargarEntidad();
            bool Exito = ClienteNeg.GurdarCliente(_cliente);
            if (Exito == true)
            {
                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "Se registro el cliente exitosamente." + "');";
                msg += "</script>";
                Response.Write(msg);
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "alert('Se registro el cliente exitosamente.');");
                LimpiarCampos();
            }
            else
            {

            }
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
