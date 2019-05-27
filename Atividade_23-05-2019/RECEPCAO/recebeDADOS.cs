using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    

    public class recebeDADOS
    {
        Banco banco = new Banco();
        Usuario usuario = new Usuario();


        public void cadastro()
        {
            Console.Clear();
           banco.Abre();

            Console.Write("Digite o nome: ");
            usuario.nome = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            usuario.cargo = Console.ReadLine();

            Console.Write("Digite data de nascimento: ");
            usuario.data = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string insereusu = string.Format("insert into tbUsuario(NomeUsu, Cargo, Data) values ('{0}', '{1}',CONVERT (DATETIME,'{2}',103));", usuario.nome, usuario.cargo, usuario.data);
            banco.executaComando(insereusu);

            banco.mostra();

            banco.Dispose();
            Console.Write("\n\n\n\n\n\n Tecle qualquer tecla para voltar ao menu...\n\n\n");
            Console.ReadKey();
            
        }
       

        public void AlteraCadastro()
        {
            Console.Clear();
            banco.Abre();

            Console.Write("Digite o id que deseja alterar: ");
            usuario.id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome que deseja alterar: ");
            usuario.nome = Console.ReadLine();

            Console.Write("Digite o cargo...: ");
            usuario.cargo = Console.ReadLine();

            Console.Write("Agora a data...: \n\n\n\n");
            usuario.data = DateTime.Parse(Console.ReadLine());



            var strQuery = "";
            strQuery += "UPDATE tbUsuario SET ";
            strQuery += string.Format(" NomeUsu = '{0}', ", usuario.nome );
            strQuery += string.Format(" Cargo = '{0}', ", usuario.cargo);
            strQuery += string.Format(" Data = CONVERT(DATETIME, '{0}',103)", usuario.data);
            strQuery += string.Format(" WHERE IdUsu = {0} ", usuario.id);

            string strselecionausu = strQuery;
            banco.executaComando(strselecionausu);

            banco.mostra();
            Console.Write("\n\n\n\n\n\n Tecle qualquer tecla para voltar ao menu...\n\n\n");
            Console.ReadKey();
            // Listar();
            banco.Dispose();

        }
        public void Listar()
        {
            Console.Clear();
            banco.Abre();

            string strselecionausu = "select * from tbUsuario";
            SqlDataReader leitor = banco.RetornaComando(strselecionausu);

            while(leitor.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo {2}, Data {3}", leitor["IdUsu"], leitor["NomeUsu"], leitor["Cargo"], leitor["Data"]);
                
            }

            banco.mostra();


            Console.Write("\n\n\n\n\n\n Tecle qualquer tecla para voltar ao menu...\n\n\n");
            //Listar();

            banco.Dispose();
            Console.ReadKey();
            
            
        }

        public void deletarusu()
        {
            banco.Abre();

            Console.Clear();
            banco.Abre();
            Console.Write("Digite o id que deseja deletar ");
            usuario.id = int.Parse(Console.ReadLine());

        
          
            string strselecionausu = " delete from tbUsuario where IdUsu = " + usuario.id;
            banco.executaComando(strselecionausu);

                Console.Write("\n\n\n\Usuário deletado com sucesso!!!\n\n\n");

            //Listar();
            banco.mostra();

            Console.Write("\n\n\n\n\n\n Tecle qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            banco.Dispose();
        }

    }
}
