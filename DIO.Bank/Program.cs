using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o Banco Curso .NET DIO");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.WriteLine("=====DEPOSITAR DINHEIRO=====");
            Console.WriteLine("DIGITE O NÚMERO DA CONTA:");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O VALOR A SER DEPOSITADO:");
            double valorDeposito = double.Parse(Console.ReadLine());
            listContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("=====SACAR DINHEIRO=====");
            Console.WriteLine("DIGITE O NÚMERO DA CONTA:");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O VALOR A SER SACADO:");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("=====TRANSFERIR DINHEIRO=====");
            Console.WriteLine("DIGITE O NÚMERO DA CONTA DE ORIGEM:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O NÚMERO DA CONTA DE DESTINO:");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O VALOR A SER TRANSFERIDO:");
            double valorTransferido = double.Parse(Console.ReadLine());
            listContas[indiceContaOrigem].Transferir(valorTransferido, listContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("=====INSERIR NOVA CONTA=====");
            Console.WriteLine("DIGITE 1 PARA PESSOA FÍSICA E 2 PARA PESSOA JURÍDICA:");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O NOME DO TITULAR DA CONTA:");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("DIGITE O SALDO INICIAL DA CONTA:");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("DIGITE O CRÉDITO INICIAL DA CONTA:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("=====LISTA DE CONTAS=====");
            if (listContas.Count == 0)
            {
                Console.WriteLine("NÃO HÁ NENHUMA CONTA CADASTRAD.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("=====Banco Curso .NET DIO=====");
            Console.WriteLine("INFORME A OPÇÃO DESEJADA:");
            Console.WriteLine("1 - LISTAR CONTAS");
            Console.WriteLine("2 - INSERIR NOVA CONTA");
            Console.WriteLine("3 - TRANSFERIR");
            Console.WriteLine("4 - SACAR");
            Console.WriteLine("5 - DEPOSITAR");
            Console.WriteLine("C - LIMPAR CONSOLE");
            Console.WriteLine("X - SAIR");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
