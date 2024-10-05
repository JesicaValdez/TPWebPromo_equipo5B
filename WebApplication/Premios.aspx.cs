using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Manager;

namespace WebApplication
{
    public partial class Premios : System.Web.UI.Page
    {
       
        public List<Articulo> listaArticulos { get; set; }
        public ImagenNegocio negocioImagen = new ImagenNegocio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Articulo> lista = articuloNegocio.listarArticulos();
                    rptArticulos.DataSource = lista;
                    rptArticulos.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string GenerarImagenes(object idArticulo)
        {
            int id = Convert.ToInt32(idArticulo);
            List<Dominio.Imagen> listaImagenes = negocioImagen.buscarimagenes(id);

            string html = "";
            bool primeraImagen = true;

            foreach(var img in listaImagenes)
            {
                string claseActiva = primeraImagen ? "active" : "";
                html += $"<div class='carousel-item {claseActiva}'><img src='{img.Url} class='d-block w-100' alt='...'></div>";
                primeraImagen = false;
            }

            if(listaImagenes.Count == 0)
            {
                html += "<div class='carousel-item active'><img src='https://www.shutterstock.com/image-vector/default-ui-image-placeholder-wireframes-600nw-1037719192.jpg' class='d-block w-100' alt='Imagen no disponible'></div";

            }
            return html;
        }

        protected void BtnS_Click(object sender, EventArgs e)
        {
            try
            {
                string id = ((Button)sender).CommandArgument;

                Session.Add("premioID", id);
                Response.Write("ID de articulo elegido " + id);
                Response.Redirect("Login.aspx");


            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.ToString());
            }


        }
    }
 }
