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

            string insereusu = string.Format("insert into tbUsuario(NomeUsu, Cargo, Data) values ('{0}', '{1}',CONVERT (DATETIME,'{2}',103));", usuario.nome, usuario.cargo, usuario.data);
            banco.executaComando(insereusu);
            
        }
       

        public void AlteraCadastro()
        {
           

            Console.Write("Digite o id que deseja alterar ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o cargo: ");
            string cargo = Console.ReadLine();
            Console.Write("Digite data de nascimento: ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            string strselecionausu = " update tbUsuario set NomeUsu =" + usuario.nome + 
                "cargo = " + usuario.cargo + 
                "data = " + usuario.data + 
                "where IdUsu = " + usuario.id;

            banco.executaComando(strselecionausu);

        }
        public void Listar()
        {
            
            string strselecionausu = "select * from tbUsuario";
            SqlDataReader leitor = banco.RetornaComando(strselecionausu);

            while(leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo {2}, Data {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
            }
            

        }

        public void deletarusu()
        {
            Console.Write("Digite o id que deseja deletar ");
            usuario.id = int.Parse(Console.ReadLine());            
            string strselecionausu = " delete from tbUsuario where IdUsu = " + usuario.id;
            banco.executaComando(strselecionausu);


        }

    }
}
