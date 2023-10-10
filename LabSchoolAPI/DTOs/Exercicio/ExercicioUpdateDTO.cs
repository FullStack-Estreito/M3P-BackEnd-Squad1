using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class ExercicioUpdateDTO
    {   
        [MaxLength(16, ErrorMessage = "Este campo aceita até 16 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo aceita até 8 caracteres")]
        public string Titulo {get; set;}

        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        [MaxLength(255, ErrorMessage = "Este campo aceita até 255 caracteres")]
        [MinLength(15, ErrorMessage = "Este campo aceita até 15 caracteres")]
        public string Descricao { get; set; }

        
        public int CodigoProfessor { get; set; }

        
        public int AlunoId { get; set; }

        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataConclusao { get; set; }
    }
}