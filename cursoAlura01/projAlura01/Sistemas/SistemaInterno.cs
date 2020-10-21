using projAlura01.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01.Sistemas
{
    class SistemaInterno
    {

        public bool Logar (IAutenticavel  funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar( senha);

            Console.WriteLine("Usuário pode usar sistema: " + usuarioAutenticado);

            return usuarioAutenticado;
        }

    }
}
