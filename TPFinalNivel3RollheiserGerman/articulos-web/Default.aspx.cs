using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using product;
using domain;
using System.Web.Services.Description;
using System.Text;

namespace articulos_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulo = negocio.toList();

                if (!IsPostBack)
                {
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == "")
                {
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}