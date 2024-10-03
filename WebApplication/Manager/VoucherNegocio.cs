using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Manager
{
    public class VoucherNegocio
    {
        AccesoDB datos = new AccesoDB();

        public VoucherNegocio()
        {
            datos = new AccesoDB();
        }
        
        public List<Voucher> listarVouchers()
        {
            List<Voucher> lista = new List<Voucher>();

            
            try
            {
                datos.setearConsulta("Select CodigoVoucher, IdCliente, IdArticulo, FechaCanje from Vouchers");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    
                    aux.codigo = (string)datos.Lector["CodigoVoucher"];
                    if (!(datos.Lector["IdCliente"] is DBNull))
                        aux.idCliente = (int)datos.Lector["IdCliente"];
                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        aux.idArticulo = (int)datos.Lector["IdArticulo"];
                    if (!(datos.Lector["FechaCanje"] is DBNull))
                        aux.fechaCanje = (System.DateTime)datos.Lector["FechaCanje"];

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

        public void modificarVoucher(Voucher nuevo)
        {
            try
            {
                datos.setearConsulta("update Vouchers set IdCliente = '" + nuevo.idCliente + "', IdArticulo = '" + nuevo.idArticulo + "', FechaCanje = '" + nuevo.fechaCanje + "' where CodigoVoucher = '" + nuevo.codigo + "'");
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
