// See https://aka.ms/new-console-template for more information
// 1. Cria o maestro (o Controller)
using MiniCaixaEletronicoMultiplas.Controllers;

var controlador = new ContaController();

// 2. Dá o comando para ele começar a reger a orquestra.
controlador.Iniciar();
