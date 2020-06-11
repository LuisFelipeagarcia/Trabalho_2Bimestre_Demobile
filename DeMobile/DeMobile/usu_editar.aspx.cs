using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class usu_editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (CapturaID())
                {
                    DadosConsulta();
                }
            }
        }

        private void DadosConsulta()
        {
            var idUsuario = obterIDUsuario();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select id_usu, nom_usu, log_usu, nivel from usuario where id_usu =@id";
                cmd.Parameters.AddWithValue("@id", idUsuario);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtId.Text = reader["id_usu"].ToString();
                    txtNome.Text = reader["nom_usu"].ToString();
                    txtLogin.Text = reader["log_usu"].ToString();
                    ddlNivel.Text = reader["nivel"].ToString();

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

        private object obterIDUsuario()
        {
            var id = 0;
            var idURL = Request.QueryString["id_usu"];

            if (!int.TryParse(idURL, out id))
            {
                throw new Exception("ID unválido");
            }
            if (id <= 0)
            {
                throw new Exception("ID unválido");
            }
            return id;
        }

        private bool CapturaID()
        {
            return Request.QueryString.AllKeys.Contains("id_usu");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var idUsuario = obterIDUsuario();           
            MySqlCommand cmd = new MySqlCommand();           
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.Parameters.AddWithValue("id", idUsuario);
                cmd.CommandText = @"update usuario set nom_usu = @nome,
                                                       log_usu = @login,
                                                       nivel = @nivel
                                                       where id_usu = @id;";

                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("login", txtLogin.Text);
                cmd.Parameters.AddWithValue("nivel", ddlNivel.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("usu_listar.aspx");
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Falha" + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}