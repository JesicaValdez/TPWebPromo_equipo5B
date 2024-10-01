using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        public string codigo {  get; set; }
        public int idCliente { get; set; }
        public int idArticulo { get; set; }
        public System.DateTime fechaCanje { get; set; }
        public Voucher()
        {
            codigo = "-";
            idArticulo = 0;
            idCliente = 0;
            fechaCanje = new System.DateTime();
        }
    }
}
