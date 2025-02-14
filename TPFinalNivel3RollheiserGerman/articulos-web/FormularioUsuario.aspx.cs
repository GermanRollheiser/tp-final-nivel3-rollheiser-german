using domain;
using product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //Configuración inicial
                if (!IsPostBack)
                {
                    ddlTipos.Items.Add(TipoUsuario.NORMAL.ToString());
                    ddlTipos.Items.Add(TipoUsuario.ADMIN.ToString());

                    //Configuración para editar datos de la entrada
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (id != "" && !IsPostBack)
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        Usuario seleccionado = (negocio.toList(id))[0];

                        //Pre cargar los campos
                        txtId.Text = id;
                        txtNombre.Text = seleccionado.Nombre;
                        txtApellido.Text = seleccionado.Apellido;
                        txtEmail.Text = seleccionado.Email;
                        txtPass.Text = seleccionado.Pass;
                        ddlTipos.SelectedValue = seleccionado.TipoUsuario.ToString();

                        if (!string.IsNullOrEmpty(seleccionado.ImagenPerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "~/Images/" + seleccionado.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Usuario u = new Usuario();
                UsuarioNegocio n = new UsuarioNegocio();
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Email = txtEmail.Text;
                u.Pass = txtPass.Text;

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

                if (ddlTipos.SelectedValue == TipoUsuario.NORMAL.ToString())
                {
                    u.TipoUsuario = TipoUsuario.NORMAL;
                }
                else
                {
                    u.TipoUsuario = TipoUsuario.ADMIN;
                }

                if (Request.QueryString["id"] != null)
                {
                    u.Id = int.Parse(txtId.Text);

                    //Escribir img si se cargó algo
                    if (imagenPerfil.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        imagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + u.Id + ".jpg");
                        u.ImagenPerfil = "perfil-" + u.Id + ".jpg";
                    }
                    else
                    {
                        u.ImagenPerfil = "perfil-" + u.Id + ".jpg";
                    }
                    n.toModify(u);
                }
                else
                {
                    //Escribir img si se cargó algo
                    if (imagenPerfil.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        imagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + u.Email + ".jpg");
                        u.ImagenPerfil = "perfil-" + u.Email + ".jpg";
                    }
                    u.Id = n.toAdd(u);
                }

                //leer img
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + u.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                if (Seguridad.activeSession(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    if (usuario.TipoUsuario == TipoUsuario.ADMIN)
                    {
                        Session.Add("usuario", usuario);
                        negocio.toLogin(usuario);
                    }
                }

                Response.Redirect("AdminUsuarios.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmar.Checked)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.toDelete(int.Parse(txtId.Text));
                    Response.Redirect("AdminUsuarios.aspx", false);
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