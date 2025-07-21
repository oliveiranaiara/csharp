using System.ComponentModel.DataAnnotations;

namespace AulaEntity.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        //propriedade de navegação
        public ICollection<Student>? Students { get; set; }


    }
}
