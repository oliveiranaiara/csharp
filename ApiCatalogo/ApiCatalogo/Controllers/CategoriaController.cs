using ApiCatalogo.Models;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IRepository _repository;

        public CategoriasController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAsync()
        {
            var categorias = await _repository.GetAllAsync<Categoria>();
            return Ok(categorias);
        }

        // <<< MUDANÇA 1: Adicionar Name = "ObterCategoria" para o Post funcionar
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> GetAsync(int id)
        {
            // <<< MUDANÇA 2: Usar o novo método para buscar com produtos
            var categoria = await _repository.GetCategoriaComProdutosAsync(id);

            // <<< MUDANÇA 3: Validar se a categoria foi encontrada
            if (categoria is null)
            {
                return NotFound("Categoria não localizada.");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostAsync(Categoria categoria)
        {
            if (categoria is null) return BadRequest();

            await _repository.AddAsync(categoria);
            await _repository.SaveChangesAsync();

            // Agora a rota "ObterCategoria" existe e o CreatedAtRouteResult funcionará
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int id, Categoria categoria)
        {
            // <<< MELHORIA: Validar se o ID da rota é o mesmo do objeto
            if (id != categoria.CategoriaId)
            {
                return BadRequest("O id da rota não corresponde ao id do objeto.");
            }

            await _repository.UpdateAsync(categoria);
            await _repository.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            // <<< MUDANÇA: Usar 'await' em vez de '.Result' para evitar bloqueios
            var deleted = await _repository.DeleteAsync<Categoria>(id);

            if (!deleted)
            {
                return NotFound("Categoria não localizada.");
            }

            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}