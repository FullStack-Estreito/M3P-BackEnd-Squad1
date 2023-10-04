using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enuns;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Models
{
    public class UsuarioModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(11)] // CPF no formato sem pontuação.
        public string Cpf { get; set; }

        [StringLength(15)] // telefone no formato (XX) XXXXX-XXXX
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public Genero Genero { get; set; } //enum

        [Required]
        public byte[] PasswordHash { get; set; } // para autenticar login com token jwt
        [Required]
        public byte[] PasswordSalt { get; set; } // para autenticar login com token jwt

        [Required]
        public TipoUsuario Tipo { get; set; } //enum

        public string Matricula { get; set; } // Opcional, apenas para alunos

        public string CodigoRegistroProfessor { get; set; } // Opcional, apenas para professores

        [Required]
        public int IdentificadorEmpresa { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }  // Se true, está Ativo. Se false, está Inativo.

        public int? EnderecoId { get; set; } // Chave estrangeira para tabela de endereços

        public virtual EnderecoModel Endereco { get; set; } // Propriedade de navegação para a tabela de endereços

    }
}