﻿using domain;
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
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario modificado = (Usuario)Session["usuario"];
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                modificado.Nombre = txtNombre.Text;
                modificado.Apellido = txtApellido.Text;
                modificado.Email = txtEmail.Text;
                modificado.Pass = txtPass.Text;
                modificado.Pass = txtPassConfirmar.Text;

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
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}