<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EstaParticipando.aspx.cs" Inherits="WebApplication.EstaParticipando" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container p-4 text-center" style="margin-top: 50px">
     <hr />
     <h1>¡FELICITACIONES!</h1>
     <p>Usted esta participando por el premio</p>
     <asp:Button ID="Button3" runat="server" class="btn btn-primary" OnClick="btn_cerrar" Text="Volver" />        
     </div>

    
</asp:Content>
