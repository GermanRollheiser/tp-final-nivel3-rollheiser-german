<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle</h1>
    <div class="row border border-2 border-primary-subtle" style="max-width: 600px;">
        <div class="col-4">
            <div class="mb-3">
                <asp:TextBox ID="txtId" CssClass="invisible" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCodigo" Font-Bold="true" runat="server" Text="Código"></asp:Label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control-plaintext" ReadOnly="true" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" Font-Bold="true" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control-plaintext" ReadOnly="true" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMarca" Font-Bold="true" runat="server" Text="Marca"></asp:Label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-control-plaintext form-range" Enabled="false" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblCategoria" Font-Bold="true" runat="server" Text="Categoría"></asp:Label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-control-plaintext form-range" Enabled="false" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPrecio" Font-Bold="true" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control-plaintext" ReadOnly="true" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblDescripcion" Font-Bold="true" runat="server" Text="Descripción"></asp:Label>
                <asp:TextBox ID="txtDescripcion" Style="resize: none" CssClass="form-control-plaintext" ReadOnly="true" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="col">
            <div class="mb-3">
                <asp:TextBox ID="txtImagenUrl" CssClass="invisible" runat="server" AutoPostBack="true" OnLoad="txtImagenUrl_Load"></asp:TextBox>
            </div>
            <asp:Image ID="imgArticulo" onerror="this.onload = null; this.src='https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg';"
                CssClass="object-fit-contain" ImageUrl="https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg" Width="100%" Height="375" runat="server" />
            <div class="mb-3">
                <asp:Label ID="lblFav" Visible="true" class="btn btn-outline-danger invalid-feedback" runat="server" AssociatedControlID="btnFav">
                    <asp:Button ID="btnFav" type="button" runat="server" CssClass="invalid-feedback" OnClick="btnFav_Click"></asp:Button>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16">
                        <path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143q.09.083.176.171a3 3 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15" />
                    </svg>
                </asp:Label>
                <asp:Label ID="lblNoFav" Visible="false" class="btn btn-outline-danger active invalid-feedback" runat="server" AssociatedControlID="btnNoFav">
                    <asp:Button ID="btnNoFav" type="button" runat="server" CssClass="invalid-feedback" OnClick="btnNoFav_Click"></asp:Button>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-heart" viewBox="0 0 16 16">
                        <path d="m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143q.09.083.176.171a3 3 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15" />
                    </svg>
                </asp:Label>
            </div>
        </div>
    </div>
    <br />
    <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
</asp:Content>
