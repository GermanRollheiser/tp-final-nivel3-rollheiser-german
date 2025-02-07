﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using product;
using domain;

namespace articulos_web
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Signup || Page is Default || Page is Detalle || Page is Error))
            {
                if (!Seguridad.activeSession(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

            if (Seguridad.activeSession(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                lblPerfil.Text = "Hola " + ((Usuario)Session["usuario"]).Email;

                if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
                else
                {
                    imgAvatar.ImageUrl = "https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png";
                }
            }
            else
            {
                imgAvatar.ImageUrl = "https://www.pngkey.com/png/full/503-5035055_a-festival-celebrating-tractors-profile-picture-placeholder-round.png";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}