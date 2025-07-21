using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronico2.Data
{
    public class ContaRepositorio
    {
        //emulação de uma conexão com banco de dados o _conta é o objeto de manipulação de dados
        private static readonly Conta _conta = new Conta(12345, 1000.00m);

        public Conta Getconta()
        {    
            // retorna a conta
             return _conta;
        }

    }
}
