
using ContaBancaria;



Console.WriteLine("\n-----------------------------------------------------\n");

List<Conta> todasAsContas = new List<Conta>();

todasAsContas.Add(new ContaCorrente("001", "João da Silva", 1000m, 500));
todasAsContas.Add(new ContaPoupanca("002", "Maria Oliveira", 2000, 5.0m));

double valorSaque = 1300;

foreach (var conta in todasAsContas)
{
    conta.ExibirSaldo();
    conta.Sacar((decimal)valorSaque);
    conta.ExibirSaldo();
}

//Criar os objetos
ContaCorrente contaCorrente = new ContaCorrente("CC-001", "João Silva", 1000m, 500);
ContaPoupanca contaPoupanca = new ContaPoupanca("CP-002", "Maria Oliveira", 2000m, 5.0m);

var seguro = new SeguroDeVida();

//lista do tipo interface
List<ITributavel> listaDeTributaveis = new List<ITributavel>();

listaDeTributaveis.Add(contaCorrente);
listaDeTributaveis.Add(seguro);
//listaDeTributaveis.Add(contaPoupanca);

Console.WriteLine("Calculando impostos de todos os tributáveis:");
double totalImpostos = 0;
foreach (var item in listaDeTributaveis)
{
    double tributodoItem = item.CalcularImposto();
    totalImpostos += tributodoItem;
    Console.WriteLine($"Tributo apra o item {item.GetType().Name} : {tributodoItem}");
}
Console.WriteLine($"Total de impostos: {totalImpostos}");

