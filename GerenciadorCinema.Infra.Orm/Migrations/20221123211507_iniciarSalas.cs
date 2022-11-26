using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorCinema.Infra.Orm.Migrations
{
    public partial class iniciarSalas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("c933df6c-9d48-405d-dc45-08dacd97cbd1"), "Sala 1", 15, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("2dc8d170-4c3e-48ff-dc46-08dacd97cbd1"), "Sala 2", 20, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("4d9b51f4-0b85-4e86-dc47-08dacd97cbd1"), "Sala 3", 25, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("2dc8d170-4c3e-48ff-dc46-08dacd97cbd1"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("4d9b51f4-0b85-4e86-dc47-08dacd97cbd1"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("c933df6c-9d48-405d-dc45-08dacd97cbd1"));
        }
    }
}
