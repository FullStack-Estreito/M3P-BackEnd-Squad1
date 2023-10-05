using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enuns;

namespace LabSchoolAPI.Models
{
    public class AvaliacaoModel
    {

        [Key]
        public int ID { get; set; } //chave primaria

        [Required] 
        public string NomeAvaliacao { get; set; }

        [Required] 
        [MinLenght(15, ErrorMessage = "Nome deve ter no mínimo 15 caracteres.")]
        [MaxLenght(255, ErrorMessage = "Nome deve ter no máximo 255 caracteres.")]
        public string DescricaoAvaliacao { get; set; }

        [Required] 
        public double NotaAvaliacao { get; set; }

        [ForeignKey("Aluno")] 
        public int AlunoID { get; set; }

        [ForeignKey("Professor")] 
        public int ProfessorID { get; set; }
        public bool Status { get; set; }

    }

}