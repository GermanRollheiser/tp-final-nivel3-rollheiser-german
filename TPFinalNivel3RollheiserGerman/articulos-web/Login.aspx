<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="articulos_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-6">
            <h1>Iniciar sesión</h1>
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
                <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                <a href="Default.aspx" class="btn btn-danger">Cancelar</a>
            </div>
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
