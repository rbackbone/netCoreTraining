using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01.Funcionarios
{
    // ------ Funcionario é uma abstração   - não deve ser diretamente instanciado
    public abstract class Funcionario
    {

        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }


        public static int TotalFuncionarios { get; private set; }

        public Funcionario (string cpf, double salario)
        {
            CPF = cpf;
            Salario = salario;
            TotalFuncionarios++;
        }

  

        // ----  com a CLASSE Abstrata, 
        // ----  os métodos também devem indicar explicitamente que precisam
        // ----  ser implementados pelas classes derivadas
        public abstract double GetBonificacao();

        public abstract void AumentarSalario();


        // -- >> método virtual, permite a sobrescrita por uma classe derivada (filha)
        /*
        public virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }

        public virtual void AumentarSalario()
        {
            Salario *= 1.1;
        }
        */


    }
}
