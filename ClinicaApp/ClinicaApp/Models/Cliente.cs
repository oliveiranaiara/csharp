using System.ComponentModel.DataAnnotations;

namespace ClinicaApp.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; } // ID

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome do Cliente")]
        public string? Nome { get; set; } // NOME

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime Dtnasc { get; set; }// DATA DE NASCIMENTO

        public decimal Salario { get; set; } // SALARIO








    }
}