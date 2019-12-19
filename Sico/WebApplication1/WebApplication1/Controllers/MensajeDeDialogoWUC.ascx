<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeDeDialogoWUC.ascx.cs" Inherits="MensajeDeDialogoWUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
    // <!CDATA[

    function BotonAceptar_onclick() {}
// ]]>
</script>


<asp:HiddenField ID="HiddenField" runat="server" />

<cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField" PopupControlID="panel"
    OkControlID="BotonAceptar" BackgroundCssClass="modalBackground" BehaviorID="popup" />

<asp:Panel ID="panel" runat="server" CssClass="divMensajeDialogoPanel">

    <div id="divContent" class="divDisplayBlock">
        <table>
            <tr>
                <td>
                    <div id="divImagen" class="divMensajeDialogoImagen">
                        <asp:Image ID="Imagen" CssClass="controlMensajeDialogoImagen" runat="server" ImageUrl="~/App_Themes/TemaTransito1/media/info.png" />
                    </div>
                </td>
                <td colspan="2">
                    <div id="divLabelMensaje" class="divMensajeDialogoMensaje">
                        <asp:Label ID="labelMensaje" runat="server" Text="mensaje" CssClass="verdana11"></asp:Label>
                    </div>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <div id="divBotones" class="divDisplayBlock">
                        <input id="BotonAceptar" class="boton90" runat="server" type="button" value="Aceptar" onclick="return BotonAceptar_onclick()" />

                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
