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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;

                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPass))
                {
                    Session.Add("error", "Debes completar ambos campos.");
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

                if (negocio.toLogin(usuario))
                {
                    Session.Add("usuario", usuario);
                    if (usuario.TipoUsuario == TipoUsuario.NORMAL)
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("Administracion.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "Email o password incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
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