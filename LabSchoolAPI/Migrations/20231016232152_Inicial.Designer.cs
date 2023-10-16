﻿// <auto-generated />
using LabSchoolAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabSchoolAPI.Migrations
{
    [DbContext(typeof(LabSchoolContext))]
    [Migration("20231016232152_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabSchoolAPI.Models.AtendimentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<string>("DataHora")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PedagogoId")
                        .HasColumnType("int");

                    b.Property<bool>("StatusAtivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("PedagogoId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.AvaliacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoProfessor")
                        .HasColumnType("int");

                    b.Property<string>("DataRealizacao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.Property<double>("PontuacaoMaxima")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.ExercicioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoProfessor")
                        .HasColumnType("int");

                    b.Property<string>("DataConclusao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Exercicio");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.LogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Atividade")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoProfessor")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("StatusAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<int>("WhiteLabelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("WhiteLabelId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.WhiteLabelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Cores")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UrlLogo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("WhiteLabel");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.AtendimentoModel", b =>
                {
                    b.HasOne("LabSchoolAPI.Models.UsuarioModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabSchoolAPI.Models.UsuarioModel", "Pedagogo")
                        .WithMany()
                        .HasForeignKey("PedagogoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Pedagogo");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.AvaliacaoModel", b =>
                {
                    b.HasOne("LabSchoolAPI.Models.UsuarioModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.ExercicioModel", b =>
                {
                    b.HasOne("LabSchoolAPI.Models.UsuarioModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.LogModel", b =>
                {
                    b.HasOne("LabSchoolAPI.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.UsuarioModel", b =>
                {
                    b.HasOne("LabSchoolAPI.Models.EnderecoModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabSchoolAPI.Models.WhiteLabelModel", "WhiteLabel")
                        .WithMany("Usuarios")
                        .HasForeignKey("WhiteLabelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("WhiteLabel");
                });

            modelBuilder.Entity("LabSchoolAPI.Models.WhiteLabelModel", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}