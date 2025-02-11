<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="articulos_web.FormularioUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script>
        function previewImg(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgNuevoPerfil.ClientID%>').attr('src', e.target.result);
                    $('#<%=imgNuevoPerfil.ClientID%>').show();
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
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
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipos" class="form-label">Tipo de usuario</label>
                <asp:DropDownList ID="ddlTipos" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-warning" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <a href="AdminUsuarios.aspx" class="btn btn-danger">Cancelar</a>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:Label ID="lblConfirmarEliminacion" class="form-label" runat="server" Text="¿Desea eliminar el usuario?"></asp:Label>
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
                <label for="imagenPerfil" class="form-label">Imagen de perfil</label>
                <input type="file" id="imagenPerfil" runat="server" class="form-control" autopostback="true" onchange="previewImg(this);" />
                <div class="mb-3"></div>
                <asp:Image ID="imgNuevoPerfil" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
                    CssClass="object-fit-contain" ImageUrl="https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png" Width="100%" Height="400" runat="server" />
            </div>
        </div>
</asp:Content>
