using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs.Exercicio
{
    public class ExercicioCreateDTO
    {
        [Required]
        public string Titulo {get; set;}

        [Required]
        public string Materia { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public int AlunoId { get; set; }

        [Required]
        public DateTime DataConclusao { get; set; }
    }
}