using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class usu_listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nivel = Session["Perfil"].ToString();

            if (nivel == "O")
            {
                btnAdicionar.Visible = false;
            }
            CarregarUsuarios();

        }
        private void CarregarUsuarios()
        {
            string query = @"select id_usu, nom_usu, nivel from usuario";
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);

                //Popular repeater
                rptUsuarios.DataSource = dt;
                rptUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Falha " + ex.Message;
            }

        }
        

        protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string nivel = Session["Perfil"].ToString();

            var lnkEditar = (LinkButton)e.Item.FindControl("lnkEditar");
            var lnkEditarSenha = (LinkButton)e.Item.FindControl("lnkEditarSenha");
            var lnkRemover = (LinkButton)e.Item.FindControl("lnkRemover");

            if (lnkEditar != null && lnkRemover != null && nivel == "O")
            {
                lnkEditar.Visible = false;
                lnkEditarSenha.Visible = false;
                lnkRemover.Visible = false;
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("usu_inserir.aspx");
        }
    }
}