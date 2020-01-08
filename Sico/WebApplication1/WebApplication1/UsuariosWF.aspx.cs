using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UsuariosWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Sico.Entidades.Usuario> ListaUsuarios = new List<Sico.Entidades.Usuario>();
                ListaUsuarios = Sico.Negocio.UsuarioNeg.BuscarUsuarios();
                if (ListaUsuarios.Count > 0)
                {
                    this.Session["usuarios"] = ListaUsuarios;
                    this.gvUsuarios.DataSource = ListaUsuarios;
                    this.gvUsuarios.DataBind();
                    this.lblTotalRegistros.Text = ListaUsuarios.Count.ToString();
                }
            }
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}