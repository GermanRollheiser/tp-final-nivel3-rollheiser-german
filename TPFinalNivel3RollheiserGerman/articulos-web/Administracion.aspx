<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="articulos_web.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Administración de artículos</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6"></div>
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Filtrar" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
                </div>
            </div>
            <div class="row">
                <div class="col-6"></div>
                <div class="mb-3">
                    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        </Columns>
                    </asp:GridView>
                    <a href="FormularioArticulo.aspx">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="Default.aspx">Volver al catálogo</a>
</asp:Content>
