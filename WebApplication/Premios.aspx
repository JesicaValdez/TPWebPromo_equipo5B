<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="WebApplication.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Titulo-->
    <h1 class="text-center my-4">Elegí tu Premio</h1>

    <!-- cards -->
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            foreach (Dominio.Articulo art in listaArticulos)
            {
                List<Dominio.Imagen> listaImagenes = negocioImagen.buscarimagenes(art.id);
        %>
                <div class="col">
                <div class="card">

                <!--Carrousel de imagenes-->
                <div id="carouselExample<%: art.id %>" class="carousel slide">
                    <div class="carousel-inner">
                        <%
                            bool primeraImagen = true;
                            foreach (var img in listaImagenes)
                            {
                        %>
                        <div class="carousel-item <%:primeraImagen? "active" : ""%>">
                            <img src="<%:img.Url %>" class="d-block w-100" alt="...">
                        </div>
                        <%
                                primeraImagen = false;
                            }
                            if (listaImagenes.Count ==0)
                            {
                                %>
                                < div class="carousel-item active">
                                <img src = "https://www.shutterstock.com/image-vector/default-ui-image-placeholder-wireframes-600nw-1037719192.jpg" class="d-block w-100" alt="Imagen no disponible">
                                </div>
                                <%
                            } 
                       %>
                    </div>
                   
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample<%:art.id %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample<%:art.id %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                    <!--Informacion del articulo-->
                <div class="card-body">
                    <h5 class="card-title"><%:art.nombre%></h5>
                    <p class="card-text"><%:art.descripcion %></p>
                        <a href="Login.aspx&Id=<%:art.imagenurl%>" class="btn btn-primary">Seleccionar</a>
                    </div>
                </div>
                </div>
         <% } %>
        
</asp:Content>
