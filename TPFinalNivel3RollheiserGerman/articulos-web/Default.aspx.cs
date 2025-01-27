using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using product;
using domain;

namespace articulos_web
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.toList();
            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltradaNombre = ListaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            List<Articulo> listaFiltradaMarca = ListaArticulo.FindAll(x => x.Marca.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            List<Articulo> listaFiltradaCategoria = ListaArticulo.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            if (rdbNombre.Checked)
            {
                repRepetidor.DataSource = listaFiltradaNombre;
            }
            else if (rdbMarca.Checked)
            {
                repRepetidor.DataSource = listaFiltradaMarca;
            }
            else
            {
                repRepetidor.DataSource = listaFiltradaCategoria;
            }
            repRepetidor.DataBind();
        }
    }
}