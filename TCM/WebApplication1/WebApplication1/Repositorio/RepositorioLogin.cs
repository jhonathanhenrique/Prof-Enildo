using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Dados;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class RepositorioLogin
    {
        private Banco db;
        Passageiro p = new Passageiro();

        public List<Passageiro> ValidarPassageiro(Passageiro p)
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from PASSAGEIRO where EMAIL_PAS = '" + p.email + "' and senha = " + p.senha;
                var retorno = db.RetornaComando(strQuery);
                return IlitValidarPassageiro(retorno);

            }

        }

        public List<Passageiro> IlitValidarPassageiro(SqlDataReader x)
        {
            var logPass = new List<Passageiro>();

            while (x.Read())
            {
                var tempLogin = new Passageiro()
                {
                    id = int.Parse(x["ID_COD_PAS"].ToString()),
                    nome = x["NOME_PAS"].ToString(),
                    telefone = x["TELEFONE_PAS"].ToString(),
                    cpf = x["CPF"].ToString(),
                    endereco = x["ENDERECO"].ToString(),
                    email = x["EMAIL_PAS"].ToString(),
                    senha = int.Parse(x["SENHA"].ToString())
                };
                logPass.Add(tempLogin);
            }
            x.Close();
            return logPass; 
        }


    }
}