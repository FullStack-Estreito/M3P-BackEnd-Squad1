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
        public decimal NotaOuPontuacao { get; set; }

        [Required]
        public bool Status { get; set; } // True para concluído, False para não concluído

        [StringLength(512)] // opcional
        public string Observacoes { get; set; }

        [Required]
        public int UsuarioAlunoId { get; set; }

        [Required]
        public int ExercicioId { get; set; }

        [ForeignKey("UsuarioAlunoId")]
        public virtual UsuarioModel Aluno { get; set; }  // Propriedade de navegação para a tabela de alunos.

        [ForeignKey("ExercicioId")]
        public virtual ExercicioModel Exercicio { get; set; }  // Propriedade de navegação para a tabela de exercícios.
        

    }
}