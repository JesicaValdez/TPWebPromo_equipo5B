using Dominio;
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


            if (string.IsNullOrWhiteSpace(txtdni.Text))
            {
                lblResultado.Text = "Ingrese un dni.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (negocio.verificadorDNI(txtdni.Text))
                {
                    lblResultado.Text = "Dni registrado";
                    lblResultado.ForeColor = System.Drawing.Color.Green;

                    List<Cliente> lista = negocio.listarCliente();
                    Cliente seleccionado = lista.FirstOrDefault(c => c.documento == txtdni.Text);


                    if (seleccionado != null)
                    {                        
                        txtNombre.Text = seleccionado.nombre;
                        txtApellido.Text = seleccionado.apellido;
                        txtEmail.Text = seleccionado.email;
                        txtDireccion.Text = seleccionado.direccion;
                        txtCiudad.Text = seleccionado.ciudad;
                        txtCP.Text = seleccionado.codigoPostal.ToString();
                    }
                    else
                    {
                        lblResultado.Text = "Cliente no encontrado.";
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    lblResultado.Text = "Complete todos los campos.";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void tyc_checked(object sender, EventArgs e)
        {
            if (check_tyc.Checked == true)
            {
                lblMensaje.Text = "Acepto los terminos y condiciones";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "Debe aceptar los terminos y condiciones";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
           
        }

        protected void btn_click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();

            if (string.IsNullOrWhiteSpace(txtdni.Text))
            {
                lblResultado.Text = "Ingrese un DNI.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }

            if (negocio.verificadorDNI(txtdni.Text))
            {
                Response.Redirect("EstaParticipando.aspx");
            }
            else
            {
                Cliente nuevoCliente = new Cliente
                {
                    documento = txtdni.Text,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    email = txtEmail.Text,
                    direccion = txtDireccion.Text,
                    ciudad = txtCiudad.Text,
                    codigoPostal = int.Parse(txtCP.Text)
                };

                negocio.agregarCliente(nuevoCliente);
                Response.Redirect("EstaParticipando.aspx");
            }
        }
    }
}