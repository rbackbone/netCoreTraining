using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01.Funcionarios
{
    class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf, double salario) : base(cpf, salario)
        {

        }

        // -- >> método sobrescreve o método da Classe PAI
        public override double GetBonificacao()
        {
            return Salario * 0.1;
        }

        // ----  para implementar este tipo de método
        //-----  a Classe pai deve ter a propriedade como PROTECTED
        public override void AumentarSalario()
        {
            Salario *= 0.35;
        }
    }
}
