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
    public partial class FormularioArticulo : System.Web.UI.Page
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
                    MarcaNegocio m = new MarcaNegocio();
                    List<Marca> lista = m.toList();
                    ddlMarcas.DataSource = lista;
                    ddlMarcas.DataValueField = "Id";
                    ddlMarcas.DataTextField = "Descripcion";
                    ddlMarcas.DataBind();

                    CategoriaNegocio c = new CategoriaNegocio();
                    List<Categoria> lista2 = c.toList();
                    ddlCategorias.DataSource = lista2;
                    ddlCategorias.DataValueField = "Id";
                    ddlCategorias.DataTextField = "Descripcion";
                    ddlCategorias.DataBind();
                }

                //Configuración para editar datos de la entrada
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.toList(id))[0];

                    //Pre cargar los campos
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    ddlMarcas.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategorias.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);
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

                Articulo a = new Articulo();
                ArticuloNegocio n = new ArticuloNegocio();
                a.Codigo = txtCodigo.Text;
                a.Nombre = txtNombre.Text;
                a.Descripcion = txtDescripcion.Text;

                if (Validacion.validaTextoVacio(txtNombre))
                {
                    Session.Add("error", "El artículo no puede ser cargado completamente vacío. El nombre es un campo requerido.");
                    Response.Redirect("Error.aspx");
                }

                if (Validacion.validaPrecio(txtPrecio.Text))
                {
                    Session.Add("error", "El campo precio requere solo números en formato dinero. Ejemplo: 1.00");
                    Response.Redirect("Error.aspx");
                }

                if (txtPrecio.Text != "")
                {
                    a.Precio = decimal.Parse(txtPrecio.Text);
                }
                
                a.ImagenUrl = txtImagenUrl.Text;
                a.Marca = new Marca();
                a.Marca.Id = int.Parse(ddlMarcas.SelectedValue);
                a.Categoria = new Categoria();
                a.Categoria.Id = int.Parse(ddlCategorias.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    a.Id = int.Parse(txtId.Text);
                    n.toModify(a);
                }
                else
                {
                    n.toAdd(a);
                }
                
                Response.Redirect("AdminArticulos.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtImagenUrl.Text == "")
                {
                    imgArticulo.ImageUrl = "https://i.pinimg.com/474x/e8/ee/07/e8ee0728e1ba12edd484c111c1f492f2.jpg";
                }
                else
                {
                    imgArticulo.ImageUrl = txtImagenUrl.Text;
                }
            }
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
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.toDelete(int.Parse(txtId.Text));
                    Response.Redirect("AdminArticulos.aspx", false);
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