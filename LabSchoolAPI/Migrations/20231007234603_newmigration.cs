using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhiteLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UrlLogo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiteLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    tipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CodigoProfessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusAtivo = table.Column<bool>(type: "bit", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    WhiteLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_WhiteLabels_WhiteLabelId",
                        column: x => x.WhiteLabelId,
                        principalTable: "WhiteLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusAtivo = table.Column<bool>(type: "bit", nullable: false),
                    AlunoID = table.Column<int>(type: "int", nullable: false),
                    PedagogoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_PedagogoID",
                        column: x => x.PedagogoID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    StatusAtivo = table.Column<bool>(type: "bit", nullable: false),
                    PontuacaoMaxima = table.Column<double>(type: "float", nullable: false),
                    DataRealizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlunoID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercicios_Usuarios_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraAtividade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Atividade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_AlunoID",
                table: "Atendimentos",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PedagogoID",
                table: "Atendimentos",
                column: "PedagogoID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AlunoID",
                table: "Avaliacoes",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProfessorID",
                table: "Avaliacoes",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_AlunoID",
                table: "Exercicios",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_ProfessorID",
                table: "Exercicios",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuarioID",
                table: "Logs",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_WhiteLabelId",
                table: "Usuarios",
                column: "WhiteLabelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "WhiteLabels");
        }
    }
}
