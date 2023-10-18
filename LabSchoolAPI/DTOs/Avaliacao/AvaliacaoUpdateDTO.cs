using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoUpdateDTO
    {
        public int Id { get; set; }
        
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Titulo { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        public double PontuacaoMaxima { get; set; }

        public double Nota { get; set; }

        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataRealizacao { get; set; }
   
        public int CodigoProfessor { get; set; }

        public int AlunoId { get; set; }
    }
}