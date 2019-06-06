using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Dados
{
    public class AcoesGerente
    {
        private Banco db;
        public void Excluir(Passageiro passageiro)
        {
            var strQuery = string.Format(" DELETE FROM PASSAGEIRO WHERE ID_COD_PAS = {0}", passageiro.id);
            using (db = new Banco())
            {

                db.ExecutaComando(strQuery);
            }
        }

        public void ListarCertoPas(int id )
        {
            var strQuery = string.Format(" SELECT FROM PASSAGEIRO WHERE ID_COD_PAS = {0}", id);
            db.RetornaComando(strQuery);
        }




        public void Insert(Passageiro passageiro)
        {

            var strQuery = "";
            strQuery += "insert into PASSAGEIRO(NOME_PAS, CPF, ENDERECO, TELEFONE_PAS, EMAIL_PAS, SENHA)";
            strQuery += string.Format("values('{0}', '{1}', '{2}', '{3}', '{4}', {5} );",passageiro.nome, passageiro.cpf, passageiro.endereco, passageiro.telefone,passageiro.email,passageiro.senha);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }



        }


        public void Atualizar(Passageiro passageiro)
        {
            var strQuery = "";
            strQuery += "UPDATE PASSAGEIRO SET ";
            strQuery += string.Format(" NOME_PAS = '{0}', ", passageiro.nome);
            strQuery += string.Format(" ENDERECO = '{0}', ", passageiro.endereco);
            strQuery += string.Format(" SENHA = '{0}', ", passageiro.senha);
            strQuery += string.Format(" TELEFONE_PAS = '{0}'", passageiro.telefone);
            strQuery += string.Format(" WHERE ID_COD_PAS = {0} ", passageiro.id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }

        }



        public List<Passageiro> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from PASSAGEIRO;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }

        }



        public List<Passageiro> ListaDeUsuario(SqlDataReader Retorno)
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