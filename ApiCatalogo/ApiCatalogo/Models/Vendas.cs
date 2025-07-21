using ApiCatalogo.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiCatalogo.Model;

public class Vendas
{
    [Key]
    public int VendaId { get; set; }

    public DateTime DataVenda { get; set; }

    public decimal ValorTotal { get; set; }

    public int ProdutoId { get; set; }
    public required Produto Produto { get; set; }

    [Required]
    public int Quantidade { get; set; }
    public DateTime Data { get; internal set; }

}

   