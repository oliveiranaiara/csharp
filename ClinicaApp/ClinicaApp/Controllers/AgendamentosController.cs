using ClinicaApp.Data;
using ClinicaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApp.Controllers
{
    public class AgendamentosController : Controller

    {


        private readonly ClinicaContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult MarcarConsultas()
        {
            return View();
        }

        public IActionResult ExibirConsultas()
        {
            return View();
        }

        // Ação POST: recebe os dados preenchidos do formulário e insere no banco
        [HttpPost] // Indica que este método será chamado apenas via requisição POST
        [ValidateAntiForgeryToken] // Protege contra ataques de falsificação de requisição (CSRF)
        public async Task<IActionResult> Creat(Agendamento agendamentos)
        {
            _context.Agendamentos.Add(agendamentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}