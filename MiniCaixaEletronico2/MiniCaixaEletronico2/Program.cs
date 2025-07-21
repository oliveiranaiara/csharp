
using MiniCaixaEletronico2.Businness;

//instanciar o serviço 
var ContaService = new ContaService();
bool continuar = true;

// laço de repetição para o menu principal
while (continuar)
{ //o valor dentro do {} sempre é esperado true
    Console.Clear(); //limpa o console
    Console.WriteLine("Bem-vindo ao Mini Caixa Eletrônico!");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("Saldo inicial: R$ " + ContaService.VerSaldo().ToString("F2")); //c indica que é uma moeda local
    Console.WriteLine("Selecione uma opção");
    Console.WriteLine("1 - Ver Saldo Detalhado");
    Console.WriteLine("2 - Fazer um Depósito");
    Console.WriteLine("3 - Realizar um Saque");
    Console.WriteLine("4 - Sair");
    Console.Write("Opção: ");
    string opcao = Console.ReadLine(); // lê a opção do usuário
    if (opcao == "4")
    {
        continuar = false; //se a opção for 4, encerra o laço
    }

}
Console.WriteLine("Até mais...");
