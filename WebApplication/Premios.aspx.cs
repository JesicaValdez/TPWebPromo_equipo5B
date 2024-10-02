using System;
using System.Collections.Generic;
using System.Linq;
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
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocioImagen = new ImagenNegocio();

            listaArticulos = negocio.listarArticulos();

            if (listaArticulos == null)
            {
                throw new Exception("No se pudo cargar la lista de artículos.");
            }
        }
    }
}