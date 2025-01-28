<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="articulos_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle</h1>
    <div class="row">
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
        <div class="col-4">
            <div class="mb-3">
                <asp:TextBox ID="txtImagenUrl" CssClass="invisible" runat="server" AutoPostBack="true" OnLoad="txtImagenUrl_Load"></asp:TextBox>
            </div>
            <asp:Image ID="imgArticulo" onerror="this.onload = null; this.src='https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg';"
                CssClass="object-fit-contain" ImageUrl="https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg" Width="100%" Height="445" runat="server" />
        </div>
    </div>
    <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
</asp:Content>
