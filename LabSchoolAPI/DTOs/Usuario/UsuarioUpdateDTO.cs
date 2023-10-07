using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Required]
        public int UsuarioId { get; set; } 

        [StringLength(200)]
        public string Nome { get; set; }

        public TipoGenero? Genero { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public TipoUsuario? Tipo { get; set; }

        public double? Matricula { get; set; }

        public int? ProfessorId { get; set; }

        public int? WhiteLabelId { get; set; }
    }
}