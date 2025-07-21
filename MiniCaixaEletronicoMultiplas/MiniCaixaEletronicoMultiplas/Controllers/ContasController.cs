using MiniCaixaEletronicoMultiplas.Data;
using MiniCaixaEletronicoMultiplas.Models;
using MiniCaixaEletronicoMultiplas.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniCaixaEletronicoMultiplas.Controllers
{
    public class ContaController
    {

        private readonly ContaRepositorio _repositorio;
        private readonly ContaView _view;

        public ContaController()
        {
            _repositorio = new ContaRepositorio();
            _view = new ContaView();
        }
        public void Iniciar()
        {


            while (true)
            {
                int numeroConta = _view.SolicitarNumeroConta();
                Conta contaLogada = _repositorio.BuscaContaPorNumero(numeroConta);
                if (contaLogada != null)
                {
                    ExecutarMenuDaConta(contaLogada);
                }
                else
                {
                    _view.ExibirMensagem("Conta não encontrada. Tente novamente.");
                    _view.PausarEVoltarAoMenu();
                }

            }
        }


        private void ExecutarMenuDaConta(Conta conta)
        {

            bool continuar = true;
            while (continuar)
            {
                // Pede para a View mostrar o menu e dar a opção do usuário.
                string opcao = _view.ObterOpcaoDoMenu(conta.Saldo, conta.NomeTitular);

                switch (opcao)
                {
                    case "1":
                        // Ação: Apenas mostrar o saldo.
                        _view.ExibirMensagem($"Seu saldo detalhado é: {conta.Saldo:C}");
                        break;

                    case "2":
                        // Ação: Depositar
                        // 1. Pede para a View solicitar o valor.
                        var valorDeposito = _view.SolicitarValor("Digite o valor do depósito: ");
                        // 2. Manda o Model executar a regra de negócio.
                        conta.Depositar(valorDeposito);
                        // 3. Pede para a View mostrar o resultado.
                        _view.ExibirMensagem("Depósito realizado com sucesso!");
                        break;

                    case "3":
                        // Ação: Sacar
                        var valorSaque = _view.SolicitarValor("Digite o valor do saque: ");
                        // Pede para o Model tentar executar a operação e nos diz se deu certo.
                        bool sucesso = conta.Sacar(valorSaque);
                        if (sucesso)
                        {
                            _view.ExibirMensagem("Saque realizado com sucesso!");
                        }
                        else
                        {
                            _view.ExibirMensagem("Operação falhou. Verifique o valor digitado ou seu saldo.");
                        }
                        break;

                    case "4":
                        // Ação: Sair
                        continuar = false;
                        _view.ExibirMensagem("Obrigado por usar nossos serviços. Volte sempre!");
                        break;

                    default:
                        _view.ExibirMensagem("Opção inválida. Tente novamente.");
                        break;
                }

                if (continuar)
                {
                    _view.PausarEVoltarAoMenu();
                }
            }
        }
    }
}

