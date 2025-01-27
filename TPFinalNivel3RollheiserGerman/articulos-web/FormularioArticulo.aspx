﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="articulos_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarcas" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategorias" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnEliminar" CssClass="btn btn-warning" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        <a href="Administracion.aspx" class="btn btn-danger">Cancelar</a>
                    </div>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:Label ID="lblConfirmarEliminacion" class="form-label" runat="server" Text="¿Desea eliminar el artículo?"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <asp:CheckBox ID="chkConfirmar" CssClass="form-check-inline" runat="server" />
                        <asp:Button ID="btnConfirmar" CssClass="btn btn-outline-danger" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgArticulo" CssClass="mx-auto d-block" ImageUrl="https://i.pinimg.com/474x/e8/ee/07/e8ee0728e1ba12edd484c111c1f492f2.jpg" Width="40%" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
