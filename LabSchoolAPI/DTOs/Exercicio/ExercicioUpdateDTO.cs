using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs.Exercicio
{
    public class ExercicioUpdateDTO
    {   
        [Required]
        public int ExercicioId { get; set; }
        
        public string Titulo {get; set;}

        
        public string Materia { get; set; }

       
        public string Descricao { get; set; }

        
        public int ProfessorId { get; set; }

        
        public int AlunoId { get; set; }

        
        public DateTime DataConclusao { get; set; }
    }
}