using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    

    class recebeDADOS
    {
        Banco banco = new Banco();
        Usuario usuario = new Usuario();


        public void cadastro()
        {
            
            
            Console.Write("Digite o nome: ");
            usuario.nome = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            usuario.cargo = Console.ReadLine();

            Console.Write("Digite data de nascimento: ");
            usuario.data = DateTime.Parse(Console.ReadLine());

            string insereusu = string.Format("insert into tbtUsuario(NomeUsu, Cargo, Data) values ('{0}', '{1}',CONVERT (DATETIME,'{2}',103));", usuario.nome, usuario.cargo, usuario.data);
            banco.executaComando(insereusu);
            
        }
       

        public void AlteraCadastro()
        {

            Console.Write("Digite o id que deseja alterar: ");
            usuario.id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome que deseja alterar: ");
            usuario.nome = Console.ReadLine();

            Console.Write("Digite o cargo...: ");
            usuario.cargo = Console.ReadLine();

            Console.Write("Agora a data...: ");
            usuario.data = DateTime.Parse(Console.ReadLine());



            var strQuery = "";
            strQuery += "UPDATE tbtUsuario SET ";
            strQuery += string.Format(" NomeUsu = '{0}', ", usuario.nome );
            strQuery += string.Format(" Cargo = '{0}', ", usuario.cargo);
            strQuery += string.Format(" Data = CONVERT(DATETIME, '{0}',103)", usuario.data);
            strQuery += string.Format(" WHERE IdUsu = {0} ", usuario.id);

            string strselecionausu = strQuery;


           banco.executaComando(strselecionausu);

        }
        public void Listar()
        {
            
            string strselecionausu = "select * from tbtUsuario";
            SqlDataReader leitor = banco.RetornaComando(strselecionausu);

            while(leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo {2}, Data {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
                
            }
            Console.ReadKey();
            
            
        }

        public void deletarusu()
        {
            Console.Write("Digite o id que deseja deletar ");
            usuario.id = int.Parse(Console.ReadLine());            
            string strselecionausu = " delete from tbtUsuario where IdUsu = " + usuario.id;
            banco.executaComando(strselecionausu);


        }

    }
}
