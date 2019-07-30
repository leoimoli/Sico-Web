<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FacturaBWF.aspx.cs" Inherits="WebApplication1.FacturaBWF" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
        </div>
        <div class="col-sm-9">
            <div class="row">
                <div class="col-sm-3">
                    <div class="form-group">
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Facturación B" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="form-group">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div class="row">
            <div class="col-sm-3">
            </div>
            <div class="col-sm-9">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Nombre o Razón Social:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                            <asp:Label ID="lblCliente" runat="server" Text="Hola Mundo" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Cuit:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                            <asp:Label ID="lblCuit" runat="server" Text="Hola Mundo" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9 col-sm-9 col-xs-9">
        <div>
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Persona Física:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbPersona" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Button ID="btnNuevo" Style="text-align: end; background-image: url(App_Themes/imagenes/nuevo-usuario.png); background-position: top; display: inline-block;" Width="60px" Height="60px" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCuit">Dni:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="lblDniEdit" runat="server" MaxLength="11"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblActividad">Dirección:</label>
                                <asp:TextBox class="form-control" ID="lblDireccionEdit" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="lblFecha">Observaciones:</label>
                                <asp:TextBox class="form-control" ID="lblObservacionesEdit" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="lblCondicionAntiAfip">Periodo:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbPeriodo" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Button ID="btnNuevoPeriodo" Style="text-align: end; background-image: url(App_Themes/imagenes/nuevas-insignias-de-una-tienda.png); background-position: top; display: inline-block;" Width="60px" Height="60px" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Fecha Comprobante:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="dtFecha" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCuit">Tipo Comprobante:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbTipoComprobante" runat="server"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblActividad">Nro.Factura:</label>
                                <asp:TextBox class="form-control" ID="txtFactura" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <%--  Filas Totales.....--%>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblTotal">Total:</label>
                                <asp:TextBox class="form-control" ID="txtTotal1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblNeto">Neto General:</label>
                                <asp:TextBox class="form-control" ID="txtNeto1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblAlicuota">Alicuota</label>
                                <asp:TextBox class="form-control" ID="lbl105" runat="server" Text="10,5%" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Iva:</label>
                                <asp:TextBox class="form-control" ID="txtIva1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblTotal">Total:</label>
                                <asp:TextBox class="form-control" ID="txtTotal2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblNeto">Neto General:</label>
                                <asp:TextBox class="form-control" ID="txtNeto2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblAlicuota">Alicuota</label>
                                <asp:TextBox class="form-control" ID="lbl21" runat="server" Text="21%" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Iva:</label>
                                <asp:TextBox class="form-control" ID="txtIva2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblTotal">Total:</label>
                                <asp:TextBox class="form-control" ID="txtTotal3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblNeto">Neto General:</label>
                                <asp:TextBox class="form-control" ID="txtNeto3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblAlicuota">Alicuota</label>
                                <asp:TextBox class="form-control" ID="lbl27" runat="server" Text="27%" Enabled="false"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Iva:</label>
                                <asp:TextBox class="form-control" ID="txtIva3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Tipo de Moneda:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbTipoMoneda" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCuit">Tipo De Cambio:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtTipoCambio" runat="server" MaxLength="11"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblActividad">Código Operación:</label>
                                <asp:DropDownList class="form-control" ID="cmbCodigoOperacion" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <div class="form-group">
                                <label for="lblAdjuntar">Adjuntar:</label>
                                <asp:TextBox class="form-control" ID="txtAdjuntar" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Button ID="btnAdjuntar" Style="text-align: end; background-image: url(App_Themes/imagenes/clip-sujetapapeles.png); background-position: top; display: inline-block;" Width="60px" Height="60px" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <div class="form-group">
                                <label for="lblTotal">Total:</label>
                                <asp:TextBox class="form-control" ID="txtTotal" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
    <div class="col-md-9 col-sm-9 col-xs-9" style="padding-left: 800px">
        <asp:Button ID="btnLimpiar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Limpiar" />
        <asp:Button ID="btnGuardar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Guardar" />
    </div>
</asp:Content>
