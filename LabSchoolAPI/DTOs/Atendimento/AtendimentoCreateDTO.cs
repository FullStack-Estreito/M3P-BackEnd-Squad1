using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AtendimentoCreateDTO
    {
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int PedagogoId { get; set; }
    }
}