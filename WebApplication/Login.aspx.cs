using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DNI_changed(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtdni.Text;

            if (string.IsNullOrWhiteSpace(dni))
            {
                lblResultado.Text = "Ingrese un numero de DNI.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                if (negocio.verificadorDNI(dni))
                {
                    lblResultado.Text = "El DNI existe en la base de datos.";
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblResultado.Text = "El DNI no se encuentra en la base de datos.";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}