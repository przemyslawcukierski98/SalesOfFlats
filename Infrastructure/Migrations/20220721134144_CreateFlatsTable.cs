using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateFlatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Klucz główny tabeli z informacjami o mieszkaniach")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Tytuł ogłoszenia"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Opis ogłoszenia"),
                    Area = table.Column<double>(type: "float", nullable: false, comment: "Powierzchnia mieszkania (w metrach kwadratowych)"),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false, comment: "Liczba pokoi"),
                    Price = table.Column<int>(type: "int", nullable: false, comment: "Cena (za metr kwadratowy)"),
                    FormOfOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Forma własności"),
                    Floor = table.Column<int>(type: "int", nullable: false, comment: "Piętro"),
                    StateOfCompletion = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Status wykończenia mieszkania"),
                    KindOfBalcony = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Typ balkonu (jeśli brak - wartość pusta)"),
                    ParkingSpace = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Parking (jeśli brak - wartość pusta)"),
                    Heating = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Rodzaj ogrzewania"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats");
        }
    }
}
