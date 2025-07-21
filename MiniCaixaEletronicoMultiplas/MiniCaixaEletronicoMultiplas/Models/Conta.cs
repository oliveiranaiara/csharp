using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Models
{
    public class Conta
    {
        public int NumeroConta { get; set; }
        public string NomeTitular { get; set; }
        public decimal Saldo { get; private set; }


        public Conta(int numeroConta, string nomeTitular, decimal saldoInicial)
        {
            Saldo = saldoInicial;
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
        }

        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }

        public bool Sacar(decimal valor)
        {
            if (valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }
    }
}
