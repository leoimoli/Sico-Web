using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Clases_Maestras;

/// <summary>
/// Interfaz que debe implementar un control para mostrar un mensaje.
/// </summary>
public interface IMensajeDeDialogo
{
    void MostrarMensajeDialogo(Enumeraciones.TipoDeMensaje tipoDeMensaje, string mensaje);
}
