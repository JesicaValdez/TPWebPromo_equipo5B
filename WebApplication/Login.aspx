<%@ Page Title="Premios" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ingresá tus datos</h1>

    <div>
        <asp:Label ID="lblID" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblCodigoVoucher" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <label for="txtdni" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txtdni" CssClass="form-control" placeholder="Ingrese Dni" OnTextChanged="DNI_changed" AutoPostBack="True" />
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese Nombre" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="Ingrese un nombre" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" placeholder="Ingrese Apellido" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="Ingrese el apellido" ControlToValidate="txtApellido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese Email" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" Text="Email incorrecto" ControlToValidate="txtEmail" ValidationExpression='^[\w\.-]+@[\w\.-]+\.\w{2,4}$' ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="row mb-3">
                <div class="col">
                    <label for="txtDireccion" class="form-label">Direccion</label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Ingrese Direccion" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDireccion" Text="Ingrese una direccion" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col">
                    <label for="txtCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" placeholder="Ingrese Ciudad" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCiudad" Text="Ingrese una ciudad" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col">
                    <label for="txtCP" class="form-label">CP</label>
                    <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" placeholder="Ingrese CP" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCP" Text="Ingrese un CP" ForeColor="Red"></asp:RequiredFieldValidator>             
                </div>
                <div class="form-check">
                    <asp:CheckBox Text="" ID="check_tyc" runat="server"/>
                    <asp:Label ID="Label1" runat="server" Text="Aceptar termino y condiciones"></asp:Label>
                    <div>
                        <asp:Label ID="lblMensaje" runat="server" Visible="false" Text="Aceptar terminos y condiciones para participar" ForeColor="Red" />
                    </div>
                </div>
                <div class="mb-3">
                    <asp:Button ID="Button1" runat="server" Text="Participar" class="btn btn-primary" OnClick="btn_click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
