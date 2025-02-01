<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="articulos_web.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>Registrate</h1>
    <div class="row">
        <div class="col-6">
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
                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassConfirmar" class="form-label">Confirmar password</label>
                <asp:TextBox ID="txtPassConfirmar" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="imagenPerfil" class="form-label">Imagen de perfil</label>
                <input type="file" id="imagenPerfil" runat="server" class="form-control" autopostback="true" onchange="previewImg(this);" />
                <div class="mb-3"></div>
                <asp:Image ID="imgNuevoPerfil" onerror="this.onload = null; this.src='https://icon-library.com/images/no-profile-pic-icon/no-profile-pic-icon-11.jpg';"
                    CssClass="object-fit-contain" ImageUrl="https://icon-library.com/images/no-profile-pic-icon/no-profile-pic-icon-11.jpg" Width="100%" Height="320" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
