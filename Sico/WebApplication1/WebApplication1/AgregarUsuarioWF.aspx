<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AgregarUsuarioWF.aspx.cs" Inherits="WebApplication1.AgregarUsuarioWF" EnableEventValidation="false" %>

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
                            <asp:Label ID="lblTitulo" runat="server" Text="Nuevo Usuario" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
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
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblDNI">DNI:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtDNI" runat="server" MaxLength="8" Style="text-transform: uppercase"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblApellido">Apellido:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtApellido" runat="server" Style="text-transform: uppercase"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblNombre">Nombre:<span class="kv-reqd"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtNombre" runat="server" Style="text-transform: uppercase"></asp:TextBox>
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
                                <label for="lblFecha">Fecha de Nacimiento:</label>
                                <asp:TextBox class="form-control" ID="txtFecha" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblPerfíl">Perfíl:<span class="kv-reqd"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbPerfil" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
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
                                <label for="lblContraseña">Contraseña:(*)</label>
                                <asp:TextBox class="form-control" ID="txtContraseña" runat="server" Style="text-transform: uppercase" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <label for="lblRepitaContraseña">Repita Contraseña:(*)</label>
                                <asp:TextBox class="form-control" ID="txtRepitaContraseña" runat="server" Style="text-transform: uppercase" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--////// Botones--%>
        <div class="col-md-9 col-sm-9 col-xs-9" style="padding-left: 700px">
            <asp:Button ID="btnLimpiar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            <asp:Button ID="btnGuardar" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
