using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Comandos
    {
        class Banco
        {
            private readonly SqlConnection conexao;

            public Banco()
            {
                conexao = new SqlConnection(@"Data Source =JHONATHAN-PC\SQLEXPRESS, Initial Catalog = db_registro, User ID = Jhonathan-PC\Jhonathan");
                conexao.Open();

            }

            public void executaComando()
            {
                var comando = new SqlCommand
                {
                    CommandText = StrQuery,
                    CommandType = System.Data.CommandType.Text,
                    Connection = conexao
                    
                };

                public SqlDataReader RetornaComando (StrQuery)
                {
                    var comando = new SqlCommand(strQuery, conexao)
                    return comando.EndExecuteNonQuery();
                }
            }
        }


    }
}
