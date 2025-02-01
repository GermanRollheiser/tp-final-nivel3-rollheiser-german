<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="articulos_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un problema</h1>
    <div class="row">
        <div class="mb-3">
            <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="mb-3">
            <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
            //Ver funcionalidad para volver a la página anterior o directamente quitar el link y agregar alguna imagen de error
        </div>
    </div>
</asp:Content>
