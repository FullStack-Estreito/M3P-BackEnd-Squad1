using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    public class ExercicioModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Materia { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8)]
        public string NomeExercicio { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string DescricaoExercicios { get; set; }

        [Required]
        public int UsuarioAlunoId { get; set; }

        [ForeignKey("UsuarioAlunoId")]
        public virtual UsuarioModel UsuarioAluno { get; set; }

        [Required]
        public int UsuarioProfessorId { get; set; }

        [ForeignKey("UsuarioProfessorId")]
        public virtual UsuarioModel UsuarioProfessor { get; set; }

        [Required]
        public bool Status { get; set; }  // true para Ativo e false para Inativo
    }
}
