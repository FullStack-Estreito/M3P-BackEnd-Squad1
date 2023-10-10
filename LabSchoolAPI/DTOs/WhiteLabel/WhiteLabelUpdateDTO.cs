using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class WhiteLabelUpdateDTO
    {   
        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]      
        public string NomeEmpresa { get; set; }

        [MaxLength(200, ErrorMessage = "Este campo aceita até 200 caracteres")]
        public string Slogan { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Cores { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]    
        public string UrlLogo { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Complemento { get; set; }

    }
}