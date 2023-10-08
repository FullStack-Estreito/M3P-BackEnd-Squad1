using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs.Avaliacao
{
    public class AvaliacaoCeateDTO
    {
        
        public string Titulo { get; set; }

        public string Materia { get; set; }

        [MinLength(15, ErrorMessage = "Nome deve ter no mínimo 15 caracteres.")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        public double Nota { get; set; }

        public int PontuacaoMaxima {get; set;}

        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "A data_conclusao deve estar no formato DD/MM/AAAA.")]
        public string DataRealizacao {get; set;}

        public int AlunoID { get; set; }
        
       
        public int ProfessorID { get; set; }
     
    }
}