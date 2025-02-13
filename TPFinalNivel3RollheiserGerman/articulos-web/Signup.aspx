<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="articulos_web.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
    </style>
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
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" Required runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Email es un campo requerido." ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="No ingresó un formato email. Ejemplo: hola@gmail.com" ControlToValidate="txtEmail" 
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" Required runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Password es un campo requerido." ControlToValidate="txtPass" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ControlToValidate="txtPass" ValidationExpression="^[\s\S]{3,20}$"
                    runat="server" ErrorMessage="Mínimo 3 caracteres. Máximo 20 caracteres."></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtPassConfirmar" class="form-label">Confirmar password</label>
                <asp:TextBox ID="txtPassConfirmar" TextMode="Password" CssClass="form-control" Required runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Confirmar password es un campo requerido." ControlToValidate="txtPassConfirmar" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ControlToValidate="txtPassConfirmar" ValidationExpression="^[\s\S]{3,20}$"
                    runat="server" ErrorMessage="Mínimo 3 caracteres. Máximo 20 caracteres."></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="imagenPerfil" class="form-label">Imagen de perfil</label>
                <input type="file" id="imagenPerfil" runat="server" class="form-control" autopostback="true" onchange="previewImg(this);" maxlength="500" />
                <div class="mb-3"></div>
                <asp:Image ID="imgNuevoPerfil" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
                    CssClass="object-fit-contain" ImageUrl="https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png" Width="100%" Height="375" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
