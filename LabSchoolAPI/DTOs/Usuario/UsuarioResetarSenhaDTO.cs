using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioResetarSenhaDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]
        public string Email { get; set; }
    }
}