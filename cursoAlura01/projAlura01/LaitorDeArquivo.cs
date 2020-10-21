using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAlura01
{
    public class LaitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LaitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            throw new FileNotFoundException();

            Console.WriteLine("abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("lendo linha . . .");

            throw new IOException();
                
            return "Linha do arquivo";
        }


        //public void Fechar()
        //{
        //    Console.WriteLine("fechado arquivo.");
        //}

        //  este Método deve liberar os recursos
        public void Dispose()
        {
            Console.WriteLine("fechado arquivo.");
        }

    }
}
