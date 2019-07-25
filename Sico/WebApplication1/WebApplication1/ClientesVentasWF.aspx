<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientesVentasWF.aspx.cs" Inherits="WebApplication1.ClientesVentasWF" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
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
                            <asp:Label ID="Label4" runat="server" Text="Ventas" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
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
    <div>
        <div class="row">
            <div class="col-sm-3">
            </div>
            <div class="col-sm-9">
                <div class="row">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Buscar por Nombre o Razón Social:" Font-Size="Large" ForeColor="Black"></asp:Label>
                            <asp:TextBox class="form-control" ID="txtBuscarPorNombreRazonSocial" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Buscar Nro.Factura:" Font-Size="Large" ForeColor="Black"></asp:Label>
                            <asp:TextBox class="form-control" ID="txtNroFactura" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" class="btn btn-primary" Style="display: inline-block;" Width="80px" Height="60px" runat="server" Text="Buscar" Font-Size="Small" OnClick="btnBuscar_Click1"/>
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
                        <div class="form-group">
                            <asp:GridView ID="gvVentas" runat="server" Align="center" AllowPaging="true" AllowSorting="True"
                                SkinID="grilla" PageSize="15" AutoGenerateColumns="False" BackColor="White" BorderWidth="1px"
                                Width="100%" DataKeyNames="idSubCliente" OnRowCommand="gvVentas_RowCommand"
                                OnPageIndexChanging="gvVentas_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="idSubCliente" HeaderText="Nro.Identificador">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="150px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NroFactura" HeaderText="Nro.Factura">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="1000px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="200px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido y Nombre">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="500px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Ver">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="40px" />
                                        <ItemStyle BorderColor="Black" HorizontalAlign="Center" Width="40px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnVer" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="Ver" ImageUrl="App_Themes/imagenes/lupa.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Editar">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="40px" />
                                        <ItemStyle BorderColor="Black" HorizontalAlign="Center" Width="40px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="Editar" ImageUrl="App_Themes/imagenes/editar.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div id="totales" class="total">
                                <asp:Label ID="Label3" runat="server" CssClass="total" Text="Total:"></asp:Label>
                                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="total" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9 col-sm-9 col-xs-9" style="padding-left: 550px">
        <asp:Button ID="btnSubCliente" class="btn btn-primary" Style="display: inline-block;" Width="100px" Height="61px" runat="server" Text="Nuevo Sub-Cliente" Font-Size="Small" />
        <asp:Button ID="btnFacturaB" class="btn btn-primary" Style="display: inline-block;" Width="100px" Height="61px" runat="server" Text="Factura B" Font-Size="Small" OnClick="btnFacturaB_Click" />
        <asp:Button ID="btnNotaDeCredito" class="btn btn-primary" Style="display: inline-block;" Width="100px" Height="61px" runat="server" Text="Nota de Crédito" Font-Size="Small" />
        <asp:Button ID="btnCompras" class="btn btn-primary" Style="display: inline-block;" Width="100px" Height="61px" runat="server" Text="Compras" Font-Size="Small" />
    </div>
</asp:Content>
