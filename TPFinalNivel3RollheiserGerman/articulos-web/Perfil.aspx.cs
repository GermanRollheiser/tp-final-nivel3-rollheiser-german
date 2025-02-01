using domain;
using product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        Image img = new Image();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.activeSession(Session["usuario"]))
                    {
                        Usuario perfil = (Usuario)Session["usuario"];
                        txtId.Text = perfil.Id.ToString();
                        txtNombre.Text = perfil.Nombre;
                        txtApellido.Text = perfil.Apellido;
                        txtEmail.Text = perfil.Email;
                        txtPass.Text = perfil.Pass;
                        txtPassConfirmar.Text = perfil.Pass;

                        if (!string.IsNullOrEmpty(perfil.ImagenPerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "~/Images/" + perfil.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario modificado = (Usuario)Session["usuario"];
            try
            {
                modificado.Nombre = txtNombre.Text;
                modificado.Apellido = txtApellido.Text;
                modificado.Email = txtEmail.Text;

                if (txtPass.Text != "" && txtPassConfirmar.Text != "")
                {
                    modificado.Pass = txtPass.Text;
                    modificado.Pass = txtPassConfirmar.Text;
                }

                //Escribir img si se cargó algo
                if (imagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    imagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + modificado.Id + ".jpg");
                    modificado.ImagenPerfil = "perfil-" + modificado.Id + ".jpg";
                }

                //Guardar datos
                negocio.toModify(modificado);

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" +  modificado.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

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