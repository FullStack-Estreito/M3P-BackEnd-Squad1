using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    Referencia = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhiteLabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cores = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    NomeEmpresa = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Slogan = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    UrlLogo = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhiteLabel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CodigoProfessor = table.Column<int>(type: "int", nullable: false),
                    StatusAtivo = table.Column<bool>(type: "bit", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    WhiteLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_WhiteLabel_WhiteLabelId",
                        column: x => x.WhiteLabelId,
                        principalTable: "WhiteLabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    DataHora = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    StatusAtivo = table.Column<bool>(type: "bit", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    PedagogoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimento_Usuario_PedagogoId",
                        column: x => x.PedagogoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    PontuacaoMaxima = table.Column<double>(type: "float", nullable: false),
                    DataRealizacao = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    CodigoProfessor = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CodigoProfessor = table.Column<int>(type: "int", nullable: false),
                    DataConclusao = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicio_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atividade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_AlunoId",
                table: "Atendimento",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PedagogoId",
                table: "Atendimento",
                column: "PedagogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacao",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_AlunoId",
                table: "Exercicio",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UsuarioId",
                table: "Log",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_WhiteLabelId",
                table: "Usuario",
                column: "WhiteLabelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "WhiteLabel");
        }
    }
}
