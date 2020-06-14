using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class pro_inserir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                
                cmd.CommandText = @"insert into produto (nom_prod, des_nom_prod, qtd_esto_prod, 
                                preco_unit_prod, stt_prod)
                                values
                                (@nome, @descricao, @quantidade, @valor, @status);";

                
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("descricao", txtDesc.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQtd.Text);
                cmd.Parameters.AddWithValue("valor", txtVal.Text);
                cmd.Parameters.AddWithValue("status", "A".ToString());
                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                lblResultado.Text += "Inserido";
                Response.Redirect("pro_listar.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.CssClass = "text-danger";
                lblResultado.Text = "Falha: " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}