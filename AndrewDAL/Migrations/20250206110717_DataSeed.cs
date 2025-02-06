using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndrewDAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CmsSectionTypeId",
                table: "CmsSections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameLabel = table.Column<string>(type: "TEXT", nullable: false),
                    NamePlaceholder = table.Column<string>(type: "TEXT", nullable: false),
                    EmailLabel = table.Column<string>(type: "TEXT", nullable: false),
                    EmailPlaceholder = table.Column<string>(type: "TEXT", nullable: false),
                    TitleLabel = table.Column<string>(type: "TEXT", nullable: false),
                    TitlePlaceholder = table.Column<string>(type: "TEXT", nullable: false),
                    MessageLabel = table.Column<string>(type: "TEXT", nullable: false),
                    MessagePlaceholder = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForm", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "Email", "Login", "Password" },
                values: new object[] { 1, "admin@gmail.com", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "ContactForm",
                columns: new[] { "Id", "EmailLabel", "EmailPlaceholder", "MessageLabel", "MessagePlaceholder", "NameLabel", "NamePlaceholder", "TitleLabel", "TitlePlaceholder" },
                values: new object[] { 1, "Email", "Enter your email", "Message", "Enter your message", "Name", "Enter your name", "Title", "Enter the title" });

            migrationBuilder.CreateIndex(
                name: "IX_CmsSections_CmsSectionTypeId",
                table: "CmsSections",
                column: "CmsSectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_Email",
                table: "AdminUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_Login",
                table: "AdminUsers",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_Password",
                table: "AdminUsers",
                column: "Password",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CmsSections_CmsSectionTypes_CmsSectionTypeId",
                table: "CmsSections",
                column: "CmsSectionTypeId",
                principalTable: "CmsSectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CmsSections_CmsSectionTypes_CmsSectionTypeId",
                table: "CmsSections");

            migrationBuilder.DropTable(
                name: "ContactForm");

            migrationBuilder.DropIndex(
                name: "IX_CmsSections_CmsSectionTypeId",
                table: "CmsSections");

            migrationBuilder.DropIndex(
                name: "IX_AdminUsers_Email",
                table: "AdminUsers");

            migrationBuilder.DropIndex(
                name: "IX_AdminUsers_Login",
                table: "AdminUsers");

            migrationBuilder.DropIndex(
                name: "IX_AdminUsers_Password",
                table: "AdminUsers");

            migrationBuilder.DeleteData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CmsSectionTypeId",
                table: "CmsSections");
        }
    }
}
