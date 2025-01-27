<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-6">
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" placeholder="Buscar" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
                <div class="form-check form-check-inline icon-link form-check-reverse">
                    <asp:RadioButton ID="rdbNombre" Text="Nombre" runat="server" GroupName="Filtros" Checked="true" />
                </div>
                <div class="form-check form-check-inline icon-link form-check-reverse">
                    <asp:RadioButton ID="rdbMarca" Text="Marca" runat="server" GroupName="Filtros" />
                </div>
                <div class="form-check form-check-inline icon-link form-check-reverse">
                    <asp:RadioButton ID="rdbCategoria" Text="Categoría" runat="server" GroupName="Filtros" />
                </div>
            </div>
        </div>
        <div class="col">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <div class="input-group">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Marca") %></p>
                            <p class="card-text"><%#Eval("Categoria") %></p>
                            <p class="card-text"><%#Eval("Precio") %></p>
                            <a href="Detalle.aspx?id=<%#Eval("ID") %>">Detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
