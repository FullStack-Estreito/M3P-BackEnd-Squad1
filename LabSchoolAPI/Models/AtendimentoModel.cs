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
    public string Descricao { get; set; } // Descrição do Atendimento

    [Required]
    public DateTime DataHora { get; set; }// Data e Hora do Atendimento

    [Required]
    public bool StatusAtivo { get; set; } // Status (Ativo/Inativo)


    // Chaves e relacionamentos abaixo //
    public int AlunoID { get; set; }// ID do Aluno (Chave Estrangeira para o aluno relacionado)

    public virtual UsuarioModel Aluno { get; set; }
    public int PedagogoID { get; set; }// ID do Pedagogo (Chave Estrangeira para o pedagogo que realizou o atendimento)

    public virtual UsuarioModel Pedagogo { get; set; }

    }

}