using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoCreateDTO
    {   
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double PontuacaoMaxima { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Nota { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataRealizacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoProfessor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AlunoId { get; set; }

    }
}