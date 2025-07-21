using MiniCaixaEletronico2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronico2.Businness;
public class ContaService
{
    // O Serviço DEPENDE do Repositório para funcionar.
    private readonly ContaRepositorio _repositorio = new ContaRepositorio();

    public decimal VerSaldo()
    {
        // Busca a conta usando o repositório.
        var conta = _repositorio.Getconta();
        // Retorna a informação solicitada.
        return conta.Saldo;
    }

    public void RealizarDeposito(decimal valor)
    {
        // Regra de negócio: Por exemplo, um depósito não pode ser de valor zero ou negativo.
        if (valor <= 0)
        {
            // Em uma aplicação real, poderíamos lançar uma exceção.
            // Por enquanto, apenas ignoramos a operação.
            return;
        }

        var conta = _repositorio.Getconta();
        conta.Depositar(valor);
        // O repositório não precisa de um método 'Salvar' por enquanto.
    }

    public bool RealizarSaque(decimal valor)
    {
        // Regra de negócio: O valor do saque deve ser positivo.
        if (valor <= 0)
        {
            return false;
        }

        var conta = _repositorio.Getconta();

        // A lógica de verificar se o saldo é suficiente está na própria
        // entidade Conta (no método Sacar), o que é uma boa prática de POO.
        // O serviço apenas orquestra a chamada.
        bool sucesso = conta.Sacar(valor);

        return sucesso;
    }
}

