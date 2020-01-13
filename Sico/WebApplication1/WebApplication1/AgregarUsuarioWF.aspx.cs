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
    public partial class AgregarUsuarioWF : System.Web.UI.Page
    {
        /// /////// Funciones
        //// 0 = Guardar
        //// 2 = Editar
        //// 3 = Eliminar
        public static Usuario _usuarioLoginSeleccionado { get; set; }
        public Usuario UsuarioLogin { get; set; }
        public Usuario UsuarioSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogin = (Usuario)HttpContext.Current.Session["loginUsuario"];
            UsuarioSeleccionado = (Usuario)HttpContext.Current.Session["usuariosSeleccionado"];
            ///// Editar Usuario Seleccionado.
            if (UsuarioSeleccionado.Funcion == 2 & !Page.IsPostBack)
            {
                UsuarioLogin = (Usuario)HttpContext.Current.Session["loginUsuario"];
                if (UsuarioLogin.Perfil == "OPERADOR")
                {
                    HabilitarCamposEditar(UsuarioSeleccionado);
                    txtContraseña.Enabled = false;
                    txtRepitaContraseña.Enabled = false;
                }
                if (UsuarioLogin.Perfil == "ADMINISTRADOR")
                {
                    HabilitarCamposEditar(UsuarioSeleccionado);
                    txtContraseña.Enabled = true;
                    txtRepitaContraseña.Enabled = true;
                }
                _usuarioLoginSeleccionado = UsuarioLogin;
            }
            ///// Crear nuevo Usuario.
            if (UsuarioSeleccionado.Funcion == 0 & !Page.IsPostBack)
            {
                if (UsuarioLogin.Perfil == "OPERADOR")
                {
                    cmbPerfil.Items.Add("OPERADOR");
                }
                else { CargarComboPerfil(); }
                txtDNI.Focus();
                _usuarioLoginSeleccionado = UsuarioLogin;
            }
        }
        private void HabilitarCamposEditar(Usuario usuarioSeleccionado)
        {
            txtDNI.Text = usuarioSeleccionado.Dni;
            txtApellido.Text = usuarioSeleccionado.Apellido;
            txtNombre.Text = usuarioSeleccionado.Nombre;
            txtFecha.Text = Convert.ToString(usuarioSeleccionado.FechaDeNacimiento);
            cmbPerfil.Items.Add(usuarioSeleccionado.Perfil);
            txtContraseña.Text = usuarioSeleccionado.Contraseña;
            txtRepitaContraseña.Text = usuarioSeleccionado.Contraseña;
        }
        private void CargarComboPerfil()
        {
            string[] Perfiles = Sico.Clases_Maestras.ValoresConstantes.Perfiles;
            cmbPerfil.Items.Add("Seleccione");
            cmbPerfil.Items.Clear();
            foreach (string item in Perfiles)
            {
                cmbPerfil.Text = "Seleccione";
                cmbPerfil.Items.Add(item);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Sico.Entidades.Usuario _usuario = CargarEntidad();

                if (UsuarioSeleccionado.Funcion == 2)
                {
                    bool Exito = UsuarioNeg.EditarUsuario(_usuario);
                    if (Exito == true)
                    {
                        LimpiarCampos();
                    }
                }
                else
                {
                    bool Exito = UsuarioNeg.GurdarUsuario(_usuario);
                    if (Exito == true)
                    {
                        LimpiarCampos();
                    }
                    else
                    {

                    }
                }
            }
            catch { }
        }
        private void LimpiarCampos()
        {
            txtDNI.Text = null;
            txtApellido.Text = null;
            txtNombre.Text = null;
            txtContraseña.Text = null;
            txtRepitaContraseña.Text = null;
            txtFecha.Text = null;
            CargarComboPerfil();
        }
        private Usuario CargarEntidad()
        {
            Usuario _usuario = new Usuario();
            _usuario.Dni = txtDNI.Text;
            _usuario.Apellido = txtApellido.Text;
            _usuario.Nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            _usuario.FechaDeNacimiento = fecha;
            DateTime fechaActual = DateTime.Now;
            _usuario.FechaDeAlta = fechaActual;
            _usuario.FechaUltimaConexion = fechaActual;
            _usuario.Perfil = cmbPerfil.Text;
            _usuario.Estado = "ACTIVO";
            _usuario.Contraseña = txtContraseña.Text;
            _usuario.Contraseña2 = txtRepitaContraseña.Text;
            return _usuario;
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposEscritos();
        }
        private void LimpiarCamposEscritos()
        {
            txtDNI.Text = null;
            txtApellido.Text = null;
            txtNombre.Text = null;
            txtContraseña.Text = null;
            txtRepitaContraseña.Text = null;
            txtFecha.Text = null;
        }
    }
}