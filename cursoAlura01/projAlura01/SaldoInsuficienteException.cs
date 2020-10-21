using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01
{
    class SaldoInsuficienteException : OpFinanceiraException
    {
        public double Saldo { get; }    //  readonly
        public double Saque { get; }    //  readonly

        public SaldoInsuficienteException() { }

        // ---- este construtor chama o logo abaixo, 
        //----------------  passando a mensagem pelo : this
        public SaldoInsuficienteException(double saldo, double saque)
            : this("Saldo insuficiente - Tentativa de saque = " + saque + ", saldo = " + saldo)
        {
            Saldo = saldo;
            Saque = saque;
        }

        public SaldoInsuficienteException(string erro)
            : base(erro)
        {
        }

        public SaldoInsuficienteException(string erro, Exception exception)
            : base(erro, exception)
        {
        }

    }
}
