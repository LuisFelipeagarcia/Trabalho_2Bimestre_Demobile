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
    public partial class cli_listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }
        private void CarregarUsuarios()
        {
            string query = @"select id_cli, nom_cli, stt_cli from cliente order by stt_cli asc, id_cli asc";
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
        
        
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cli_inserir.aspx");
        }
    }
}