using Microsoft.EntityFrameworkCore.Migrations;

namespace Servidor.Migrations
{
    public partial class AddIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilhets_Sessas_sessoesid",
                table: "Bilhets");

            migrationBuilder.DropForeignKey(
                name: "FK_Espetaculs_Teatrs_teatrosid",
                table: "Espetaculs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessas_Espetaculs_espetaculosid",
                table: "Sessas");

            migrationBuilder.DropIndex(
                name: "IX_Sessas_espetaculosid",
                table: "Sessas");

            migrationBuilder.DropIndex(
                name: "IX_Espetaculs_teatrosid",
                table: "Espetaculs");

            migrationBuilder.DropIndex(
                name: "IX_Bilhets_sessoesid",
                table: "Bilhets");

            migrationBuilder.DropColumn(
                name: "espetaculosid",
                table: "Sessas");

            migrationBuilder.DropColumn(
                name: "teatrosid",
                table: "Espetaculs");

            migrationBuilder.DropColumn(
                name: "sessoesid",
                table: "Bilhets");

            migrationBuilder.AddColumn<int>(
                name: "EspetaculoId",
                table: "Sessas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeatroId",
                table: "Espetaculs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sessaoId",
                table: "Bilhets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessas_EspetaculoId",
                table: "Sessas",
                column: "EspetaculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Espetaculs_TeatroId",
                table: "Espetaculs",
                column: "TeatroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhets_sessaoId",
                table: "Bilhets",
                column: "sessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhets_Sessas_sessaoId",
                table: "Bilhets",
                column: "sessaoId",
                principalTable: "Sessas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Espetaculs_Teatrs_TeatroId",
                table: "Espetaculs",
                column: "TeatroId",
                principalTable: "Teatrs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessas_Espetaculs_EspetaculoId",
                table: "Sessas",
                column: "EspetaculoId",
                principalTable: "Espetaculs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilhets_Sessas_sessaoId",
                table: "Bilhets");

            migrationBuilder.DropForeignKey(
                name: "FK_Espetaculs_Teatrs_TeatroId",
                table: "Espetaculs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessas_Espetaculs_EspetaculoId",
                table: "Sessas");

            migrationBuilder.DropIndex(
                name: "IX_Sessas_EspetaculoId",
                table: "Sessas");

            migrationBuilder.DropIndex(
                name: "IX_Espetaculs_TeatroId",
                table: "Espetaculs");

            migrationBuilder.DropIndex(
                name: "IX_Bilhets_sessaoId",
                table: "Bilhets");

            migrationBuilder.DropColumn(
                name: "EspetaculoId",
                table: "Sessas");

            migrationBuilder.DropColumn(
                name: "TeatroId",
                table: "Espetaculs");

            migrationBuilder.DropColumn(
                name: "sessaoId",
                table: "Bilhets");

            migrationBuilder.AddColumn<int>(
                name: "espetaculosid",
                table: "Sessas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teatrosid",
                table: "Espetaculs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sessoesid",
                table: "Bilhets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessas_espetaculosid",
                table: "Sessas",
                column: "espetaculosid");

            migrationBuilder.CreateIndex(
                name: "IX_Espetaculs_teatrosid",
                table: "Espetaculs",
                column: "teatrosid");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhets_sessoesid",
                table: "Bilhets",
                column: "sessoesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilhets_Sessas_sessoesid",
                table: "Bilhets",
                column: "sessoesid",
                principalTable: "Sessas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Espetaculs_Teatrs_teatrosid",
                table: "Espetaculs",
                column: "teatrosid",
                principalTable: "Teatrs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessas_Espetaculs_espetaculosid",
                table: "Sessas",
                column: "espetaculosid",
                principalTable: "Espetaculs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
