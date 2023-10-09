using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoCreateDTO
    {   
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Materia { get; set; }

        [Required]
        public double PontuacaoMaxima { get; set; }

        [Required]
        public double Nota { get; set; }

        [Required]
        public DateTime DataRealizacao { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public int AlunoId { get; set; }

    }
}