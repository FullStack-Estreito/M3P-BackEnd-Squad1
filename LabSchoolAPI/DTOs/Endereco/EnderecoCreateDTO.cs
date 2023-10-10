using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.DTOs
{
    public class EnderecoCreateDTO
    {
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(9, ErrorMessage = "Digite o cep nesse formato: XXXXX-XXX")]
        [MinLength(9, ErrorMessage = "Digite o cep nesse formato: XXXXX-XXX")] // CEP no formato XXXXX-XXX
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")]
        public string Cidade { get; set; }

        [Required]
        public TipoEstado Estado { get; set; } //enum

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo aceita até 20 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Este campo aceita até 10 caracteres")] 
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo aceita até 100 caracteres")] // Campo opcional
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(120, ErrorMessage = "Este campo aceita até 120 caracteres")] 
        public string Bairro { get; set; }

        [MaxLength(120, ErrorMessage = "Este campo aceita até 120 caracteres")]  // Campo opcional
        public string Referencia { get; set; }
    }
    
}