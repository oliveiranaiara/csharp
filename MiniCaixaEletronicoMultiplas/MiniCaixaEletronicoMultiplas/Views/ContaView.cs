using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Views;
public class ContaView
{
    public int SolicitarNumeroConta()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine(" BEM-VINDO AO BANCO CSHARP S.A. (MVC)");
        Console.WriteLine("===================================");
        Console.WriteLine("Digite o número da sua conta: ");
        return int.Parse(Console.ReadLine());

    }

    public string ObterOpcaoDoMenu(decimal saldo, string nomeTitular)
    {
        Console.Clear();

        Console.WriteLine($"Olá {nomeTitular}, Bem Vindo");
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
        Console.Write(mensagem);
        // Tratamento de erro de conversão pode ser adicionado aqui depois
        return decimal.Parse(Console.ReadLine());
    }

    public void ExibirMensagem(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    public void PausarEVoltarAoMenu()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}