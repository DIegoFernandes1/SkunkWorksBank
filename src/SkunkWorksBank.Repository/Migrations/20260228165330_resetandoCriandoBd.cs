using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkunkWorksBank.Repository.Migrations
{
    /// <inheritdoc />
    public partial class resetandoCriandoBd : Migration
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
                name: "user_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_status_id = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    is_pep = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_user_status_user_status_id",
                        column: x => x.user_status_id,
                        principalTable: "user_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    is_verified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_contact_types_contact_type_id",
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

            migrationBuilder.InsertData(
                table: "user_status",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Active" },
                    { 3, "Blocked" },
                    { 4, "Disabled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_contact_type_id",
                table: "contacts",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_user_id",
                table: "contacts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_cpf",
                table: "users",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_user_status_id",
                table: "users",
                column: "user_status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "contact_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_status");
        }
    }
}
