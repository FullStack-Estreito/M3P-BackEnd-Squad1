using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs.Usuario.Atendimento
{
    public class AtendimentoCreateDTO
    {
        [Required] 
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "A data_conclusao deve estar no formato DD/MM/AAAA.")]
        public DateTime DataRealizacao {get; set;}

        [Required] 
        
        public string Descricao { get; set; }

        [Required] 
        public int AlunoId { get; set; }
        
        [Required] 
        public int ProfessorId { get; set; }
       
        [Required] 
        public bool StatusAtivo { get; set; }  // Status (Ativo/Inativo)

    }
}