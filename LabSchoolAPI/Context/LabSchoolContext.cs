using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions<LabSchoolContext> options) : base(options) { }

        // DbSets para cada modelo
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AtendimentoModel> Atendimentos { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<WhiteLabelModel> WhiteLabels { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações para o modelo Usuario
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Endereco)
                .WithMany()
                .HasForeignKey(u => u.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.WhiteLabel)
                .WithMany(wl => wl.Usuarios)
                .HasForeignKey(u => u.WhiteLabelId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Atendimento
            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(a => a.Aluno)
                .WithMany()
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            modelBuilder.Entity<AtendimentoModel>()
                .HasOne(a => a.Pedagogo)
                .WithMany()
                .HasForeignKey(a => a.PedagogoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Avaliacao
            modelBuilder.Entity<AvaliacaoModel>()
                .HasOne(av => av.Aluno)
                .WithMany()
                .HasForeignKey(av => av.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Exercicio
            modelBuilder.Entity<ExercicioModel>()
                .HasOne(ex => ex.Aluno)
                .WithMany()
                .HasForeignKey(ex => ex.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Configurações para o modelo Log
            modelBuilder.Entity<LogModel>()
                .HasOne(l => l.Usuario)
                .WithMany()
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);  // Aplicando a restrição

            // Carga inicial (Seeders)
            modelBuilder.Entity<WhiteLabelModel>().HasData(
                new WhiteLabelModel { Id = 1, NomeEmpresa = "Floripa Sul", Slogan = "Inovação em primeiro lugar!", Cores = "#123456, #654321", UrlLogo = "https://github.com/FeReDragon/Avalicao-modulo2-FullStack-Senai/blob/main/LABSchool_Manager/src/assets/img/labScool-logo.png?raw=true", Complemento = "Tech" },
                new WhiteLabelModel { Id = 2, NomeEmpresa = "e us guri", Slogan = "Vendas em primeiro lugar!", Cores = "#123456, #654321", UrlLogo = "https://github.com/FeReDragon/Avalicao-modulo2-FullStack-Senai/blob/main/LABSchool_Manager/src/assets/img/labScool-logo.png?raw=true", Complemento = "Informações adicionais" },
                new WhiteLabelModel { Id = 3, NomeEmpresa = "Lab365", Slogan = "LAB365 - Espaço do SENAI para desenvolver habilidades do futuro.", Cores = "#808080, #C8A2C8, #FFA500", UrlLogo = "https://play-lh.googleusercontent.com/XVWVhVq5s0_ME8DAGCEVEAM-vRiU0RvWH6DhYIfJHdYi2lwx-8L0YIK-YT0uEH-PFg=w240-h480", Complemento = "Senai LAB 365" }
            );

            modelBuilder.Entity<UsuarioCreateDTO>().HasData(
                new UsuarioCreateDTO { Id = 1, Nome = "Fernando", Cpf = "05193149995", Telefone = "(48) 98805-0165", Email = "alexandre.nolla@gmail.com", Genero = 0, Senha = "root", TipoUsuario = 0, Matricula = 0, CodigoProfessor = 0, StatusAtivo = true },
                new UsuarioCreateDTO  { Id = 2, Nome = "Pedagogo", Cpf = "05193149995", Telefone = "(48) 98805-0165", Email = "alexandre.nolla@gmail.com", Genero = 0, Senha = "root", TipoUsuario = 1, Matricula = 0, CodigoProfessor = 0, StatusAtivo = true },
                new UsuarioCreateDTO  { Id = 3, Nome = "Professor", Cpf = "05193149995", Telefone = "(48) 98805-0165", Email = "alexandre.nolla@gmail.com", Genero = 0, Senha = "root", TipoUsuario = 2, Matricula = 0, CodigoProfessor = 1, StatusAtivo = true },
                new UsuarioCreateDTO  { Id = 4, Nome = "Aluno", Cpf = "05193149995", Telefone = "(48) 98805-0165", Email = "alexandre.nolla@gmail.com", Genero = 0, Senha = "root", TipoUsuario = 3, Matricula = 123, CodigoProfessor = 0, StatusAtivo = true }
            );
        }


    }
}
