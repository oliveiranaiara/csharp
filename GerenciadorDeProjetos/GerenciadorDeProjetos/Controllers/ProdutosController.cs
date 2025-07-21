using GerenciadorDeProjetos.DTOs;
using GerenciadorDeProjetos.Models;
using GerenciadorDeProjetos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProjetos.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota base: /api/produtos
    public class ProdutosController : ControllerBase
    {


        private readonly IUnitOfWork _uow;
        public ProdutosController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // Endpoint para criar um novo produto.
        // POST /api/produtos
        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoDto produtoDto)
        {
            // 1. Busca a categoria usando o repositório de categoria
            var categoria = await _uow.CategoriaRepository.FindByIdAsync(produtoDto.CategoriaId);

            if (categoria == null)
            {
                return BadRequest("A CategoriaId fornecida não existe.");
            }

            // Mapeamento do DTO para a Entidade
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                CategoriaId = produtoDto.CategoriaId
            };

            // 2. Adiciona o novo produto usando o repositório de produto
            await _uow.ProdutoRepository.AddAsync(produto);

            // 3. Modifica a entidade Categoria
            categoria.QuantidadeDeProdutos++;
            // Não precisamos de um método "Update" no repositório para isso,
            // pois o EF Core já está rastreando a entidade 'categoria' que buscamos.
            // Qualquer alteração nela será detectada.

            // 4. Salva TODAS as alterações de uma vez só!
            // Tanto a adição do novo produto quanto a atualização da categoria
            // serão enviadas ao banco de dados em uma única transação.
            // Se qualquer uma das operações falhar aqui, nada será salvo.
            await _uow.CommitAsync();

            var produtoResultDto = new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };

            return Ok(produtoResultDto);
        }

    }


}


