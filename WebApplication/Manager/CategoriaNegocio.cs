using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class CategoriaNegocio
    {
        AccesoDB datos = new AccesoDB();

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                datos.setearConsulta("SELECT * FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void agregarCategoria(Categoria nueva)
        {
            try
            {
                datos.setearConsulta("insert into CATEGORIAS VALUES ('" + nueva.Descripcion + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificaCategoria(Categoria categoriaModificada)
        {
            try
            {
                datos.setearConsulta("update CATEGORIAS set Descripcion = '" + categoriaModificada.Descripcion + "' where Id = " + categoriaModificada.Id);
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

        public void eliminarCategoria(Categoria eliminarCat)
        {
            try
            {

                datos.setearConsulta("delete from CATEGORIAS where Id = " + eliminarCat.Id);
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
