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
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo aceita até 150 caracteres")]
        public string Nome { get; set; }

        [Required]
        public TipoGenero Genero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "Digite o cpf sem pontuação: XXXXXXXXXXX")]
        [MinLength(11, ErrorMessage = "Digite o cpf sem pontuação: XXXXXXXXXXX")]
        public string Cpf { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(15, ErrorMessage = "Digite o telefone nesse formato: (XX) XXXXX-XXXX")]
        [MinLength(15, ErrorMessage = "Digite o telefone nesse formato: (XX) XXXXX-XXXX")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]
        public string Email { get; set; }

        // [Required]
        // [StringLength(100)]
        // public string Senha { get; set; }

        [Required]
        public TipoUsuario TipoUsuario { get; set; }

        public int Matricula { get; set; }

        public int CodigoProfessor { get; set; }

        public int WhiteLabelId { get; set; }

        [Required]
        public EnderecoCreateDTO Endereco { get; set; } 
    }
 }