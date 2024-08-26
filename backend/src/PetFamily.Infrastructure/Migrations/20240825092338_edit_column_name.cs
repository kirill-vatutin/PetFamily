using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit_column_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name_last_name",
                table: "volunteers");

            migrationBuilder.RenameColumn(
                name: "full_name_second_name",
                table: "volunteers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "full_name_firstname",
                table: "volunteers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "classification_species_id",
                table: "pets",
                newName: "species_id");

            migrationBuilder.RenameColumn(
                name: "classification_breed_id",
                table: "pets",
                newName: "breed_id");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "pets",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "address_house_number",
                table: "pets",
                newName: "house_number");

            migrationBuilder.RenameColumn(
                name: "address_house_letter",
                table: "pets",
                newName: "house_letter");

            migrationBuilder.RenameColumn(
                name: "address_country",
                table: "pets",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "address_city",
                table: "pets",
                newName: "city");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "volunteers",
                newName: "full_name_second_name");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "volunteers",
                newName: "full_name_firstname");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "pets",
                newName: "address_street");

            migrationBuilder.RenameColumn(
                name: "species_id",
                table: "pets",
                newName: "classification_species_id");

            migrationBuilder.RenameColumn(
                name: "house_number",
                table: "pets",
                newName: "address_house_number");

            migrationBuilder.RenameColumn(
                name: "house_letter",
                table: "pets",
                newName: "address_house_letter");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "pets",
                newName: "address_country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "pets",
                newName: "address_city");

            migrationBuilder.RenameColumn(
                name: "breed_id",
                table: "pets",
                newName: "classification_breed_id");

            migrationBuilder.AddColumn<string>(
                name: "full_name_last_name",
                table: "volunteers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
