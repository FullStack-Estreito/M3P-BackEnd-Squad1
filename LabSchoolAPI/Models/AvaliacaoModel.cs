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

        [Required]
        public bool Status { get; set; }

        [Required]
        public double PontuacaoMaxima {get; set;}

        [Required] 
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "A data_conclusao deve estar no formato DD/MM/AAAA.")]
        public string DataRealizacao {get; set;}

    }

}