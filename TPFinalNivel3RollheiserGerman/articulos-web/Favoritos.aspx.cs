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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Favorito> ListaFavorito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.activeSession(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    string idUser = usuario.Id.ToString();
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    ListaFavorito = negocio.toList(idUser);

                    if (!IsPostBack)
                    {
                        repRepetidor.DataSource = ListaFavorito;
                        repRepetidor.DataBind();
                    }

                    if (!ListaFavorito.Any())
                    {
                        imgListaVacia.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnNoFav_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                string articulo = ((Button)sender).CommandArgument;

                int idUser = usuario.Id;
                int idArticulo = int.Parse(articulo);

                negocio.toDelete(idUser, idArticulo);

                Response.Redirect("Favoritos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}