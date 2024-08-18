using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fio_firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fio_second_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fio_last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    years_experience = table.Column<int>(type: "integer", nullable: false),
                    count_help = table.Column<int>(type: "integer", nullable: false),
                    count_house_search = table.Column<int>(type: "integer", nullable: false),
                    count_house_found = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    requisite_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    requisite_description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    social_networks = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    species = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    color = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    health_info = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    address_country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address_city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address_street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address_house_number = table.Column<int>(type: "integer", nullable: false),
                    address_house_letter = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    is_castrated = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    birth_day = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    help_status = table.Column<string>(type: "text", nullable: false),
                    requisite_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    requisite_description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    create_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    pet_photos = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.id);
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "volunteers");
        }
    }
}
