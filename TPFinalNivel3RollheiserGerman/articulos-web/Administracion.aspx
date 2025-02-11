<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="articulos_web.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administración</h1>
    <div class="row">
        <div class="col-6">
            <div class="col-9 mb-3">
                <a href="AdminArticulos.aspx" style="text-decoration: none">
                    <asp:Image ID="imgAdmArt" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
                        CssClass="object-fit-contain" ImageUrl="https://img.freepik.com/free-vector/illustration-multitasking-person_23-2148405070.jpg" Width="100%" Height="400" runat="server" />
                </a>
            </div>
            <div class="mb-3 display-6 ms-3">
                <asp:Label ID="lblAdmArt" runat="server" Text="Administración de articulos"></asp:Label>
            </div>
        </div>
        <div class="col-6">
            <div class="col-9 mb-3">
                <a href="AdminUsuarios.aspx" style="text-decoration: none">
                    <asp:Image ID="Image1" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
                        CssClass="object-fit-contain" ImageUrl="https://img.freepik.com/vector-premium/icono-vectorial-3d-figura-humana-simple-rojo-que-representa-individualidad-identidad_6011-1479.jpg?semt=ais_hybrid" Width="100%" Height="400" runat="server" />
                </a>
            </div>
            <div class="mb-3 display-6 ms-3">
                <asp:Label ID="lblAdmUs" runat="server" Text="Administración de usuarios"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="mb-3">
            <a class="icon-link icon-link-hover" href="Default.aspx"><i class="bi bi-arrow-left"></i>Volver al catálogo</a>
        </div>
    </div>
</asp:Content>
