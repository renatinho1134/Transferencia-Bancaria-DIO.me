using System;

namespace ProjetoBancario
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;
                    case "5":
                        depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("***Obrigado Por Usar Nossos Serviços***");
            Console.ReadLine();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Qual tipo de conta: \n 1 - Pessoa Fisica \n 2 - Pessoa Juridica ");
            int EntradaTipoConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string EntradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double SaldoInicial = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de Credito: ");
            double EntradaCredito = Convert.ToDouble(Console.ReadLine());

            Conta NovaConta = new Conta(TipoConta: (TipoConta)EntradaTipoConta,
                                        Saldo: SaldoInicial,
                                        Credito: EntradaCredito,
                                        Nome: EntradaNome);

            

            ListaContas.Add(NovaConta);

        }

        private static void listarContas()
        {
            if(ListaContas.Count == 0)
            {
                Console.WriteLine("Não existe contas cadastradas");
                return;
            }
            else
            {
                for(int i = 0 ; i < ListaContas.Count ; i++)
                {
                    Conta conta = ListaContas[i];
                    Console.Write("#{0} - " , i);
                    Console.WriteLine(conta);

                }
                
            }
        }

        private static void sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int IndiceDaConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja sacar: ");
            int ValorSaque = Convert.ToInt32(Console.ReadLine());

            ListaContas[IndiceDaConta].Sacar(ValorSaque);
        }

        private static void depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int IndiceDaConta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o valor que deseja depositar: ");
            int ValorDeposito = Convert.ToInt32(Console.ReadLine());

            ListaContas[IndiceDaConta].Depositar(ValorDeposito);
        }



        private static void transferir()
        {
            Console.WriteLine("Digite o numero da conta que vai transferir: ");
            int IndiceDaContaEnviar = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Digite o numero da conta que vai Receber: ");
            int IndiceDaContaReceber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Valor a transferir: ");
            int ValorTransferir = Convert.ToInt32(Console.ReadLine());

            ListaContas[IndiceDaContaEnviar].transferir(ValorTransferir, ListaContas[IndiceDaContaReceber]);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("*********RN Bank a seu Dispos*********");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("x - SAIR");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }

    
}

