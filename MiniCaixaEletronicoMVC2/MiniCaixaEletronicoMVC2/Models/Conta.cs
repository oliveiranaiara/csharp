using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMVC.Models
{
    public class Conta
    {
        public decimal Saldo { get; set; }

        public Conta(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Sacar(decimal valor)
        {

            Saldo -= valor;
            return true;
        }

    }
}


