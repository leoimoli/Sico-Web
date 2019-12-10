<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AgregarClienteWF.aspx.cs" Inherits="WebApplication1.AgregarClienteWF" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="row">
            <div class="col-sm-3">
            </div>
            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-1">
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Clientes" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
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
                <div class="col-sm-12">
                    <%--   <label for="lblTitulo" style="font-size: x-large; color: steelblue"">Agregar Clientes</label>--%>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRazonSocial">Nombre/Razon Social:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtNombreRazonSocial" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCuit">Cuit:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtCuit" runat="server" MaxLength="11"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblActividad">Actividad:</label>
                                <asp:TextBox class="form-control" ID="txtActividad" runat="server"></asp:TextBox>
                                <%-- <input type="text" class="form-control" id="txtActividad">--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblFecha">Fecha:</label>
                                <asp:TextBox class="form-control" ID="txtFecha" runat="server" placeholder="yyyy-mm-dd" onkeyup="var date = this.value;if (date.match(/^\d{4}$/) !== null) {this.value = date + '-';} else if (date.match(/^\d{4}\-\d{2}$/) !== null) {this.value = date + '-';}" MaxLength="10"></asp:TextBox>
                                <%--<input type="text"  name="date" placeholder="yyyy-mm-dd" onkeyup="var date = this.value;if (date.match(/^\d{4}$/) !== null) {this.value = date + '-';} else if (date.match(/^\d{4}\-\d{2}$/) !== null) {this.value = date + '-';}" maxlength="10">--%>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCondicionAntiAfip">Con.Anti-Afip:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbCondicionAntiAfip" runat="server"></asp:DropDownList>
                                <%--    <input type="text" class="form-control" id="cmbCondicionAntiAfip">--%>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblTelefono">Telefono:</label>
                                <asp:TextBox class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                                <%--  <input type="text" class="form-control" id="txtTelefono">--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-9">
                            <div class="form-group">
                                <label for="lblEmail">Email:</label>
                                <asp:TextBox class="form-control" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  Domicilio--%>
        <div>
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblProvincia">Provincia:</label>
                                <asp:DropDownList ID="cmbProvincia" runat="server" class="form-control" OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <%--    <asp:DropDownList ID="ddlUsuarios" runat="server" Height="25px" Width="700px" CssClass="form-control-solid text" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>--%>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblLocalidad">Localidad:</label>
                                <asp:DropDownList class="form-control" ID="cmbLocalidad" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCodigoPostal">Código Postal:</label>
                                <asp:TextBox class="form-control" ID="txtCodigoPostal" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblCalle">Calle:</label>
                                <asp:TextBox class="form-control" ID="txtCalle" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblAltura">Altura:</label>
                                <asp:TextBox class="form-control" ID="txtAltura" runat="server"></asp:TextBox>
                                <%--  <input type="text" class="form-control" id="txtTelefono">--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--////// Botones--%>
        <div class="col-md-9 col-sm-9 col-xs-9" style="padding-left: 700px">
            <asp:Button ID="btnLimpiar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            <asp:Button ID="btnGuardar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Guardar" OnClick="btnGuardar_Click1" />
        </div>
    </div>
</asp:Content>
