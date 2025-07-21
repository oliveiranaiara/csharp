using MiniCaixaEletronicoMVC.Models;
using MiniCaixaEletronicoMVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniCaixaEletronicoMVC.Controllers
{
    class ContaController
    {
        //o controlador conhece  e tem acesso ao model e view
        private readonly Conta _model;
        private readonly ContaView _view;

        //É O CONTRSUTOR JA CRIANDO O OBJETO COM ESTES VALORES
        public ContaController()
        {
            _model = new Conta(3000); // saldo inicial
            _view = new ContaView();
        }


        public void Iniciar()
        {
            bool continuar = true;

            while (continuar)
            {
                //pede para a View mostrar o menu e dar opçãp ao usuário
                //montar um menu
                string opcao = _view.ObterOpcaoMenu(_model.Saldo);

                switch (opcao)
                {
                    case "1":
                        //visualizar saldo
                        _view.ExibirMensagem($"Seu saldo detalhado é: {_model.Saldo:C}");
                        break;
                    case "4":
                        //sair do sistema
                        continuar = false;
                        break;
                    default:
                        //opção inválida
                        _view.ExibirMensagem("Opção inválida. Tente novamente.");
                        break;
                }

                if (continuar)
                {
                    _view.PausarVoltarAoMenu();
                }


            }

            Console.WriteLine("Obrigado por usar o Banco CSharp S.A. (MVC)! Até logo!");
        }


    }
}

