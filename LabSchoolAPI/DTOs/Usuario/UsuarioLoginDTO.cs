using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string Email { get; set; }

        // [Required]
        // public string Senha { get; set; }
    }

}