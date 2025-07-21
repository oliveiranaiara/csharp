using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeProjetos.DTOs;
// DTO para receber os dados de criação de um novo produto.
public class CriarProdutoDto
{
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(120)]
    public string Nome { get; set; }

    [Required]
    [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required]
    public int CategoriaId { get; set; }
}



 

