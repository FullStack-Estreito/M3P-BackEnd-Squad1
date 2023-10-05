using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enuns;

namespace LabSchoolAPI.Models
{
        public class LogModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("UsuarioID")] 
        public int UsuarioID { get; set; }
        public DateTime DataHoraAtividade { get; set; }

        [Required]
        public TipoAtividade Atividade { get; set; }

        [Required]
        [StringLength(250)] 
        public string DescricaoDetalhada { get; set; }

        public virtual ICollection Usuarios { get; set; }
    }

}