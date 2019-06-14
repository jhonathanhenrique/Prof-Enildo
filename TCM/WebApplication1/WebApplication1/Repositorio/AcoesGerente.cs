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

        //INTERAÇÃO COM O PASSAGEIRO

        public void Excluir(Passageiro passageiro)
        {
            var strQuery = string.Format(" DELETE FROM PASSAGEIRO WHERE ID_COD_PAS = {0}", passageiro.id);
            using (db = new Banco())
            {

                db.ExecutaComando(strQuery);
            }
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
            strQuery += string.Format(" SENHA = {0}, ", passageiro.senha);
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //INTERAÇÃO COM O MOTORISTA


        public void InsertMot(Motorista m)
        {

            var strQuery = "";
            strQuery += "insert into MOTORISTA(NOME_MOT, CNH, TELEFONE_MOT, EMAIL_MOT, SENHA)";
            strQuery += string.Format("values('{0}', '{1}', '{2}', '{3}', {4});", m.nome, m.cnh, m.telefone, m.email, m.senha);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }



        }


        public List<Motorista> ListarMot()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from Motorista;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeMot(retorno);
            }

        }


        public List<Motorista> ListaDeMot(SqlDataReader Retorno)
        {
            var usuarios = new List<Motorista>();
            while (Retorno.Read())
            {
                var TempMot = new Motorista()
                {
                    id = int.Parse(Retorno["ID_COD_MOT"].ToString()),
                    nome = Retorno["NOME_MOT"].ToString(),
                    telefone = Retorno["TELEFONE_MOT"].ToString(),
                     cnh = Retorno["CNH"].ToString(),                    
                    email = Retorno["EMAIL_MOT"].ToString(),
                    senha = int.Parse(Retorno["SENHA"].ToString())

                };
                usuarios.Add(TempMot);
            }
            Retorno.Close();
            return usuarios;

        }

        public void AtualizarMot(Motorista m)
        {
            var strQuery = "";
            strQuery += "UPDATE MOTORISTA SET ";
            strQuery += string.Format(" NOME_MOT = '{0}', ", m.nome);
            strQuery += string.Format(" CNH = '{0}', ", m.cnh);
            strQuery += string.Format(" SENHA = {0}, ", m.senha);
            strQuery += string.Format(" TELEFONE_MOT = '{0} ,' ", m.telefone);
            strQuery += string.Format(" EMAIL_MOT = '{0}'", m.email);
            strQuery += string.Format(" WHERE ID_COD_MOT = {0} ", m.id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }

        }

        public void ExcluirMot(Motorista m)
        {
            var strQuery = string.Format(" DELETE FROM MOTORISTA WHERE ID_COD_MOT = {0}", m.id);
            using (db = new Banco())
            {

                db.ExecutaComando(strQuery);
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //INTERAÇÃO COM O ONIBUS



        public void InsertOni(Onibus o)
        {

            var strQuery = "";
            strQuery += "insert into ONIBUS (PLACA_ONIBUS, ROTA, DATA_MANUTENCAO)";
            strQuery += string.Format("values('{0}', '{1}', CONVERT(DATERIME,'{2}',103));", o.placa, o.rota, o.dataManu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }



        }



        public List<Onibus> ListaroNI()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from ONIBUS;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeOni(retorno);
            }

        }


        public List<Onibus> ListaDeOni(SqlDataReader Retorno)
        {
            var usuarios = new List<Onibus>();
            while (Retorno.Read())
            {
                var TempOni = new Onibus()
                {
                    id = int.Parse(Retorno["ID_COD_ONI"].ToString()),
                    placa = Retorno["PLACA_ONIBUS"].ToString(),
                    rota = Retorno["ROTA"].ToString(),
                    dataManu = DateTime.Parse(Retorno["DATA_MANUTENCAO"].ToString()),
                };
                usuarios.Add(TempOni);
            }
            Retorno.Close();
            return usuarios;

        }

        public void AtualizarONI(Onibus O)
        {
            var strQuery = "";
            strQuery += "UPDATE ONIBUS SET ";
            strQuery += string.Format(" PLACA_ONIBUS = '{0}', ", O.placa);
            strQuery += string.Format(" ROTA = '{0}', ", O.rota);
            strQuery += string.Format(" DATA_MANUTENCAO = {0}, ", O.dataManu);
          strQuery += string.Format(" WHERE ID_COD_ONI = {0} ", O.id);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }

        }

        public void ExcluirOni(Onibus O)
        {
            var strQuery = string.Format(" DELETE FROM ONIBUS WHERE ID_COD_ONI = {0}", O.id);
            using (db = new Banco())
            {

                db.ExecutaComando(strQuery);
            }
        }
    }
}