using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs.Endereco
{
    public class EnderecoUpdateDTO
    {
        public int EnderecoId { get; set; }

        //public EnderecoReadDTO Endereco { get; set; } 
        
        public string Cep { get; set; }

        public string Cidade { get; set; }

        public TipoEstado Estado { get; set; } //enum

        public string Logradouro { get; set; }

        public string Numero { get; set; }
 
        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Referencia { get; set; }
    }
}