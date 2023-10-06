using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace LabSchoolAPI.Models
{
    public class ExercicioModel 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Matéria { get; set; }

        [Required]
        [StringLength(100)]
        public string Título { get; set; }

        [Required]
        [StringLength(200)]
        public string Descrição { get; set; }

        [Required]
        public bool StatusAtividade { get; set; }

        [Required]
        public bool StatusConclusão { get; set; }

        [Required]
        public DateTime DataConclusão { get; set; }

        [Required]
        [StringLength(200)]
        public string Observação { get; set; }

        [ForeignKey("UsuarioModel")]
        public int AlunoID { get; set; }
        
        [ForeignKey("UsuarioModel")]
        public int ProfessorID { get; set; }

        public virtual UsuarioModel Aluno { get; set; }

        public virtual UsuarioModel Professor { get; set; }
    }
}