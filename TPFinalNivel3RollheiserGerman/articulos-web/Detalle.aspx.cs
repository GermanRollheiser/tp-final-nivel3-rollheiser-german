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
        public List<Favorito> ListaFavorito { get; set; }
        public List<Articulo> ListaArticulo { get; set; }
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

                //Transformar lista de favoritos en lista de articulos
                if (Seguridad.activeSession(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    string idUser = usuario.Id.ToString();
                    int idUserSesion = usuario.Id;
                    ArticuloNegocio negocioArt = new ArticuloNegocio();
                    ListaArticulo = negocioArt.toList();
                    FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                    ListaFavorito = favoritoNegocio.toList(idUser);
                    List<Articulo> listaFavArt = new List<Articulo>();

                    foreach (var item in ListaFavorito)
                    {
                        int idUserFav = item.IdUser;
                        int idArtFav = item.IdArticulo;

                        if (idUserSesion == idUserFav)
                        {
                            foreach (var item2 in ListaArticulo)
                            {
                                if (idArtFav == item2.Id)
                                {
                                    Articulo articulo = new Articulo();
                                    articulo.Id = item2.Id;
                                    articulo.Codigo = item2.Codigo;
                                    articulo.Nombre = item2.Nombre;
                                    articulo.Descripcion = item2.Descripcion;
                                    articulo.Marca = new Marca();
                                    articulo.Marca.Id = item2.Marca.Id;
                                    articulo.Marca.Descripcion = item2.Marca.Descripcion;
                                    articulo.Categoria = new Categoria();
                                    articulo.Categoria.Id = item2.Categoria.Id;
                                    articulo.Categoria.Descripcion = item2.Categoria.Descripcion;
                                    articulo.ImagenUrl = item2.ImagenUrl;
                                    articulo.Precio = item2.Precio;
                                    listaFavArt.Add(articulo);
                                }
                            }
                        }
                    }

                    //Comprobar si ya existe para modificar el toggle
                    if (listaFavArt.Any(a => a.Id == seleccionado.Id))
                    {
                        lblNoFav.Visible = true;
                        lblFav.Visible = false;
                    }
                }
            }
        }

        protected void txtImagenUrl_Load(object sender, EventArgs e)
        {
            if (txtImagenUrl.Text == "")
            {
                imgArticulo.ImageUrl = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
            }
            else
            {
                imgArticulo.ImageUrl = txtImagenUrl.Text;
            }
        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.activeSession(Session["usuario"]))
                {
                    Favorito nuevo = new Favorito();
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    Usuario usuario = (Usuario)Session["usuario"];
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    string idArticulo = id;
                    int idUser = usuario.Id;

                    nuevo.IdUser = idUser;
                    nuevo.IdArticulo = int.Parse(idArticulo);

                    nuevo.Id = negocio.toAdd(nuevo);

                    lblFav.Visible = false;
                    lblNoFav.Visible = true;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnNoFav_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.activeSession(Session["usuario"]))
                {
                    FavoritoNegocio negocio = new FavoritoNegocio();
                    Usuario usuario = (Usuario)Session["usuario"];
                    string articulo = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    int idUser = usuario.Id;
                    int idArticulo = int.Parse(articulo);

                    negocio.toDelete(idUser, idArticulo);

                    lblNoFav.Visible = false;
                    lblFav.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}