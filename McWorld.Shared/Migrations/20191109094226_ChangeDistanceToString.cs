using Microsoft.EntityFrameworkCore.Migrations;

namespace McWorld.Shared.Migrations
{
    public partial class ChangeDistanceToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Distance",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
