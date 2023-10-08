using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs.Usuario.Atendimento
{
    public class AtendimentoUpdateDTO
    {
        public int AtendimentoId { get; set; }

        public DateTime DataRealizacao {get; set;}

        public string Descricao { get; set; }

        public int AlunoId { get; set; }
        
        public int ProfessorId { get; set; }
       
        public bool StatusAtivo { get; set; }  // Status (Ativo/Inativo)
    }
}