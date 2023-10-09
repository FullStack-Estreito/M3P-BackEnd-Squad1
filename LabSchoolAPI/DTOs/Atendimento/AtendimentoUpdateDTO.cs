using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AtendimentoUpdateDTO
    {
        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public bool StatusAtivo { get; set; }

        public int AlunoId { get; set; }

        public int PedagogoId { get; set; }

        [Required]
        public int AtendimentoId { get; set; }
    }
}