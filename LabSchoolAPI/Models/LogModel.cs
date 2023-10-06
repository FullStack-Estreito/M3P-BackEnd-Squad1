using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.Models
{
        public class LogModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime DataHoraAtividade { get; set; }

        [Required]
        public TipoAtividade Atividade { get; set; }

        [Required]
        [StringLength(250)] 
        public string Descricao { get; set; }


        // Chaves e relacionamentos abaixo //
        public int UsuarioID { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }

}