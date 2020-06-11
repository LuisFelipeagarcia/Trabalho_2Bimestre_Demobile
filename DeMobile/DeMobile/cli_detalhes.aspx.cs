using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class cli_detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CapturaID())
            {
                DadosConsulta();
            }

        }
        private void carregarCliente(int idCli)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from cliente where id_cli =@id";
                cmd.Parameters.AddWithValue("@id", idCli);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                string telefone = "", fone, ddd;

                while (reader.Read())
                {
                    txtId.Text = reader["id_cli"].ToString();
                    txtNome.Text = reader["nom_cli"].ToString();
                    txtEmail.Text = reader["email_cli"].ToString();
                    ddlStatus.SelectedItem.Value = reader["stt_cli"].ToString();
                    telefone = reader["des_numero_cli"].ToString();
                    int numMax = telefone.Length - 2;

                    ddd = telefone.Substring(0, 2);
                    fone = telefone.Substring(2, numMax);
                    txtDdd.Text = ddd;
                    txtFone.Text = fone;

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

        private int retornarIdEnd(int idCli)
        {
            int idEnd = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select endereco from cliente where id_cli =@id";
                cmd.Parameters.AddWithValue("@id", idCli);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    idEnd = Convert.ToInt32(reader["endereco"].ToString());
                    return idEnd;
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
            return idEnd;
        }
        private void carregarEndereco(int idCli)
        {
            var idEnd = retornarIdEnd(idCli);
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from endereco where id_end =@endereco";
                cmd.Parameters.AddWithValue("@endereco", idEnd);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtLog.Text = reader["log_end"].ToString();
                    txtNum.Text = reader["num_end"].ToString();
                    txtComp.Text = reader["comp_end"].ToString();
                    txtBairro.Text = reader["bair_end"].ToString();
                    txtCidade.Text = reader["cid_end"].ToString();
                    txtUF.Text = reader["uf_end"].ToString();
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
        private void DadosConsulta()
        {
            var idCliente = obterIDCliente();

            carregarCliente(Convert.ToInt32(idCliente));
            carregarEndereco(Convert.ToInt32(idCliente));
        }

        private object obterIDCliente()
        {
            var id = 0;
            var idURL = Request.QueryString["id_cli"];

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
            return Request.QueryString.AllKeys.Contains("id_cli");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cli_listar.aspx");
        }
    }
}