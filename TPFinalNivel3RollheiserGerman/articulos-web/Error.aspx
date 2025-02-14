<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="articulos_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hubo un problema</h1>
    <div class="row">
        <div class="mb-3">
            <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="mb-3">
            <asp:Image ID="imgError" onerror="this.onload = null; this.src='https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png';"
                CssClass="object-fit-contain" ImageUrl="https://static.vecteezy.com/system/resources/thumbnails/020/371/779/small_2x/confused-business-women-sit-at-laptop-at-workplace-with-coffee-cup-burnout-neurosis-stress-error-concept-png.png" Width="100%" Height="400" runat="server" />
        </div>
        <div class="mb-3">
            <a class="icon-link icon-link-hover" href="##" onClick="history.go(-1); return false;"><i class="bi bi-arrow-left"></i>Volver</a>
        </div>
    </div>
</asp:Content>
