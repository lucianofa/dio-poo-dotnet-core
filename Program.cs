using System.Collections.Generic;
using System;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {

            // Teste do override do ToString()
            //Conta minhaconta = new Conta(TipoConta.PessoaFisica, 0, 0, "Luciano Faria");
            //Console.WriteLine(minhaconta.ToString());
            //Console.ReadLine();
    
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Transferir();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
  
        }
   
        public static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir uma nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Transferir");
            Console.WriteLine("C - Limpa tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return OpcaoUsuario;
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta cadastrada!");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para continuar ...");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);

            }
            Console.Write("Pressione qualquer tecla para continuar ...");
            Console.ReadLine();

        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("Inserir Nova Conta - Digite os dados abaixo:");
            Console.WriteLine();
            Console.Write("(1) para Conta Física e (2) para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine()); 

            // Conversão explícita do TipoConta com o Enum 
            // Poderia passar os parâmetros sem o nome mas precisa seguir a ordem da classe
            Conta novaConta = new Conta(tipoconta: (TipoConta) entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);

            Console.Write("Pressione qualquer tecla para continuar ...");
            Console.ReadLine();

        }

           private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("Saque - Digite os daods abaixo: ");
            Console.WriteLine();
  
            Console.Write("Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor a ser Sacado: ");
            double entradaSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(entradaSaque);

            Console.Write("Pressione qualquer tecla para continuar ...");
            Console.ReadLine();

        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("Depósito - Digite os dados abaixo: ");
            Console.WriteLine();
  
            Console.Write("Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor a ser Depositado: ");
            double entradaDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(entradaDeposito);     

            Console.Write("Pressione qualquer tecla para continuar ...");
            Console.ReadLine();   
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("Transferência - Digite os dados abaixo: ");
            Console.WriteLine();
  
            Console.Write("Número da Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Número da Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());


            Console.Write("Valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);   

            Console.Write("Pressione qualquer tecla para continuar ...");
            Console.ReadLine();     
        }

    }

}
