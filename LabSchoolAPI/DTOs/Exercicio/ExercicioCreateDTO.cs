using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class ExercicioCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Titulo {get; set;}

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        [Required]
        public int CodigoProfessor { get; set; }

        [Required]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataConclusao { get; set; }
    }
}