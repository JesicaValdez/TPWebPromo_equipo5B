using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private ClienteNegocio negocio = new ClienteNegocio();
        private VoucherNegocio negocioVoucher = new VoucherNegocio();
        private ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DNI_changed(object sender, EventArgs e)
        {
            try
            {
                if (validarCampoDni())
                {
                    return;
                }

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
                    lblResultado.Text = "Cliente no registrado complete todos los campos";
                    lblResultado.ForeColor = System.Drawing.Color.Orange;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btn_click(object sender, EventArgs e)
        {
           
            try
            {
                if (terminoYcondiciones())
                {
                    if (validarCampoDni())
                    {
                        return;
                    }

                    if (validarCamposForm())
                    {
                        return;
                    }

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
                    nuevoCliente.id = negocio.obtenerIDCliente(nuevoCliente.documento);

                    if (nuevoCliente.id == 0)
                    {
                        lblMensaje.Text = "Error al obtener el ID del cliente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }

                    if (Session["premioID"] != null && int.TryParse(Session["premioID"].ToString(), out int idArticulo))
                    {
                        Voucher voucher = new Voucher
                        {
                            codigo = (string)Session["voucher"],
                            idCliente = nuevoCliente.id,
                            idArticulo = idArticulo,
                            fechaCanje = DateTime.Now
                        };


                        negocioVoucher.modificarVoucher(voucher);

                        EmailService emailService = new Manager.EmailService();
                        emailService.armarCorreo(nuevoCliente.email, "Canje de Premio Exitoso", "Hola " + nuevoCliente.nombre + ", tu canje de premio fue exitoso. En los próximos días recibirás tu premio en tu dirección.");
                        emailService.enviarEmail();

                        Response.Redirect("EstaParticipando.aspx");
                    }

                }
                else
                {
                    lblMensaje.Visible = true;
                }                                                            
                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarCampoDni()
        {

            if (string.IsNullOrWhiteSpace(txtdni.Text))
            {
                lblResultado.Text = "Ingrese un DNI.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtdni.Text.Length != 8 || !txtdni.Text.All(char.IsDigit))
            {
                lblResultado.Text = "Ingrese un DNI válido (8 dígitos)";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                return true;
            }

            negocio.verificadorDNI(txtdni.Text);
            return false;
        }


        private bool validarCamposForm()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtCiudad.Text))
            {
                return true;
            }
            if (string.IsNullOrEmpty(txtCP.Text))
            {

                return true;
            }

            return false;
        }
              
        private bool terminoYcondiciones()
        {
            if (check_tyc.Checked == true)
            {
                return true;
            }
            else
            {
                lblMensaje.Visible = true;

                return false;
            }
        }
    }
}