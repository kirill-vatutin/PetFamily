using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValueObjectList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count_help",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "count_house_found",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "count_house_search",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "requisite_description",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "requisite_name",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "requisite_description",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "requisite_name",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "fio_second_name",
                table: "volunteers",
                newName: "full_name_second_name");

            migrationBuilder.RenameColumn(
                name: "fio_last_name",
                table: "volunteers",
                newName: "full_name_last_name");

            migrationBuilder.RenameColumn(
                name: "fio_firstname",
                table: "volunteers",
                newName: "full_name_firstname");

            migrationBuilder.AddColumn<string>(
                name: "requisites",
                table: "volunteers",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "requisites",
                table: "pets",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requisites",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "requisites",
                table: "pets");

            migrationBuilder.RenameColumn(
                name: "full_name_second_name",
                table: "volunteers",
                newName: "fio_second_name");

            migrationBuilder.RenameColumn(
                name: "full_name_last_name",
                table: "volunteers",
                newName: "fio_last_name");

            migrationBuilder.RenameColumn(
                name: "full_name_firstname",
                table: "volunteers",
                newName: "fio_firstname");

            migrationBuilder.AddColumn<int>(
                name: "count_help",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "count_house_found",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "count_house_search",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "requisite_description",
                table: "volunteers",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "requisite_name",
                table: "volunteers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "requisite_description",
                table: "pets",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "requisite_name",
                table: "pets",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
