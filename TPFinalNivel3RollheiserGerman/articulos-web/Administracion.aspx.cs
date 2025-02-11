using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || ((Usuario)Session["usuario"]).TipoUsuario == TipoUsuario.NORMAL)
            {
                Session.Add("error", "Necesitás permisos como admin para ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}