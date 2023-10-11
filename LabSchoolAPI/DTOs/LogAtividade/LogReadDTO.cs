using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class LogReadDTO
    {
         
        public TipoAtividade Atividade { get; set; }

        public string Descricao { get; set; }
    }
}