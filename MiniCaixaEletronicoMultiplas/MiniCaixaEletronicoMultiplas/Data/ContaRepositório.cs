using MiniCaixaEletronicoMultiplas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Data
{
    class ContaRepositorio
    {
        //emulando a conexão com o banco de dados
        private readonly List<Conta> _contas = new List<Conta>();

        public ContaRepositorio()
        {
            if (!_contas.Any())
            {
                _contas.Add(new Conta(101, "Mayara", 5000m));
                _contas.Add(new Conta(201, "Patricia", 3800.65m));
                _contas.Add(new Conta(301, "Manoel", 7897.23m));
            }
        }

        public Conta BuscaContaPorNumero(int numeroConta)
        {
            //busca a conta pelo número
            return _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        }
    }
}