using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class pro_fazerPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CapturaID())
            {
                DadosConsulta();
            }

        }

        private void DadosConsulta()
        {
            var idProduto = obterIDProduto();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select id_prod, nom_prod, des_nom_prod, qtd_esto_prod, preco_unit_prod, stt_prod from produto where id_prod =@id";
                cmd.Parameters.AddWithValue("@id", idProduto);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    txtNome.Text = reader["nom_prod"].ToString();
                    txtDesc.Text = reader["des_nom_prod"].ToString();
                    txtQtd.Text = reader["qtd_esto_prod"].ToString();
                    txtVal.Text = reader["preco_unit_prod"].ToString();
                    
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

        private object obterIDProduto()
        {
            var id = 0;
            var idURL = Request.QueryString["id_prod"];

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
            return Request.QueryString.AllKeys.Contains("id_prod");
        }

        private int ConferirCliente() 
        {
            int idCli = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select id_cli from cliente where email_cli =@email";
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    return Convert.ToInt32(reader["id_cli"].ToString());
                    
                    

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
            return idCli;
        }
        
        private bool ConferirEStoque() 
        {
            var idProduto = obterIDProduto();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select id_prod, nom_prod, des_nom_prod, qtd_esto_prod, preco_unit_prod, stt_prod from produto where id_prod =@id";
                cmd.Parameters.AddWithValue("@id", idProduto);
                Conexao.Conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   

                    var estoque = Convert.ToInt32(reader["qtd_esto_prod"].ToString());
                    if (Convert.ToInt32(txtnqtd.Text) < estoque)
                    {
                        return true;
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
            
            
            return false;
            
        }
        private void diminuirEstoque() 
        {
            var idProduto = obterIDProduto();
            var estoque = Convert.ToInt32(txtQtd.Text) - Convert.ToInt32(txtnqtd.Text);
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update produto set qtd_esto_prod= @estoq where id_prod =@id";
                cmd.Parameters.AddWithValue("@id", idProduto);
                cmd.Parameters.AddWithValue("@estoq", estoque);
                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("ped_listar.aspx");
                
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

        protected void btnFazerPedido_Click(object sender, EventArgs e)
        {
            var idProduto = obterIDProduto();
            bool possuiEstoque = ConferirEStoque();
            int idcliente = ConferirCliente();
            if (possuiEstoque == false)
            {
                lblResultado.Text = "Falha: Não possui essa quantidade de produtos no estoque";
            }
            else
            if (idcliente == -1)
            {
                lblResultado.Text = "Falha: Cliente não encontrado";
            }
            else 
            {
                MySqlCommand cmd = new MySqlCommand();
                var valFinal = Convert.ToDouble(txtVal.Text) * Convert.ToDouble(txtnqtd.Text);
                try
                {
                    cmd.Connection = Conexao.Connection;
                    
                    cmd.CommandText = @"insert into pedido (produto, cliente, qtd_ped, 
                                valor_final_ped, stt_ped)
                                values
                                (@produto, @cliente, @quantPed, @ValorFinal, @status);";

                    cmd.Parameters.AddWithValue("produto", idProduto.ToString());
                    cmd.Parameters.AddWithValue("cliente", idcliente.ToString());
                    cmd.Parameters.AddWithValue("quantPed", txtnqtd.Text);
                    cmd.Parameters.AddWithValue("ValorFinal", valFinal);
                    cmd.Parameters.AddWithValue("status", "Em Andamento".ToString());
                    Conexao.Conectar();
                    cmd.ExecuteNonQuery();
                    lblResultado.Text += "Inserido";
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
                diminuirEstoque();
            }
            
        }
    }
}