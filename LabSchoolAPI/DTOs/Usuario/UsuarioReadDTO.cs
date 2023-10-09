using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.DTOs.Endereco;

namespace LabSchoolAPI.DTOs.Usuario
{
    public class UsuarioReadDTO
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public TipoGenero Genero { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public TipoUsuario Tipo { get; set; }

        public EnderecoReadDTO Endereco { get; set; } 

        public bool StatusAtivo { get; set; }

        public double Matricula { get; set; }

        public int ProfessorId { get; set; }

        public int WhiteLabelId { get; set; }
    }
}