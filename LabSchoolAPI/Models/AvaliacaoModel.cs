using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.Models
{
    public class AvaliacaoModel
    {

        [Key]
        public int ID { get; set; } //chave primaria

        [Required] 
        public string Titulo { get; set; }

        [Required]
        public string Materia { get; set; }

        [Required] 
        [MinLength(15, ErrorMessage = "Nome deve ter no mínimo 15 caracteres.")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        [Required] 
        public double Nota { get; set; }

        public bool StatusAtivo { get; set; }  // Status (Ativo/Inativo)

        [Required]
        public double PontuacaoMaxima {get; set;}

        [Required] 
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "A data_conclusao deve estar no formato DD/MM/AAAA.")]
        public string DataRealizacao {get; set;}


        // Chaves e relacionamentos abaixo //

        public int AlunoID { get; set; }
        
        public virtual UsuarioModel Aluno { get; set; }

        public int ProfessorID { get; set; }

        public virtual UsuarioModel Professor { get; set; }
    }   

}