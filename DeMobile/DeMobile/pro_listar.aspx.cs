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
    public partial class pro_listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }
        private void CarregarUsuarios()
        {
            string query = @"select id_prod, nom_prod, qtd_esto_prod, preco_unit_prod, stt_prod from produto";
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
            Response.Redirect("pro_inserir.aspx");
        }

        protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var lnkPedido = (LinkButton)e.Item.FindControl("lnkPedir");
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                object id = e.Item.ItemIndex + 1;


                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao.Connection;
                    cmd.CommandText = @"select qtd_esto_prod, stt_prod from produto where id_prod =@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    Conexao.Conectar();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        var stt = reader["stt_prod"].ToString();
                        var quant = Convert.ToInt32(reader["qtd_esto_prod"].ToString());
                        if (stt.ToString() == "I" || quant <= 0)
                        {
                            lnkPedido.Visible = false;
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