using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       

        static void Main(string[] args)
        {

            
            recebeDADOS dados = new recebeDADOS();
        
            int opcao;

            
            /*Inicio();
            Introducao();*/
            Console.Clear();

            do
            {
                

                Console.Clear();
                Console.WriteLine("        *************OPÇÕES*************");
                Console.WriteLine("  ___________________________________");
                Console.WriteLine("  |                                  |");
                Console.WriteLine("  |       CADASTRO                   |");
                Console.WriteLine("  |----------------------------------|");
                Console.WriteLine("  |  1 - CADASTRAR                   |");
                Console.WriteLine("  |  2 - ALTERAR                     |");
                Console.WriteLine("  |  3 - EXCLUIR                     |");
                Console.WriteLine("  |  4 - LISTAR REGISTROS            |");
                Console.WriteLine("  |  5 - SAIR                        |");
                Console.WriteLine("  |                                  |");
                Console.WriteLine("  |__________________________________|");
                Console.Write("\n  Digite a opção desejada:");



                while (!(int.TryParse(Console.ReadLine(), out opcao)))
                {
                    Console.Write("Opção não númérica. Escolha uma opção de 0 a 12:");
                }
                switch (opcao)
                {
                    case 1:
                        dados.cadastro();
                        break;
                    case 2:
                        dados.AlteraCadastro();
                        break;
                    case 3:
                        dados.deletarusu();
                        break;
                    case 4:
                        dados.Listar();
                        break;
                

                    default:
                        Console.WriteLine("Opção inválida, digite um número de 1 a 5");
                        break;
                }
                
               
            } while (opcao != 5);

            


        }

    }
}
