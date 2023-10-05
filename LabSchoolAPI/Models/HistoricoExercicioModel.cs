using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    public class HistoricoExercicioModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime DataHoraRealizacao { get; set; }

        [Required]
        public float NotaOuPontuacao { get; set; } // Tipo alterado para float

        [Required]
        public bool Status { get; set; } // True para concluído, False para não concluído

        [StringLength(512)] // opcional
        public string Observacoes { get; set; }

        [Required]
        [ForeignKey("Aluno")] 
        public int UsuarioAlunoId { get; set; }

        [Required]
        [ForeignKey("Exercicio")] 
        public int ExercicioId { get; set; }

        public virtual UsuarioModel Aluno { get; set; }  // Propriedade de navegação para a tabela de alunos.

        public virtual ExercicioModel Exercicio { get; set; }  // Propriedade de navegação para a tabela de exercícios.
    }
}
