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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void txtImagenUrl_Load(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}