using Sico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class InicioWF : System.Web.UI.Page
    {
        public Usuario UsuarioLogin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogin = (Usuario)HttpContext.Current.Session["loginUsuario"];
        }
    }
}