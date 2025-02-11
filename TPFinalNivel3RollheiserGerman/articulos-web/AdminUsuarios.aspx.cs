using domain;
using product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace articulos_web
{
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || ((Usuario)Session["usuario"]).TipoUsuario == TipoUsuario.NORMAL)
            {
                Session.Add("error", "Necesitás permisos como admin para ingresar");
                Response.Redirect("Error.aspx", false);
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                FiltroAvanzado = false;

                //Cargo la lista de usuarios
                UsuarioNegocio negocio = new UsuarioNegocio();
                Session.Add("listaUsuarios", negocio.toList());
                dgvUsuarios.DataSource = Session["listaUsuarios"];
                dgvUsuarios.DataBind();

                //Cargo los valores de los desplegables por default
                getCampo();
                getDefaultCriterio();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> listaFiltrada = lista.FindAll(x => x.Email.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvUsuarios.DataSource = listaFiltrada;
            dgvUsuarios.DataBind();
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioUsuario.aspx?id=" + id);
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Text = "";
            UsuarioNegocio negocio = new UsuarioNegocio();
            dgvUsuarios.DataSource = negocio.toList();
            dgvUsuarios.DataBind();
            txtFiltro.Enabled = !FiltroAvanzado;

            if (chkAvanzado.Checked == false)
            {
                getCampo();
                getDefaultCriterio();
                txtFiltroAvanzado.Text = "";
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (ddlCampo.SelectedValue.ToString() == "3" && ddlCriterio.SelectedValue.ToString() == "1")
                {
                    txtFiltroAvanzado.Text = "0";
                }

                if (ddlCampo.SelectedValue.ToString() == "3" && ddlCriterio.SelectedValue.ToString() == "2")
                {
                    txtFiltroAvanzado.Text = "1";
                }

                dgvUsuarios.DataSource = negocio.toSortBy(ddlCampo.SelectedValue.ToString(), ddlCriterio.SelectedValue.ToString(), txtFiltroAvanzado.Text);
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        private void getCampo()
        {
            DataTable campo = new DataTable();
            campo.Columns.Add("CampoId", typeof(int));
            campo.Columns.Add("CampoNombre");
            campo.Rows.Add(1, "Nombre");
            campo.Rows.Add(2, "Email");
            campo.Rows.Add(3, "Tipo de usuario");
            ddlCampo.DataSource = campo;
            ddlCampo.DataTextField = "CampoNombre";
            ddlCampo.DataValueField = "CampoId";
            ddlCampo.DataBind();
        }

        private void getDefaultCriterio()
        {
            DataTable criterioDefault = new DataTable();
            criterioDefault.Columns.Add("CriterioId", typeof(int));
            criterioDefault.Columns.Add("CriterioNombre");
            criterioDefault.Rows.Add(1, "Empieza con");
            criterioDefault.Rows.Add(2, "Termina con");
            criterioDefault.Rows.Add(3, "Contiene");
            ddlCriterio.DataSource = criterioDefault;
            ddlCriterio.DataTextField = "CriterioNombre";
            ddlCriterio.DataValueField = "CriterioId";
            ddlCriterio.DataBind();
        }

        protected void OnCampoChange(object sender, EventArgs e)
        {
            if (int.Parse(ddlCampo.SelectedValue) > 0)
            {
                DataTable criterio = new DataTable();
                criterio.Columns.Add("CriterioId", typeof(int));
                criterio.Columns.Add("CampoId", typeof(int));
                criterio.Columns.Add("CriterioNombre");

                if (ddlCampo.SelectedValue == "1")
                {
                    criterio.Rows.Add(1, 1, "Empieza con");
                    criterio.Rows.Add(2, 1, "Termina con");
                    criterio.Rows.Add(3, 1, "Contiene");

                    txtFiltroAvanzado.Enabled = true;
                }

                if (ddlCampo.SelectedValue == "2")
                {
                    criterio.Rows.Add(1, 1, "Empieza con");
                    criterio.Rows.Add(2, 1, "Termina con");
                    criterio.Rows.Add(3, 1, "Contiene");

                    txtFiltroAvanzado.Enabled = true;
                }

                if (ddlCampo.SelectedValue == "3")
                {
                    criterio.Rows.Add(1, 1, "Normal");
                    criterio.Rows.Add(2, 1, "Admin");

                    txtFiltroAvanzado.Text = "";
                    txtFiltroAvanzado.Enabled = false;
                }

                ddlCriterio.DataSource = criterio;
                ddlCriterio.DataTextField = "CriterioNombre";
                ddlCriterio.DataValueField = "CriterioId";
                ddlCriterio.DataBind();
            }
        }
    }
}