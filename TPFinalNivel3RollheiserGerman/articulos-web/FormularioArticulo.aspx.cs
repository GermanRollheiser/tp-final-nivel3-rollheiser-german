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
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
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
                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo a = new Articulo();
                ArticuloNegocio n = new ArticuloNegocio();
                a.Nombre = txtNombre.Text;
                a.Descripcion = txtDescripcion.Text;
                a.Precio = decimal.Parse(txtPrecio.Text);
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
                
                Response.Redirect("Administracion.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
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
    }
}