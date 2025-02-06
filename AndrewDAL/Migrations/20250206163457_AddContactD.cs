using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndrewDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddContactD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactForm",
                table: "ContactForm");

            migrationBuilder.RenameTable(
                name: "ContactForm",
                newName: "ContactForms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactForms",
                table: "ContactForms",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactForms",
                table: "ContactForms");

            migrationBuilder.RenameTable(
                name: "ContactForms",
                newName: "ContactForm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactForm",
                table: "ContactForm",
                column: "Id");
        }
    }
}
