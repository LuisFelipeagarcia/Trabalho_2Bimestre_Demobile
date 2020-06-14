using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class ped_detalhes : System.Web.UI.Page
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
                cmd.CommandText = @"select * from cliente where id_cli =@idC";
                cmd.Parameters.AddWithValue("@idC", idCli);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                string telefone = "", fone, ddd;

                while (reader.Read())
                {
                    
                    txtNomeCli.Text = reader["nom_cli"].ToString();
                    txtEmail.Text = reader["email_cli"].ToString();
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
        private void carregarProduto(int idProd)
        {
            
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from produto where id_prod =@idP";
                cmd.Parameters.AddWithValue("@idP", idProd);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
               

                while (reader.Read())
                {

                    txtNomeprod.Text = reader["nom_prod"].ToString();
                    txtDesc.Text = reader["des_nom_prod"].ToString();
                    
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
            var idPedido = obterIDPedido();
            var prod = 0;
            var cli = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from pedido where id_ped = @id";
                cmd.Parameters.AddWithValue("@id", idPedido);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    txtId.Text = reader["id_ped"].ToString();
                    txtnqtd.Text = reader["qtd_ped"].ToString();
                    txtValF.Text = reader["valor_final_ped"].ToString();
                    prod = Convert.ToInt32(reader["produto"].ToString());
                    cli = Convert.ToInt32(reader["cliente"].ToString());
                    ddlStatus.Text = reader["stt_ped"].ToString();
             
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
            carregarProduto(Convert.ToInt32(prod));
            carregarCliente(Convert.ToInt32(cli));
        }

        private object obterIDPedido()
        {
            var id = 0;
            var idURL = Request.QueryString["id_ped"];

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
            return Request.QueryString.AllKeys.Contains("id_ped");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ped_listar.aspx");
        }
    }
}