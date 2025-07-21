using ClinicaApp.Data;
using ClinicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ClientesController : Controller
{
    // Injeção de dependência do contexto do Entity Framework
    private readonly ClinicaContext _context;

    public ClientesController(ClinicaContext context)
    {
        _context = context;
    }

    // GET: /Clientes
    public async Task<IActionResult> Index()
    {
        var clientes = await _context.Clientes.ToListAsync();
        return View(clientes);
    }

    // GET: /Clientes/Create
    public IActionResult Create()
    {
        // Método para abrir o formulário de cadastro
        return View();
    }


    // Ação POST: recebe os dados preenchidos do formulário e insere no banco
    [HttpPost] // Indica que este método será chamado apenas via requisição POST
    [ValidateAntiForgeryToken] // Protege contra ataques de falsificação de requisição (CSRF)
    public async Task<IActionResult> Create([Bind("Nome, Dtnasc, Salario")] Cliente cliente)
    {
        // Adiciona o objeto cliente à lista de clientes rastreados pelo Entity Framework
        _context.Add(cliente);

        // Salva as alterações de forma assíncrona no banco de dados
        await _context.SaveChangesAsync();

        // Redireciona o usuário para a página de listagem de clientes (Index)
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound(); // Retorna um erro 404 se o id for nulo
        }
        var cliente = await _context.Clientes.FindAsync(id); // Busca o cliente pelo id
        if (cliente == null)
        {
            return NotFound(); // Retorna um erro 404 se o cliente não for encontrado
        }
        return View(cliente); // Retorna a view de edição com o cliente encontrado
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,DtNasc,Salario")] Cliente cliente)
    {
        if (!ClienteExists(cliente.ClienteId))
        {
            return NotFound();
        }


        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        try
        {
            _context.Clientes.Update(cliente); // Atualiza o cliente no contexto do banco de dados  
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(cliente.ClienteId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.ClienteId == id);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound(); // Retorna um erro 404 se o id for nulo
        }
        var cliente = await _context.Clientes.FindAsync(id); // Busca o cliente pelo id
        if (cliente == null)
        {
            return NotFound(); // Retorna um erro 404 se o cliente não for encontrado
        }
        return View(cliente); // Retorna a view de exclusão com o cliente encontrado
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}