using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manager
{
    public class ClienteNegocio
    {
        public List<Cliente> listarCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP From Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();

                    aux.id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Documento"] is DBNull))
                        aux.documento = (string)datos.Lector["Documento"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Apellido"] is DBNull))
                        aux.apellido = (string)datos.Lector["Apellido"];

                    if (!(datos.Lector["Email"] is DBNull))
                        aux.email = (string)datos.Lector["Email"];
                    
                    if (!(datos.Lector["Direccion"] is DBNull))
                        aux.direccion = (string)datos.Lector["Direccion"];
                    

                    if (!(datos.Lector["Ciudad"] is DBNull))
                        aux.ciudad = (string)datos.Lector["Ciudad"];

                    if (!(datos.Lector["CP"] is DBNull))
                        aux.codigoPostal = (int)datos.Lector["CP"];

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

        public void agregarCliente(Cliente nuevo)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                
                datos.setearConsulta("insert into Clientes (Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) \r\n values (@Id, @Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");
                datos.setearParametro("@Id", nuevo.id);
                datos.setearParametro("@Documento", nuevo.documento);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("Apellido", nuevo.email);
                datos.setearParametro("Email", nuevo.email);
                datos.setearParametro("Direccion", nuevo.direccion);
                datos.setearParametro("Ciudad", nuevo.ciudad);
                datos.setearParametro("CP", nuevo.codigoPostal);
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

        public bool verificadorDNI(string dni)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDB datos = new AccesoDB();


            try
            {

                datos.setearConsulta("SELECT COUNT(*) From Clientes WHERE Documento = @Documento");
                datos.comando.Parameters.AddWithValue("@Documento", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
