using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronico2.Data
{
    public class Conta
    {
        public int NumeroConta { get; set; }
        public decimal Saldo { get; set; }
       

        //Construtor
        public Conta(int numeroConta, decimal saldo) { 

            NumeroConta = numeroConta;
            Saldo = saldo;
        }
        public void Depositar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo) 
            {
                Saldo = valor;
            }
            else
            {
                Console.WriteLine("Valor inválido para saque.");
            }
        }

        internal bool Sacar(decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
