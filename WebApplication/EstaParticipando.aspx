<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EstaParticipando.aspx.cs" Inherits="WebApplication.EstaParticipando" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css"> <!-- Iconos de Bootstrap -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container p-4 text-center" style="margin-top: 50px">
     <hr />
     <h1 class="display-4 text-success"><i class="bi bi-trophy"></i>¡FELICITACIONES!</h1>
     <p class="lead">¡Has participado exitosamente por el premio!</p>
         <p class="text-muted">Te enviamos un email a tu correo electrónico con la confirmación del Voucher. Si no lo encuentras en tu bandeja de entrada, por favor revisa la carpeta de spam.</p>
     
     <div class="mt-4"></div>
        <asp:Button ID="Button3" runat="server" class="btn btn-primary btn-lg" OnClick="btn_cerrar" Text="Volver" />        
     </div>
   </div>
    
</asp:Content>
