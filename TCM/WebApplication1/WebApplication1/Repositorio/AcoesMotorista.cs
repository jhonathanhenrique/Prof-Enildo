using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Dados;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class AcoesMotorista
    {

        private Banco db;
        public List<Passageiro> ListarPas()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from PASSAGEIRO;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDePass(retorno);
            }

        }



        public List<Passageiro> ListaDePass(SqlDataReader Retorno)
        {
            var usuarios = new List<Passageiro>();
            while (Retorno.Read())
            {
                var TempUsuario = new Passageiro()
                {
                    id = int.Parse(Retorno["ID_COD_PAS"].ToString()),
                    nome = Retorno["NOME_PAS"].ToString(),
                    telefone = Retorno["TELEFONE_PAS"].ToString(),
                    cpf = Retorno["CPF"].ToString(),
                    endereco = Retorno["ENDERECO"].ToString(),
                    email = Retorno["EMAIL_PAS"].ToString(),
                    senha = int.Parse(Retorno["SENHA"].ToString())

                };
                usuarios.Add(TempUsuario);
            }
            Retorno.Close();
            return usuarios;

        }
    }
}