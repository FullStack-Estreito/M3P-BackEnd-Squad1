using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class ExercicioUpdateDTO
    {   
        [MaxLength(64, ErrorMessage = "Este campo aceita até 64 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo aceita no mínimo 8 caracteres")]
        public string Titulo {get; set;}

        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        [MaxLength(64, ErrorMessage = "Este campo aceita até 64 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo aceita no mínimo 8 caracteres")]
        public string Descricao { get; set; }

        
        public int CodigoProfessor { get; set; }

        
        public int AlunoId { get; set; }

        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataConclusao { get; set; }
    }
}