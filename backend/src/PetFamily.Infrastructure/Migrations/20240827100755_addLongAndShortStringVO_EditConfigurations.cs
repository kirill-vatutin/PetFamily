using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLongAndShortStringVO_EditConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "secondname",
                table: "volunteers",
                newName: "second_name");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "volunteers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "volunteers",
                newName: "first_name");

            migrationBuilder.AlterColumn<string>(
                name: "health_info",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "volunteers",
                newName: "secondname");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "volunteers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "volunteers",
                newName: "firstname");

            migrationBuilder.AlterColumn<string>(
                name: "health_info",
                table: "pets",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
