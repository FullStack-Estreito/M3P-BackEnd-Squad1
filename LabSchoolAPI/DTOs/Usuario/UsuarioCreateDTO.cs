using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioCreateDTO
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        public TipoGenero Genero { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        public double? Matricula { get; set; }

        public int? ProfessorId { get; set; }

        [Required]
        public int WhiteLabelId { get; set; }
    }
 }