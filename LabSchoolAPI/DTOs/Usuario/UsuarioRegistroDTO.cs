using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs.Usuario
{
    public class UsuarioRegistroDTO
    {
        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required]
        public TipoGenero Genero { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario TipoUsuario { get; set; }

        public int? Matricula { get; set; }
        public string CodigoProfessor { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public int WhiteLabelId { get; set; }
    }
}