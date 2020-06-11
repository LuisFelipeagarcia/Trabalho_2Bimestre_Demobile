using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class usu_inserir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var senhaEncriptada = BCrypt.Net.BCrypt.HashPassword(txtSenha.Text);
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into usuario (nom_usu, log_usu, senha, nivel) 
                                    values (@nome, @login, @senha, @nivel);";

                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("login", txtLogin.Text);
                cmd.Parameters.AddWithValue("senha", senhaEncriptada);
                cmd.Parameters.AddWithValue("nivel", ddlNivel.Text);

                Conexao.Conectar();

                cmd.ExecuteNonQuery();
                Response.Redirect("usu_listar.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Falha: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}