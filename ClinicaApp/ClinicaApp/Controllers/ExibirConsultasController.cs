using Microsoft.AspNetCore.Mvc;

namespace ClinicaApp.Controllers
{
    public class ExibirConsultasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
