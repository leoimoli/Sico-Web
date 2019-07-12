using Sico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gym.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public Usuario usuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(((Usuario)HttpContext.Current.Session["loginUsuario"]).IdUsuario);
            usuarioActual = (Usuario)HttpContext.Current.Session["loginUsuario"];
            //lblUsuarioRegistrado.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
        }
    }
}