﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Banco : IDisposable
    {
        private readonly SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(@"Data Source =JHONATHAN-PC\SQLEXPRESS; Initial Catalog = db_registro; Integrated Security = True");
            conexao.Open();

        }

        public void executaComando(string StrQuery)
        {
            var comando = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao

            };

            comando.ExecuteNonQuery();

        
        }
        public SqlDataReader RetornaComando(string strQuery)
        {
            var comando = new SqlCommand(strQuery, conexao);
                
               return comando.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}

