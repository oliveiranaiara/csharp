namespace MiniCaixaEletronico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal saldo = 1500.78m;  //o m no final indica que é um decimal
            bool continuar = true;

            // laço de repetição para o menu principal
            while (continuar)
            { //o valor dentro do {} sempre é esperado true
                Console.Clear(); //limpa o console
                Console.WriteLine("Bem-vindo ao Mini Caixa Eletrônico!");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Saldo atual: R$ " + saldo.ToString("c")); //c indica que é uma moeda local
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1 - Ver Saldo Detalhado");
                Console.WriteLine("2 - Fazer um Depósito");
                Console.WriteLine("3 - Realizar um Saque");
                Console.WriteLine("4 - Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine(); // lê a opção do usuário
                if (opcao == "4"){
                    continuar = false; //se a opção for 4, encerra o laço
                }

            }
            Console.WriteLine("Até mais...");
        }

    }
}