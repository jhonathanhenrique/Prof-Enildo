using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
   public class UsuarioDAO
    {
        private Banco db;
        public void Insert(Usuario usuario)
        {

            var strQuery = "";
            strQuery += "insert into tbtusuario(NomeUsu, Cargo, Data)";
            strQuery += string.Format("values('{0}', '{1}',CONVERT(DATETIME, '{2}',103))", usuario.NomeUsu, usuario.Cargo, usuario.Data);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE tbtUsuario SET ";
            strQuery += string.Format(" NomeUsu = '{0}', ", usuario.NomeUsu);
            strQuery += string.Format(" Cargo = '{0}', ", usuario.Cargo);
            strQuery += string.Format(" Data = CONVERT(DATETIME, '{0}',103)", usuario.Data);
            strQuery += string.Format(" WHERE IdUsu = {0} ", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }

        }

        public void salvar(Usuario usuario)
        {
            if (usuario.IdUsu > 0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }

        }

        public List<Usuario>Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from tbtUsuario;";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }
        }
        public List<Usuario> ListaDeUsuario (SqlDataReader Retorno)
        {
            var usuarios = new List<Usuario>();
            while(Retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(Retorno["IdUsu"].ToString()),
                    NomeUsu = Retorno["NomeUsu"].ToString(),
                    Cargo = Retorno["Cargo"].ToString(),
                    Data = DateTime.Parse(Retorno["Data"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            Retorno.Close();
            return usuarios;
            
        }
    }
}
