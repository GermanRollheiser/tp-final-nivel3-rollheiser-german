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
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}