using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Dados
{
    public class Banco : IDisposable
    {


        private readonly SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoo"].ConnectionString);
            conexao.Open();

        }



        public void ExecutaComando(string StrQuery)
        {
            var vComando = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public SqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new SqlCommand(StrQuery, conexao);
            return comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        public void Abre()
        {
            if (conexao.State == ConnectionState.Closed)
                conexao.Open();
        }
    }

}