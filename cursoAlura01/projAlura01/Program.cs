using projAlura01.Funcionarios;
using projAlura01.Sistemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace projAlura01
{
    class Program
    {
        static void Main(string[] args)
        {

            // RunException_POO_etc();
            // ArraysListas_etc();

            CarregarContas();



            // -----------------------------------------

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }

        private static void CarregarContas()
        {
            // --- esta implementação é especifica para leituras externas
            // --- LaitorDeArquivo deve derivar da Interface IDisposible
            // --- no 

            using (LaitorDeArquivo leitor = new LaitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }


            // ----  esta implementação abaixo é um exemplo PIORADO
            //       da implementação acima

            //LaitorDeArquivo leitor = null;
            //try
            //{
            //    leitor = new LaitorDeArquivo("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
                
            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException tratada!");
            //}
            //finally
            //{
            //    if (leitor != null)
            //    leitor.Fechar();

            //}

        }


        private static void ArraysListas_etc()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(2);
            listaDeIdades.Adicionar(3);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar(5);

            listaDeIdades.AdicionarVarios(1, 2, 3, 4, 5, 6, 7, 8);


            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Item na posição {i} = {idade} ");
            }


            Lista<int> listaPeso = new Lista<int>();

            listaPeso.Adicionar(2);
            listaPeso.Adicionar(3);
            listaPeso.Adicionar(4);
            listaPeso.Adicionar(5);

            listaPeso.AdicionarVarios(1, 2, 3, 4, 5, 6, 7, 8);

            for (int i = 0; i < listaPeso.Tamanho; i++)
            {
                int peso = listaPeso[i];
                Console.WriteLine($"Item na posição {i} = {peso} ");
            }

            Console.WriteLine(SomarVarios(1, 2, 3, 4, 5, 6, 5, 4));
            Console.WriteLine(SomarVarios(1, 2, 3, 5, 4));

        }


        private static void RunException_POO_etc()
        {
            try
            {

                CalcularBonificacao();
                UsarSistema();

                Cliente gabriela = new Cliente();
                ContaCorrente contaCorrente = new ContaCorrente(867, 348856);
                contaCorrente.Titular = gabriela;

                contaCorrente.Depositar(230);
                contaCorrente.Sacar(30);

                contaCorrente.Sacar(20);

                ContaCorrente contaDestino = new ContaCorrente(897, 333856);

                contaCorrente.Transferir(400, contaDestino);

                ListaDeContaCorrente lista = new ListaDeContaCorrente();

                lista.Adicionar(new ContaCorrente(876, 12345));
                lista.Adicionar(new ContaCorrente(876, 12346));
                lista.Adicionar(new ContaCorrente(876, 12347));
                lista.Adicionar(new ContaCorrente(876, 12348));
                lista.Adicionar(new ContaCorrente(876, 12349));
                lista.Adicionar(new ContaCorrente(876, 12340));

                ContaCorrente contadoTioFlor = new ContaCorrente(1111, 111111111);
                lista.Adicionar(contadoTioFlor);

                ContaCorrente[] contas = new ContaCorrente[]
                {
                    contadoTioFlor,
                    new ContaCorrente(444, 144440),
                    new ContaCorrente(10, 13330)
                };

                lista.AdicionarVarios(contas);

                lista.AdicionarVarios(new ContaCorrente(444, 144440), new ContaCorrente(123, 1879));

                for (int i = 0; i < lista.Tamanho; i++)
                {
                    ContaCorrente itemAtual = lista[i];
                    Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia} ");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Saldo);
                Console.WriteLine(e.Saque);
                Console.WriteLine(e.Message);
            }
            catch (OpFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Inner = " + e.InnerException.Message);
            }


        }



        static int SomarVarios(params int[] numeros)
        {
            int tot = 0;
            foreach(int num in numeros)
            {
                tot += num;
            }

            return tot;

        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Funcionario Joyce = new Auxiliar("920-321-330/91", 1350);
            Joyce.Nome = "Joyce";

            GerenteDeConta Teleuma = new GerenteDeConta("920-321-330/91", 1350);
            Teleuma.Nome = "Joyce";
            Teleuma.Senha = "345";

            Diretor Joseane = new Diretor("198-168-400-98", 5000);
            Joseane.Nome = "Joseane";
            Joseane.Senha = "123";

            sistemaInterno.Logar(Joseane, "123");
            sistemaInterno.Logar(Teleuma, "345");
            //sistemaInterno.Logar(Joyce, "143");

        }

        public static void CalcularBonificacao()
        {

            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            Funcionario Carlos = new Auxiliar("920-321-330/91", 1200);
            Carlos.Nome = "Carlos";

            Funcionario Joyce = new Auxiliar("920-321-330/91", 1350);
            Joyce.Nome = "Joyce";

            // -----  polimorfismo
            Funcionario Joseane = new Diretor("198-168-400-98", 5000);
            Joseane.Nome = "Joseane";

            Funcionario Clayton = new GerenteDeConta("198-168-400-98", 7800);
            Clayton.Nome = "Clayton";


            gerenciador.Registrar(Joyce);
            gerenciador.Registrar(Carlos);
            gerenciador.Registrar(Joseane);
            gerenciador.Registrar(Clayton);

            Carlos.AumentarSalario();
            Joseane.AumentarSalario();

            Console.WriteLine("Total Bonificações: " + gerenciador.GetTotalBonificacao());
            Console.WriteLine("Total Funcionários: " + Funcionario.TotalFuncionarios);

            // =======================




        }


    }
}


/*
string sPath = Environment.CurrentDirectory + "\\";
string strFile = "";
string [] sText = null;

while (!File.Exists(strFile))
{
    Console.WriteLine("Please, enter a valid file: ");
    strFile = Console.ReadLine();
    strFile = sPath + strFile;                
}

sText = File.ReadAllLines(strFile);

foreach (string line in sText)
{

    Console.WriteLine("\t" + line);
}
*/
