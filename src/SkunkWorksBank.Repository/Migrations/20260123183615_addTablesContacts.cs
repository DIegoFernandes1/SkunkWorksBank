using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkunkWorksBank.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addTablesContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contact_type_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_primary = table.Column<bool>(type: "bit", nullable: false),
                    is_verified = table.Column<bool>(type: "bit", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_contact_type_id",
                        column: x => x.contact_type_id,
                        principalTable: "contact_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_contact_type_id",
                table: "contacts",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_user_id",
                table: "contacts",
                column: "user_id");

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
            migrationBuilder.DropTable(
                name: "contact_types");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
