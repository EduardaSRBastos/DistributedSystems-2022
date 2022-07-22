using Microsoft.EntityFrameworkCore.Migrations;

namespace Servidor.Migrations
{
    public partial class Recibos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReciboId",
                table: "Bilhets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroBilhetes = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    gasto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibos_Clients_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clients",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhets_ReciboId",
                table: "Bilhets",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClienteId",
                table: "Recibos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhets_Recibos_ReciboId",
                table: "Bilhets",
                column: "ReciboId",
                principalTable: "Recibos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilhets_Recibos_ReciboId",
                table: "Bilhets");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Bilhets_ReciboId",
                table: "Bilhets");

            migrationBuilder.DropColumn(
                name: "ReciboId",
                table: "Bilhets");
        }
    }
}
