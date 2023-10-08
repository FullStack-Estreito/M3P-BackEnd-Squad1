using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs.Avaliacao
{
    public class AvaliacaoUpdateDTO
    {
        public int AvaliacaoId { get; set; }
        public string Titulo { get; set; }

        public string Materia { get; set; }

        public string Descricao { get; set; }

        public double Nota { get; set; }

        public int PontuacaoMaxima {get; set;}

        public string DataRealizacao {get; set;}
 
        public int ProfessorID { get; set; }
    }
}