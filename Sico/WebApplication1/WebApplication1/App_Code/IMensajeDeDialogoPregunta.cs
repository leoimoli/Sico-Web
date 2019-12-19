using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Interfaz que debe implementar un control para mostrar un mensaje.
/// </summary>
public interface IMensajeDeDialogoPregunta
{
    void MostrarMensajeDeDialogoPregunta(WebApplication1.Clases_Maestras.Enumeraciones.TipoDeMensaje tipoDeMensaje, string mensaje);
}
