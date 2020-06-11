using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeMobile
{
    public class Conexao
    {
        private static string Server = "localhost";
        private static string Database = "web_demobile";
        private static string User = "root";
        private static string Password = "123456";

        private static string connectionString = $@"Server={Server};
                                                    Database={Database};
                                                    Uid={User};
                                                    Pwd={Password};
                                                    SslMode=none;charset=utf8;";


        public static MySqlConnection Connection = new MySqlConnection(connectionString);

        public static void Conectar()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public static void Desconectar()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

    }
}