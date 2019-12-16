﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PeriodoWF.aspx.cs" Inherits="WebApplication1.PeriodoWF" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="Períodos" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
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
                <%--    Datos Cliente--%>
                <div class="row">
                    <div class="col-sm-3">
                    </div>
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Nombre o Razón Social:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                    <asp:Label ID="lblCliente" runat="server" Text="Hola Mundo" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Cuit:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                    <asp:Label ID="lblCuit" runat="server" Text="Hola Mundo" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    Filtros--%>
                <div class="row">
                    <div class="col-sm-3">
                    </div>
                    <div class="col-sm-9">
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Tipo de Transacción:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="cmbTransaccion" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label ID="lblAñoConsulta" runat="server" Text="Año:" Font-Size="Large" ForeColor="SteelBlue"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="cmbAño" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <asp:Button ID="btnBuscar" class="btn btn-primary" Style="display: inline-block;" Width="80px" Height="60px" runat="server" Text="Buscar" Font-Size="Small" OnClick="btnBuscar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="form-group">
                            <asp:GridView ID="gvPeriodos" runat="server" Align="center" AllowPaging="true" AllowSorting="True"
                                SkinID="grilla" PageSize="10" AutoGenerateColumns="False" BackColor="White" BorderWidth="1px"
                                Width="100%" DataKeyNames="idSubCliente" OnRowCommand="gvPeriodos_RowCommand"
                                OnPageIndexChanging="gvPeriodos_PageIndexChanging" Visible="false">
                                <Columns>
                                    <asp:BoundField DataField="idPeriodo" HeaderText="Nro.Identificador">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombrePeriodo" HeaderText="Nombre Período">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="200px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Ano" HeaderText="Año">
                                        <HeaderStyle CssClass="header_grilla" HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle BorderColor="Black" CssClass="item_grilla" HorizontalAlign="left" Width="200px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <div id="totales" class="total">
                                <asp:Label ID="lblTotal" runat="server" CssClass="total" Text="Total:" Visible="false"></asp:Label>
                                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="total" Text="0" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="form-group">
                            <asp:Label ID="lblMensaje" runat="server" Text="No se encontraron resultados para los parametros seleccionados." Font-Size="Large" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div style="padding-left: 580px">
                <asp:Button ID="btnNuevo" class="btn btn-primary" Style="display: inline-block;" Width="110px" Height="61px" runat="server" Text="Nuevo Período" Font-Size="Small" />
            </div>
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="lblAñoNuevo" visible="false">Año:<span class="kv-reqd" visible="false"> (*)</span></label>
                                <asp:DropDownList class="form-control" ID="cmbAñoPeriodo" runat="server" Visible="false"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="lblNombrePeriodo" visible="false">Nombre:<span class="kv-reqd" visible="false"> (*)</span></label>
                                <asp:TextBox class="form-control" ID="txtNombrePeriodo" runat="server" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="padding-left: 460px">
                    <asp:Button ID="btnGuardar" class="btn btn-primary" Style="display: inline-block;" Width="110px" Height="61px" runat="server" Text="Guardar" Font-Size="Small" Visible="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

