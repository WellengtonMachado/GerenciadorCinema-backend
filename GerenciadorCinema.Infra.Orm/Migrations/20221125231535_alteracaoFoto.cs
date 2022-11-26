using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorCinema.Infra.Orm.Migrations
{
    public partial class alteracaoFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Filme",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("f8a531d9-86ff-4547-b057-08dacf3af46d"), "Sala 1", 15, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("bc5bfce2-eb5b-421d-b058-08dacf3af46d"), "Sala 2", 20, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("07f8e708-8125-477b-b059-08dacf3af46d"), "Sala 3", 25, new Guid("bfc7e720-3c99-49a4-e23f-08dacf2fff5a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("07f8e708-8125-477b-b059-08dacf3af46d"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("bc5bfce2-eb5b-421d-b058-08dacf3af46d"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("f8a531d9-86ff-4547-b057-08dacf3af46d"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Filme",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("c933df6c-9d48-405d-dc45-08dacd97cbd1"), "Sala 1", 15, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("2dc8d170-4c3e-48ff-dc46-08dacd97cbd1"), "Sala 2", 20, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Nome", "QuantidadeAssentos", "UsuarioId" },
                values: new object[] { new Guid("4d9b51f4-0b85-4e86-dc47-08dacd97cbd1"), "Sala 3", 25, new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
