<%@ Page Title="Error" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Incorrecto.aspx.cs" Inherits="WebApplication.Incorrecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container p-4 text-center" style="margin-top: 50px">
        <hr />
        <%if (Session["error"].ToString() == "1")
            { %>
        <h1>Voucher nulo</h1>
        <p>No se ingreso ningun codigo</p>
        <asp:Button ID="Button3" runat="server" class="btn btn-secondary" OnClick="Button1_Click" Text="Volver" />
        <%  }
        if (Session["error"].ToString() == "2")
            { %>
        <h1>Voucher invalido</h1>
        <p>El codigo ingresado ya ha sido utilizado</p>
        <asp:Button ID="Button1" runat="server" class="btn btn-secondary" OnClick="Button1_Click" Text="Volver" />

        <%  } 
        
        if(Session["error"].ToString() == "3")
            {%>
        <h1>Voucher inexistente</h1>
        <p>El codigo ingresado no existe</p>
        <asp:Button ID="Button2" runat="server" class="btn btn-secondary" OnClick="Button1_Click" Text="Volver" />
        <%  }%>

        
      
    </div>
    
</asp:Content>

