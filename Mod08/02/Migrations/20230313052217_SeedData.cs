using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterM.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Operas",
                columns: new[] { "OperaID", "Composer", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Wolfgang Amadeus Mozart", "Cosi Fan Tutte", 1790 },
                    { 2, "Giuseppe Verdi", "Rigoletto", 1851 },
                    { 3, "John Adams", "Nixon in China", 1987 },
                    { 4, "Alban Berg", "Wozzeck", 1922 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operas",
                keyColumn: "OperaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Operas",
                keyColumn: "OperaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operas",
                keyColumn: "OperaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Operas",
                keyColumn: "OperaID",
                keyValue: 4);
        }
    }
}
