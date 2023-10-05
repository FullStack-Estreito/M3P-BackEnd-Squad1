using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Models
{
    public class AtendimentoModel
    {
    [Key]
    public int ID { get; set; }// ID (Chave Primária)

    [Required]
    [StringLength(500)] 
    public string DescricaoDoAtendimento { get; set; } // Descrição do Atendimento

    [Required]
    public DateTime DataHoraAtendimento { get; set; }// Data e Hora do Atendimento

    [Required]
    [ForeignKey("Aluno")]
    public int AlunoID { get; set; }// ID do Aluno (Chave Estrangeira para o aluno relacionado)

    [Required]
    [ForeignKey("Pedagogo")]
    public int PedagogoID { get; set; }// ID do Pedagogo (Chave Estrangeira para o pedagogo que realizou o atendimento)

   [Required]
    public bool Status { get; set; } // Status (Ativo/Inativo)
    }

}