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
                Usuario nuevo = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Pass = txtPass.Text;
                nuevo.Pass = txtPassConfirmar.Text;
                nuevo.TipoUsuario = TipoUsuario.NORMAL;

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
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}