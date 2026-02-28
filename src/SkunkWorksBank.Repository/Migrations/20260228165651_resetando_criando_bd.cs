using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkunkWorksBank.Repository.Migrations
{
    /// <inheritdoc />
    public partial class resetando_criando_bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contact_types",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Telefone" },
                    { 2, "Email" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contact_types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contact_types",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
