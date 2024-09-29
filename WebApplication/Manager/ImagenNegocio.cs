using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ImagenNegocio
    {
        public List<Imagen> buscarimagenes(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("Select IdArticulo, ImagenUrl from IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Imagen aux = new Imagen();
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Url = (string)datos.Lector["ImagenUrl"];
                    if (aux.IdArticulo == id)
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

        public void agregarImagen(Imagen nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl) \r\n values (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", nuevo.IdArticulo);
                datos.setearParametro("@ImagenUrl", nuevo.Url);
                datos.ejecutarAccion();
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
    }
}
