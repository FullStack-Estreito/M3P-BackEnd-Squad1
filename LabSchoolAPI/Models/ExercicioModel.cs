using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions
using LabSchoolAPI.Enuns;

namespace LabSchoolAPI.Models
{
        public class ExercicioModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Materia { get; set; }

        [Required]
        [MinLenght(8, ErrorMessage = "Nome deve ter no mínimo 5 caracteres.")]
        [MaxLenght(64, ErrorMessage = "Nome deve ter no máximo 50 caracteres.")]
        public string NomeExercicio { get; set; } //titulo do exercicio

        [Required]
        [MinLenght(15, ErrorMessage = "Nome deve ter no mínimo 5 caracteres.")]
        [MaxLenght(255, ErrorMessage = "Nome deve ter no máximo 50 caracteres.")]
        public string DescricaoListaExercicios { get; set; }

        [Required]
        public int AlunoID { get; set; }

        [Required]
        public int ProfessorID { get; set; }

        public bool Status { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "A data_conclusao deve estar no formato DD/MM/AAAA.")]
        public  string DataConclusao {get; set}
    }


}