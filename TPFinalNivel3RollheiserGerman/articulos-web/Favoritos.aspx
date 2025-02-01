<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="articulos_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mis favoritos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-warning" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <a href="Perfil.aspx" class="btn btn-success">Editar Perfil</a>
                <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
            </div>
        </div>
    </div>
    <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
</asp:Content>
