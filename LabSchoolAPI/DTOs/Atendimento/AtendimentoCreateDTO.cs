using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AtendimentoCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Digite a data nesse formato: dd-mm-aaaa")]
        public string DataHora { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int PedagogoId { get; set; }
    }
}