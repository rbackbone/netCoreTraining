using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01
{
    class OpFinanceiraException : Exception
    {

        public OpFinanceiraException()
        { }

        public OpFinanceiraException(string mensagem)
            : base(mensagem)
        { }

        public OpFinanceiraException(string mensagem, Exception excecaoInt)
            : base(mensagem, excecaoInt)
        {

        }

    }
}
