using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrpcServiceDataBase.Migrations
{
    /// <inheritdoc />
    public partial class new_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClientBankAccounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    ClientInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBankAccounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClientId",
                        column: x => x.ClientInfoId,
                        principalTable: "ClientInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ClientInfo",
                columns: new[] { "id", "firstName", "lastName", "name", "password", "phone" },
                values: new object[] { 1, "Тестов", "Тестович", "Тест", "12345", "89969520206" });

            migrationBuilder.InsertData(
                table: "ClientBankAccounts",
                columns: new[] { "id", "account", "ClientInfoId", "number" },
                values: new object[,]
                {
                    { 1, "Срочный", 1, "42305840513000000112" },
                    { 2, "До востреббования", 1, "42301810413002008000" },
                    { 3, "Карточный", 1, "40817810310009035474" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientBankAccounts_ClientInfoId",
                table: "ClientBankAccounts",
                column: "ClientInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientBankAccounts");

            migrationBuilder.DropTable(
                name: "ClientInfo");
        }
    }
}
