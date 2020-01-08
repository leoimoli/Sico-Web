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
        public Usuario UsuarioLogin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsuarioLogin = (Usuario)HttpContext.Current.Session["loginUsuario"];
                CargarComboPerfil();
                if (UsuarioLogin.Perfil == "OPERADOR")
                {
                    cmbPerfil.Items.Add("OPERADOR");
                }
                txtDNI.Focus();
            }
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
    }
}