using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Models
{
    public class WhiteLabelModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeEmpresa { get; set; }

        [Required]
        [StringLength(200)]
        public string Slogan { get; set; }

        // opcional
        public List<string> Cores { get; set; }

        
        [StringLength(200)] // URL da imagem do logotipo, opcional
        public string UrlLogo { get; set; }

        [StringLength(512)] // opcional
        public string Complemento { get; set; }


         // Relacionamento abaixo //
        public virtual ICollection<UsuarioModel> Usuarios { get; set; }  // Propriedade de navegação para a tabela Usuarios
    }
}