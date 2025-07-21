using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public class ContaPoupanca : Conta
    {
        // NÃO preciso declarar o campo _saldo novamente, pois ele já é herdado da classe base ContaBancaria.


        //atributo da classe filha
        public decimal TaxaJuros { get; set; }


        //uma taxa fxa de saque
        private const double TAXA_SAQUE = (double)2.78m;

        public ContaPoupanca(string numero, string titular, decimal saldo, decimal taxaJuros)
            : base(numero, titular, saldo)
        {
            TaxaJuros = taxaJuros;
        }

        public void AdcionarJuros()
        {
            decimal juros = (decimal)Saldo * (decimal)TaxaJuros / 100;
            Saldo += juros;
            Console.WriteLine($"Juros de {TaxaJuros}% adicionados. Novo saldo: {Saldo:C}");

        }

        public override void Sacar(decimal valor)
        {
            Console.WriteLine($"Tentativa de saque valor: {valor:C} na conta {this.GetType().Name} de {this.Titular}");

            if (valor <= 0)
            {
                Console.WriteLine("Valor de saque inválido. O valor deve ser maior que zero.");
                return;
            }

            //nova regra de saque
            if (valor + (decimal)TAXA_SAQUE <= Saldo)
            {
                Saldo -= (valor + (decimal)TAXA_SAQUE);
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque, incluindo a taxa de saque.");
            }

        }
    }
}

