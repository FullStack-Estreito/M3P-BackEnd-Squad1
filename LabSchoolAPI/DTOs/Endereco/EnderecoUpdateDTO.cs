using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.DTOs
{
    public class EnderecoUpdateDTO
    {   

        [MaxLength(9, ErrorMessage = "Digite o cep nesse formato: XXXXX-XXX")]
        [MinLength(9, ErrorMessage = "Digite o cep nesse formato: XXXXX-XXX")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]
        public string Cidade { get; set; }

        public TipoEstado Estado { get; set; } //enum

        public string Logradouro { get; set; }

        [MaxLength(10, ErrorMessage = "Este campo aceita até 10 caracteres")] 
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]
        public string Complemento { get; set; }

        [MaxLength(120, ErrorMessage = "Este campo aceita até 120 caracteres")] 
        public string Bairro { get; set; }

        [MaxLength(120, ErrorMessage = "Este campo aceita até 120 caracteres")] 
        public string Referencia { get; set; }
    }
}