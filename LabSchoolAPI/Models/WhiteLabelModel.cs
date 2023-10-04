using System;
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

        [StringLength(255)] // opcional
        public string PalhetaDeCores { get; set; }

        [Required]
        [StringLength(200)] // URL da imagem do logotipo
        public string UrlLogotipo { get; set; }

        [StringLength(512)] // opcional
        public string OutrasInformacoes { get; set; }

        [Required]
        public int UsuarioAdministradorId { get; set; } //chave estrangeira 

        public virtual UsuarioModel UsuarioAdministrador { get; set; }  // Propriedade de navegação para a tabela Usuarios
    }
}