using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco();
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            Console.WriteLine("Digite o nome do usuário: ");
            string vNome = Console.ReadLine();

            Console.WriteLine("Digite o cargo: ");
            string vCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento: ");
            string vData = Console.ReadLine();

            

            usuario.NomeUsu = vNome;
            usuario.Cargo = vCargo;
            usuario.Data = DateTime.Parse(vData);

            usuarioDAO.salvar(usuario);



            // usuarioDAO.Atualizar(usuario);


            var leitor = usuarioDAO.Listar ();

                foreach (var usuarios  in leitor)
                {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", usuarios.IdUsu, usuarios.NomeUsu, usuarios.Cargo, usuarios.Data);
                      
                };


                Console.ReadLine();

            }
        }
    }

