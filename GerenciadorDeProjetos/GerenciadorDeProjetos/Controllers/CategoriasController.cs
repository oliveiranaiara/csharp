using GerenciadorDeProjetos.Data;
using GerenciadorDeProjetos.DTOs;
using GerenciadorDeProjetos.Models;
using GerenciadorDeProjetos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProjetos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  //Rota base: /api/categorias
    public class CategoriasController : ControllerBase
    {

        // SAI
        // private readonly ICategoriaRepository _categoriaRepository;
        // public CategoriasController(ICategoriaRepository categoriaRepository)
        // {
        //     _categoriaRepository = categoriaRepository;
        // }

        // ENTRA
        private readonly IUnitOfWork _uow;
        public CategoriasController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        [HttpPost]
        // SAI
        // public async Task<IActionResult> CriarCategoria([FromBody] Categoria categoria)
        // ENTRA
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaDto categoriaDto)
        {
            // Mapeamento do DTO para a Entidade
            var categoria = new Categoria
            {
                Nome = categoriaDto.Nome
            };

            await _uow.CategoriaRepository.AddAsync(categoria);
            await _uow.CommitAsync();

            // Mapeamento da Entidade para um DTO de retorno (opcional, mas boa prática)
            var categoriaResultDto = new CategoriaComProdutosDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                // Usamos a propriedade .Count da coleção de Produtos para obter o número real.
                // A contagem é sempre precisa e baseada nos dados atuais.
                QuantidadeDeProdutos = categoria.Produtos.Count,

                Produtos = categoria.Produtos.Select(p => new ProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                }).ToList()
            };




            return CreatedAtAction(nameof(BuscarCategoriaPorId), new { id = categoria.Id }, categoriaResultDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCategoriaPorId(int id)
        {
            // O método GetByIdWithProductsAsync já faz o .Include(c => c.Produtos),
            // então a lista de produtos já está disponível na memória.
            var categoria = await _uow.CategoriaRepository.GetByIdWithProductsAsync(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            var categoriaDto = new CategoriaComProdutosDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,

                // SAI
                // QuantidadeDeProdutos = categoria.QuantidadeDeProdutos,

                // ENTRA
                // Aqui está a mágica!
                // Usamos a propriedade .Count da coleção de Produtos para obter o número real.
                // A contagem é sempre precisa e baseada nos dados atuais.
                QuantidadeDeProdutos = categoria.Produtos.Count,

                Produtos = categoria.Produtos.Select(p => new ProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                }).ToList()
            };

            return Ok(categoriaDto);
        }



    }
}
