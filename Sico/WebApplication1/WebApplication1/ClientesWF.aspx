<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientesWF.aspx.cs" Inherits="WebApplication1.ClientesWF" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
        </div>
        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-1">
                    <div class="form-group">
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="form-group">
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Cliente" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-4">
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
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Button ID="btnCompras" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Compras" Width="250px" Height="100px" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Button ID="btnVentas" class="btn btn-primary" Style="display: inline-block;" runat="server" Text="Ventas" Width="250px" Height="100px" OnClick="btnVentas_Click1" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
