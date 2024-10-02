<%@ Page Title="Premios" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Ingresá tus datos</h1>
 <div class="row">
     <div class="col-5">
         <div class="mb-3">
             <label for="txtVoucher" class="form-label">DNI</label>
             <asp:TextBox runat="server" ID="txtVoucher" CssClass="form-control" />
         </div>
         <div class="row mb-3">
             <div class="col">
                 <label for="txtNombre" class="form-label">Nombre</label>
                 <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
             </div>
             <div class="col">
                 <label for="txtApellido" class="form-label">Apellido</label>
                 <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
             </div>
         </div>
         <div class="mb-3">
             <label for="txtEmail" class="form-label">Email</label>
             <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
         </div>
         <div class="row mb-3">
             <div class="col">
                 <label for="txtDireccion" class="form-label">Direccion</label>
                 <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
             </div>
             <div class="col">
                 <label for="txtCiudad" class="form-label">Ciudad</label>
                 <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
             </div>
             <div class="col">
                 <label for="txtCP" class="form-label">CP</label>
                 <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
             </div>
             <div class="form-check">
                 <asp:CheckBox Text="" ID="chBoxTyC" runat="server" />
                 <label class="form-check-label" for="flexCheckDefault">
                    Acepta Terminos y Condiciones.
                 </label>
             </div>
             <div class="mb-3">
                 <button type="submit" class="btn btn-primary">Aceptar</button>
             </div>
         </div>
     </div>
   </div>

</asp:Content>
