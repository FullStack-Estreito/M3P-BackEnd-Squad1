using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace LabSchoolAPI.Models
{
    public class ExercicioModel 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Materia { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataConclusao { get; set; }


        // Chaves e relacionamentos abaixo

        public int AlunoID { get; set; }

        public virtual UsuarioModel Aluno { get; set; }
        
        public int ProfessorID { get; set; }
        
        public virtual UsuarioModel Professor { get; set; }
    }
}