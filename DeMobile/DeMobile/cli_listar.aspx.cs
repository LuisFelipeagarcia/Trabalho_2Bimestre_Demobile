using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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

        protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var lnkRemover = (LinkButton)e.Item.FindControl("lnkRemover");
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                object id = e.Item.ItemIndex + 1;
                

                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao.Connection;
                    cmd.CommandText = @"select stt_cli from cliente where id_cli =@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    Conexao.Conectar();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        var stt = reader["stt_cli"].ToString();
                        
                        if (stt.ToString() == "Inativo") 
                        {
                            lnkRemover.Visible = false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }
                finally
                {
                    Conexao.Desconectar();
                }
            }


        }
    }
}