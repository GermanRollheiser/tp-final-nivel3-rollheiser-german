<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="articulos_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Mis favoritos</h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row" style="max-width: 540px;">
                <asp:Repeater ID="repRepetidor" runat="server">
                    <ItemTemplate>
                        <div class="card border-2 border-primary-subtle">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="<%#Eval("ImagenUrl") %>" onerror="this.onerror=null;this.src='https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg';"
                                        class="object-fit-contain" style="width: 100%; height: 220px" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title d-inline align-text-top"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Marca") %></p>
                                        <p class="card-text"><%#Eval("Categoria") %></p>
                                        <p class="card-text"><%#Eval("Precio") %></p>
                                        <a class="btn btn-primary" href="Detalle.aspx?id=<%#Eval("ID") %>">Detalle</a>
                                        <asp:Button ID="btnNoFav" type="button" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                                            CommandArgument='<%#Eval("ID") %>' CommandName="ArticuloID" OnClick="btnNoFav_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Image ID="imgListaVacia" Visible="false" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
    CssClass="object-fit-contain" ImageUrl="https://ebed.in/images/noitem.png" Width="100%" Height="400" runat="server" />
    <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
</asp:Content>
