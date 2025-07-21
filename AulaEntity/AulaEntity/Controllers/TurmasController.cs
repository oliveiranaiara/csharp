using AulaEntity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaEntity.Controllers
{
    public class TurmasController : Controller
    {
        private readonly AulaEntityContext _context;

        public TurmasController(AulaEntityContext context)
        {
            _context = context;
        }



        // GET: Turmas/AlunosPorTurma/1
        public IActionResult AlunosPorTurma(int id)
        {
            var turma = _context.Grade
                .Include(t => t.Students)
                .FirstOrDefault(t => t.GradeId == id);
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }
    }
}

