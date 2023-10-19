using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;


namespace LabSchoolAPI.DTOs
{
    public class LogCreateDTO
    {
        public int UsuarioId { get; set; }

        [Required]
        public TipoAtividade Atividade { get; set; }

        public string Descricao { get; set; }
    }
}