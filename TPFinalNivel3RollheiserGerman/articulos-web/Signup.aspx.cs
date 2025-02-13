using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using product;

namespace articulos_web
{
    public partial class Signup : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Usuario nuevo = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Pass = txtPass.Text;
                nuevo.Pass = txtPassConfirmar.Text;
                nuevo.TipoUsuario = TipoUsuario.NORMAL;

                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPass))
                {
                    Session.Add("error", "Email y password son campos requeridos.");
                    Response.Redirect("Error.aspx");
                }

                if (Validacion.validaEmail(txtEmail.Text))
                {
                    Session.Add("error", "No ingresó un formato email. Ejemplo: hola@gmail.com");
                    Response.Redirect("Error.aspx");
                }

                if (Validacion.validaPassword(txtPass.Text))
                {
                    Session.Add("error", "El campo password requere un mínimo de 3 caracteres y un máximo de 20 caracteres.");
                    Response.Redirect("Error.aspx");
                }

                if (txtPass.Text != txtPassConfirmar.Text)
                {
                    Session.Add("error", "Los campos password y confirmar password deben ser iguales");
                    Response.Redirect("Error.aspx");
                }

                //Escribir img si se cargó algo
                if (imagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    imagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + nuevo.Email + ".jpg");
                    nuevo.ImagenPerfil = "perfil-" + nuevo.Email + ".jpg";
                }

                nuevo.Id = usuarioNegocio.toAdd(nuevo);

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + nuevo.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                Session.Add("usuario", nuevo);

                Response.Redirect("Default.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}