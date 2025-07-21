using System.ComponentModel.DataAnnotations;
using System.Data;


namespace ClinicaApp.Models

{
    public class Agendamento
    {
       [Key]
       public int AgendamentoID { get; set; }

        public string Cliente { get; set; }

        public string Medico { get; set; }

        public string Especialidade { get; set; }

        public DateTime DataConsulta { get; set; }

        public string TipoAtendimento { get; set; }



    }
}
