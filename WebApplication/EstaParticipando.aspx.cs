using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class EstaParticipando : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_cerrar(object sender, EventArgs e) 
        {
            Response.Redirect("Promoganá.aspx");
        }

    }
}