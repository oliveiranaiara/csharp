using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMVC.Views
{
    class ContaView
    {
        public string ObterOpcaoMenu(decimal saldo)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine(" BEM-VINDO AO BANCO CSHARP S.A. (MVC)");
            Console.WriteLine("===================================");
            Console.WriteLine($"Seu saldo atual é: {saldo:C}");
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Ver Saldo Detalhado");
            Console.WriteLine("2 - Fazer um Depósito");
            Console.WriteLine("3 - Realizar um Saque");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");

            return Console.ReadLine();

        }
        public decimal SolicitarValor(string mensagem)
        {
            Console.WriteLine(mensagem);
            return decimal.Parse(Console.ReadLine());

        }
        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void PausarVoltarAoMenu()
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
