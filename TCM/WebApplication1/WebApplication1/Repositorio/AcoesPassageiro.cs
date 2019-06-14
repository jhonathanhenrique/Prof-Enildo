using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Dados;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class AcoesPassageiro
    {
        private Banco db;

        public List<Passageiro> selecionaid(int x)
        {

                using (db = new Banco())
            {
                var strQuery = "Select * from PASSAGEIRO where id_cod_pas = " + x;
                var retorno = db.RetornaComando(strQuery);



                return retornarPassageiro(retorno);

            }

        }

        public List<Passageiro> retornarPassageiro(SqlDataReader x)
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









        public Passageiro detalhes(int x)
        {

            using (db = new Banco())
            {
                var strQuery = "Select * from PASSAGEIRO where id_cod_pas = " + x;
                var retorno = db.RetornaComando(strQuery);



                return retornarPassageiro(retorno).FirstOrDefault();

            }

        }






















    }
    }








    //        public List<Passageiro> Listar(int id)
    //        {
    //            using (db = new Banco())
    //            {
    //                var strQuery = "select * from passageiro where id_cod_pas = " + id;
    //                var retorno = db.RetornaComando(strQuery);
    //                return ListaDePassageiro(retorno);
    //            }

    //        }



    //        public List<Passageiro> ListaDePassageiro(SqlDataReader Retorno)
    //        {
    //            var usuarios = new List<Passageiro>();
    //            while (Retorno.Read())
    //            {
    //                var TempUsuario = new Passageiro()
    //                {
    //                    id = int.Parse(Retorno["ID_COD_PAS"].ToString()),
    //                    nome = Retorno["NOME_PAS"].ToString(),
    //                    telefone = Retorno["TELEFONE_PAS"].ToString(),
    //                    cpf = Retorno["CPF"].ToString(),
    //                    endereco = Retorno["ENDERECO"].ToString(),
    //                    email = Retorno["EMAIL_PAS"].ToString(),
    //                    senha = int.Parse(Retorno["SENHA"].ToString())

    //                };
    //                usuarios.Add(TempUsuario);
    //            }
    //            Retorno.Close();
    //            return usuarios;
    //        }
    //    }

