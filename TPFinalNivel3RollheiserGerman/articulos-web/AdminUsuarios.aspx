<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="articulos_web.AdminUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Administración de usuarios</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Filtrar" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                        <asp:Label ID="lblFiltroAvanzado" class="form-label" runat="server" Text="Filtro Avanzado"></asp:Label>
                    </div>
                </div>
            </div>
            <%if (FiltroAvanzado)
                {%>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-control btn btn-outline-dark dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="OnCampoChange">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" ID="lblCriterio" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control btn btn-outline-dark dropdown-toggle">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" ID="lblFiltro" runat="server"></asp:Label>
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-6">
                </div>
                <div class="mb-3">
                    <asp:GridView ID="dgvUsuarios" runat="server" DataKeyNames="Id" CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                            <asp:BoundField HeaderText="Email" DataField="email" />
                            <asp:BoundField HeaderText="Password" DataField="pass" />
                            <asp:BoundField HeaderText="Tipo de usuario" DataField="tipoUsuario" />
                            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="📝" />
                        </Columns>
                    </asp:GridView>
                    <a href="FormularioUsuario.aspx" class="btn btn-primary">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a class="icon-link icon-link-hover" href="Administracion.aspx"><i class="bi bi-arrow-left"></i>Volver a administración</a>
</asp:Content>
