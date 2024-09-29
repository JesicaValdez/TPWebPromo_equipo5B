using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ArticuloNegocio
    {
        private List<Articulo> listaArticulos = new List<Articulo>();
        private List<Categoria> ListaCategorias = new List<Categoria>();
        AccesoDB datos = new AccesoDB();

        public ArticuloNegocio()
        {
            datos = new AccesoDB();
        }

        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            List<Imagen> lista1 = new List<Imagen>();
            ImagenNegocio negocio = new ImagenNegocio();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion as Detalle, M.Descripcion as Marca, C.Descripcion as Categoria, Precio From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Detalle"] is DBNull))
                        aux.descripcion = (string)datos.Lector["Detalle"];
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.marca = new Marca();
                        aux.marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.categoria = new Categoria();
                        aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.precio = (decimal)datos.Lector["Precio"];
                    lista1 = negocio.buscarimagenes(aux.id);

                    if (lista1 != null && lista1.Count > 0)
                    {
                        aux.imagenurl = lista1[0].Url;
                    }
                    else
                    {
                        aux.imagenurl = null;
                    }
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulo> buscarpormarca(string marca)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista1 = negocio.listarArticulos();
            List<Articulo> lista2 = new List<Articulo>();
            foreach (Articulo art in lista1)
            {
                if (art.marca.Descripcion == marca)
                {
                    lista2.Add(art);
                }
            }
            return lista2;
        }

        public List<Articulo> buscarporcategoria(string cat)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista1 = negocio.listarArticulos();
            List<Articulo> lista2 = new List<Articulo>();
            foreach (Articulo art in lista1)
            {
                if (art.categoria.Descripcion == cat)
                {
                    lista2.Add(art);
                }
            }
            return lista2;
        }

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try 
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) \r\n values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.categoria.Id);
                datos.setearParametro("@Precio", nuevo.precio);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarArticulo(int id)
        {
            try
            {
                AccesoDB datos = new AccesoDB();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarArticulo(Articulo articulo)
        {

            try
            {
                AccesoDB datos = new AccesoDB();
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Id", articulo.id);
                datos.setearParametro("@Codigo", articulo.codigo);
                datos.setearParametro("@Nombre", articulo.nombre);
                datos.setearParametro("@Descripcion", articulo.descripcion);
                datos.setearParametro("@Precio", articulo.precio);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void insertarImagenes(Articulo nuevoArticulo)
        {
            Articulo articulo = new Articulo();
            articulo = listarArticulos().Last();

            try
            {
                AccesoDB datos = new AccesoDB();
                datos.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl) values (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", articulo.id);
                datos.setearParametro("@ImagenUrl", articulo.imagenurl);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
