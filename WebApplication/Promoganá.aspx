<%@ Page Title="Vouchers" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Promoganá.aspx.cs" Inherits="WebApplication.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Canje de vouchers</h2>
    </div>
    
    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" class="form-label" Text="Ingrese cogigo de voucher"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="Vou" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="Canjear" />
            </div>

        </div>
        <div class="col-4"></div>
    </div>
    
</asp:Content>
