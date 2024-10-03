using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            VoucherNegocio neg = new VoucherNegocio();
            List<Voucher> lista = neg.listarVouchers();
            if(Vou.Text == "")
            {
                Session.Add("error", 1);
                Response.Redirect("Incorrecto.aspx");
            }
            foreach (Voucher voucher in lista)
            {
                if (voucher.codigo == Vou.Text)
                {
                    if (voucher.idCliente == 0)
                    {
                        Session.Add("voucher", voucher.codigo);
                        Response.Redirect("Premios.aspx");
                    }
                    else
                    {
                        Session.Add("error", 2);
                        Response.Redirect("Incorrecto.aspx");
                    }
                }
            }
            Session.Add("error", 3);
            Response.Redirect("Incorrecto.aspx");
        }
    }
}