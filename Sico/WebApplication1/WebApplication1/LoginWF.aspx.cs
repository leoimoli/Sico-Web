using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sico.Entidades;
using Sico.Negocio;

namespace WebApplication1
{
    public partial class LoginWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnLogin_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                string usuario = txtDni.Text;
                string contraseña = txtClave.Text;
                usuarios = UsuarioNeg.LoginUsuario(usuario, contraseña);
                if (usuarios.Count == 0)
                {
                    throw new Exception("El usuario ingresado/contraseña incorrecta.");
                }
                else
                {
                    //IList<Usuario> usuariLogin = Session["usuarios"] as IList<Usuario>;
                    HttpContext.Current.Session["loginUsuario"] = usuarios.First();
                    Response.Redirect("~/InicioWF.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}