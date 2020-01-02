using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Clases_Maestras;



public partial class MensajeDeDialogoWUC : System.Web.UI.UserControl, IMensajeDeDialogo
{
    /// <summary>
    /// Representa un path hacia una imagen
    /// </summary>
    private string imagenURL;

    #region IMensajeDeDialogo Members

    /// <summary>
    /// Establece la im&#225;gen y muestra el cuadro de di&#225;logo
    /// </summary>
    /// <param name="tipoDeMensaje">El tipo de mensaje a mostrar</param>
    /// <param name="mensaje">El mensaje a mostrar</param>
    public void MostrarMensajeDialogo(WebApplication1.Clases_Maestras.Enumeraciones.TipoDeMensaje tipoDeMensaje, string mensaje)
    {

        switch (tipoDeMensaje)
        {
            case Enumeraciones.TipoDeMensaje.Informacion:
                imagenURL = "C:/Users/limoli/Source/Repos/Sico-Web/Sico/WebApplication1/WebApplication1/App_Themes/imagenes/info.png";
                break;
            case Enumeraciones.TipoDeMensaje.Pregunta:
                imagenURL = "C:/Users/limoli/Source/Repos/Sico-Web/Sico/WebApplication1/WebApplication1/App_Themes/imagenes/pregunta.png";
                break;
            case Enumeraciones.TipoDeMensaje.Error:
                imagenURL = "C:/Users/limoli/Source/Repos/Sico-Web/Sico/WebApplication1/WebApplication1/App_Themes/imagenes/error.png";
                break;
            default:
                break;
        }

        Imagen.ImageUrl = imagenURL;
        labelMensaje.Text = mensaje;
        //resize();

        ModalPopupExtender.Show();
    }



    /// <summary>
    /// Establece el alto del mensaje
    /// </summary>
    public void resize()
    {
        this.panel.Height = this.labelMensaje.Height;
    }

    #endregion
}
