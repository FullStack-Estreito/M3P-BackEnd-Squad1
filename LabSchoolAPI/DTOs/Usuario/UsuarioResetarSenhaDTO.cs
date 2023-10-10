using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioResetarSenhaDTO
    {
        [Required]
        public string Email { get; set; }
    }
}