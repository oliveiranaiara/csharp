using ApiCatalogo.Models;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //dependencia diretta do Entity Framework Core
        // antes: private readonly AppDbContext _context;

        //pelo repositório
        private readonly IRepository _repository;

        public ProdutosController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet] // api/produtos
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            //logica do EF direta no controller 
            var produtos = await _repository.GetAllAsync<Produto>();
            return Ok(produtos);
        }







        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _repository.GetByIdAsync<Produto>(id);

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            if (produto is null) return BadRequest();

            // Verifica se o produto já existe
            await _repository.AddAsync(produto);
            //SALVAR AS ALTERAÇÕES NO BANCO DE DADOS    
            await _repository.SaveChangesAsync();// Espera a tarefa ser concluída
            //return CreatedAtAction(nameof(Get), new { id = produto.ProdutoId }, produto);
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            //return StatusCode(201);
        }

        [HttpPut("{id:int}")] // /produtos/1
        public async Task<ActionResult> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(produto);
            await _repository.SaveChangesAsync();

            return Ok(produto);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = _repository.DeleteAsync<Produto>(id).Result;

            if (!deleted)
            {
                return NotFound();
            }
            await _repository.SaveChangesAsync();
            return NoContent();
        }





    }
}