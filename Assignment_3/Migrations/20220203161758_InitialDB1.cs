using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_3.Migrations
{
    public partial class InitialDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacters",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "MovieCharacters",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieCharacters",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "MovieCharacters",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 1, 2 });
        }
    }
}
