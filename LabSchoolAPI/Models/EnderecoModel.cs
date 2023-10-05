using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enuns;

namespace LabSchoolAPI.Models
{
    public class EnderecoModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(9)] // CEP no formato XXXXX-XXX
        public string Cep { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        public TipoEstado Estado { get; set; } //enum

        [Required]
        [StringLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(10)] 
        public string Numero { get; set; }

        [StringLength(100)] // Campo opcional
        public string Complemento { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [StringLength(255)] // Campo opcional
        public string PontoReferencia { get; set; }
    }
}