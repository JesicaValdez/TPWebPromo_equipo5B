<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="WebApplication.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Título -->
    <h1 class="text-center my-4">Elegí tu Premio</h1>

    <!-- Repeater para generar las tarjetas de premios -->
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <!-- Carrousel de imágenes -->
                        <div id="carouselExample<%# Eval("Id") %>" class="carousel slide">
                            <div class="carousel-inner">
                                <%# GenerarImagenes(Eval("Id")) %> <!-- Llama a la función del code-behind para generar imágenes -->
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample<%# Eval("Id") %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample<%# Eval("Id") %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <!-- Información del artículo -->
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <asp:Button ID="btnSeleccionado" runat="server" Text="Seleccionar" 
                                        CommandArgument='<%# Eval("Id") %>' 
                                        CssClass="btn btn-primary" OnClick="BtnS_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

