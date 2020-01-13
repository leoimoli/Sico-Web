using Sico.Entidades;
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
        public static Usuario UsuarioSeleccionado { get; set; }
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
        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUsuarios.DataSource = this.Session["usuarios"];
                gvUsuarios.PageIndex = e.NewPageIndex;
                gvUsuarios.SelectedIndex = -1;
                gvUsuarios.DataBind(); ;
            }
            catch (Exception ex)
            {

            }
        }
        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                gvUsuarios.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                int idusuario = (int)gvUsuarios.SelectedValue;
                switch (e.CommandName)
                {
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
            IList<Usuario> usuarios = Session["usuarios"] as IList<Usuario>;
            UsuarioSeleccionado = usuarios[posicion];
            int idUsuario = usuarios[posicion].IdUsuario;
            UsuarioSeleccionado.Funcion = 2;
            UsuarioSeleccionado.IdUsuario = idUsuario;
            this.Session["usuariosSeleccionado"] = UsuarioSeleccionado;
            Response.Redirect("~/AgregarUsuarioWF.aspx");
        }
        //private void Ver(int posicion)
        //{
        //    IList<Usuario> usuarios = Session["usuarios"] as IList<Usuario>;
        //    this.Session["usuarios"] = usuarios[posicion];
        //    Response.Redirect("~/ClientesWF.aspx");
        //}
        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}