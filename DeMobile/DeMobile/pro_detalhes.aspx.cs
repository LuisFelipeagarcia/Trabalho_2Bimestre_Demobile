﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class pro_detalhes : System.Web.UI.Page
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
                    txtId.Text = reader["id_prod"].ToString();
                    txtNome.Text = reader["nom_prod"].ToString();
                    txtDesc.Text = reader["des_nom_prod"].ToString();
                    txtQtd.Text = reader["qtd_esto_prod"].ToString();
                    txtVal.Text = reader["preco_unit_prod"].ToString();
                    ddlStatus.Text = reader["stt_prod"].ToString();
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pro_listar.aspx");
        }
    }
}