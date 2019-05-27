using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ConsoleApp1
{
    public class Banco : IDisposable
    {

        private Banco db;
        private readonly SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ToString());
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


        public void mostra()
        {
            Dispose();
            conexao.Open();
            
            
            var strQuery = "select * from tbUsuario";
            SqlDataReader leitor = RetornaComando(strQuery);

     
            while (leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo {2}, Data {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);

            }

            using (db = new Banco())
            {
                strQuery = "Select * from tbUsuario;";
                db.RetornaComando(strQuery);

            }
            

        }



        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
        public void Abre()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
        }
    }
}

