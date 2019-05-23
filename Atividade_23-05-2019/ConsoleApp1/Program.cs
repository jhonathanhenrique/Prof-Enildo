using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBancoDominio.Comandos comandos = new AppBancoDominio.Comandos();
            AppBancoDAO.UsuarioDAO usuario = new AppBancoDAO.UsuarioDAO();
        
            int id, telefone, opcao, crq, qtd;
            string cnpj, nome, endereco, bairro, email, med, continua;

            /*Inicio();
            Introducao();*/
            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine("        *************FARMÁCIA DE MANIPULAÇÃO MISTURA CERTA*************");
                Console.WriteLine("  _____________________________________________________________________");
                Console.WriteLine("  |                                  |                                |");
                Console.WriteLine("  |       CADASTRO                   |     CONSULTAS                  |");
                Console.WriteLine("  |----------------------------------|--------------------------------|");
                Console.WriteLine("  |  1 - CADASTRAR FARMÁCIA          |                                |");
                Console.WriteLine("  |  2 - CADASTRAR CLIENTE           |                                |");
                Console.WriteLine("  |                                  |                                |");
                Console.WriteLine("  |  4 - LISTAR REGISTROS            |                                |");
                Console.WriteLine("  |                                  |                                |");
                Console.WriteLine("  |                                  |                                |");
                Console.WriteLine("  |__________________________________|________________________________|");
                Console.Write("\n  Digite a opção desejada:");



                while (!(int.TryParse(Console.ReadLine(), out opcao)))
                {
                    Console.Write("\t\t\t\t    Opção não númérica. Escolha uma opção de 0 a 12:");
                }
                switch (opcao)
                {
                    case 1:
                       // cadastrarFarmacia();
                        break;
                    case 2:
                        //cadastrarCliente();
                        break;
                    case 3:
                        //cadastrarFuncionario();
                        break;
                    case 4:
                        comandos.mostrarReg(usuario);
                        break;
                    case 5:
                        //cadastrarEstoque();
                        break;

                    default:
                        Console.WriteLine("\t\t\t\t Opção numérica inexistente.");
                        break;
                }
                if (opcao != 0)
                {
                    Console.Write("\n Aperte qualquer tecla para voltar ao menu....");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcao != 0);

            


        }

    }
}
