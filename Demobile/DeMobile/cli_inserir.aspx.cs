using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class cli_inserir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int retornarID()
        {
            MySqlCommand cmd = new MySqlCommand();
            string id = "";
            try
            {

                cmd.Connection = Conexao.Connection;
                Conexao.Conectar();

                cmd.CommandText = @"SELECT id_end FROM endereco ORDER BY id_end DESC LIMIT 1;";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader["id_end"].ToString();

                    return Convert.ToInt32(id);
                }
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
            return Convert.ToInt32(id);

        }
        private void insertEnd()
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into ENDERECO (log_end, num_end, comp_end, 
                                bair_end, cid_end,uf_end)
                                values
                                (@logradouro, @numero, @complemento, @bairro, @cidade, @uf);";

                cmd.Parameters.AddWithValue("logradouro", txtLog.Text);
                cmd.Parameters.AddWithValue("numero", txtNum.Text);
                cmd.Parameters.AddWithValue("complemento", txtComp.Text);
                cmd.Parameters.AddWithValue("bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("uf", txtUF.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();

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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = Conexao.Connection;
                insertEnd();
                cmd.CommandText = @"insert into CLIENTE (endereco, nom_cli, email_cli, 
                                des_numero_cli, stt_cli)
                                values
                                (@endereco, @nome, @email, @telefone, @status);";

                cmd.Parameters.AddWithValue("endereco", retornarID().ToString());
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("telefone", txtDdd.Text + txtFone.Text);
                cmd.Parameters.AddWithValue("status", "Ativo".ToString());
                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                lblResultado.Text += "Inserido";
                Response.Redirect("cli_listar.aspx");
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