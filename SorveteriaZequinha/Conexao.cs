using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SorveteriaZequinha
{
    public class Conexao
    {
        private static string conectionString = "Server=localhost;Port=3306;Database=dbsorveteriazequinha;Uid=root;Pwd=''";
        private static MySqlConnection conn = null;

        public static MySqlConnection obterConexao()
        {
            conn = new MySqlConnection(conectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException)
            {
                conn = null;
            }
            return conn;
        }
        public static void fecharConexao()
        {
            if (conn != null)
            {
                conn.Close();

            }
        }

    }
}
