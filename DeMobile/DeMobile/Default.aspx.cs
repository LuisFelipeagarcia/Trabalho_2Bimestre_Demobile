using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeMobile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                cmd.Connection = Conexao.Connection;

                // recuperar senha incriptada
                cmd.CommandText = @"select senha from usuario where log_usu=@login";
                cmd.Parameters.AddWithValue("login", usuario);
                Conexao.Conectar();

                string senhaEncriptada = Convert.ToString(cmd.ExecuteScalar());

                if (string.IsNullOrEmpty(senhaEncriptada))
                {
                    throw new Exception("Usuário ou Senha Inválida");
                }

                //comparar a senha encriptada com a senha digitada 

                if (BCrypt.Net.BCrypt.Verify(senha, senhaEncriptada))
                {
                    cmd.CommandText = @"select nivel
                                        from usuario
                                        where log_usu = @usuario";
                    cmd.Parameters.AddWithValue("usuario", usuario);

                    string nivel = Convert.ToString(cmd.ExecuteScalar());

                    Session["perfil"] = nivel;

                    FormsAuthentication.RedirectFromLoginPage(nivel, false);

                }
                else
                {
                    throw new Exception("Usuário ou Senha Inválida");
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

        }
    }
}