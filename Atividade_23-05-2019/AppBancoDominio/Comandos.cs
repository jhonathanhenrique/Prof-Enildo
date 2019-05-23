using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Comandos
    {
        public void mostrarReg (AppBancoDAO.UsuarioDAO usuario)
        {

            Console.Write("ID do usuário: {0}", usuario.id);
            Console.Write("Nome do usuário: {0}", usuario.nome);

        }

        
    }
}
