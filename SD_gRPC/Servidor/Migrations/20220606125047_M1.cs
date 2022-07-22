using Microsoft.EntityFrameworkCore.Migrations;

namespace Servidor.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teatro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teatro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Espetaculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teatrosid = table.Column<int>(type: "int", nullable: true),
                    dataInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espetaculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Espetaculo_Teatro_teatrosid",
                        column: x => x.teatrosid,
                        principalTable: "Teatro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    espetaculosid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horaInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horaFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lugarTotal = table.Column<int>(type: "int", nullable: false),
                    lugarDisponivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sessao_Espetaculo_espetaculosid",
                        column: x => x.espetaculosid,
                        principalTable: "Espetaculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilhete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sessoesid = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhete", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bilhete_Sessao_sessoesid",
                        column: x => x.sessoesid,
                        principalTable: "Sessao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bilheteId = table.Column<int>(type: "int", nullable: false),
                    contaVirtual = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Bilhete_bilheteId",
                        column: x => x.bilheteId,
                        principalTable: "Bilhete",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_sessoesid",
                table: "Bilhete",
                column: "sessoesid");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_bilheteId",
                table: "Cliente",
                column: "bilheteId");

            migrationBuilder.CreateIndex(
                name: "IX_Espetaculo_teatrosid",
                table: "Espetaculo",
                column: "teatrosid");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_espetaculosid",
                table: "Sessao",
                column: "espetaculosid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Bilhete");

            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Espetaculo");

            migrationBuilder.DropTable(
                name: "Teatro");
        }
    }
}
