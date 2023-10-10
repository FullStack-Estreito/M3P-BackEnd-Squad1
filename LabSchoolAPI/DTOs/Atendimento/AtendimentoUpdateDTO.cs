using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AtendimentoUpdateDTO
    {   
        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string Data { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        public bool StatusAtivo { get; set; }

        public int AlunoId { get; set; }

        public int PedagogoId { get; set; }

    }
}