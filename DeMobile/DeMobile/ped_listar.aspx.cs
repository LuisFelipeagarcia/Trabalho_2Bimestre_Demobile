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
    public partial class ped_listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }
        private void CarregarUsuarios()
        {
            string query = @"select p.id_ped, c.nom_cli, o.nom_prod, p.qtd_ped, p.valor_final_ped, p.stt_ped 
                            from pedido as p
                            join cliente as c on c.id_cli = p.cliente
                            join produto as o on o.id_prod = p.produto";
            
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
            var lnkEditar = (LinkButton)e.Item.FindControl("lnkEditar");
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                object id = e.Item.ItemIndex + 1;


                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao.Connection;
                    cmd.CommandText = @"select stt_ped from pedido where id_ped =@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    Conexao.Conectar();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        var stt = reader["stt_ped"].ToString();
                        
                        if (stt.ToString() == "Finalizado" || stt.ToString() == "Cancelado")
                        {
                            lnkEditar.Visible = false;
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