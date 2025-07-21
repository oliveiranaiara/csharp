using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMVC.Models
{
    public class ContaView
    {
        public decimal Saldo { get; set; }

        public ContaView(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public ContaView()
        {
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

        internal string ObterOpcaoMenu(decimal saldo)
        {
            throw new NotImplementedException();
        }

        internal void ExibirMensagem(string v)
        {
            throw new NotImplementedException();
        }

        internal void PausarVoltarAoMenu()
        {
            throw new NotImplementedException();
        }

        internal decimal SolicitarValor(string v)
        {
            throw new NotImplementedException();
        }
    }
}

