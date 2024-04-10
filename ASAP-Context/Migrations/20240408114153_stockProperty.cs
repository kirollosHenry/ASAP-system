using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASAP_Context.Migrations
{
    /// <inheritdoc />
    public partial class stockProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "stocks");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "stocks",
                newName: "ticker");

            migrationBuilder.AddColumn<int>(
                name: "split_from",
                table: "stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "split_to",
                table: "stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "split_from",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "split_to",
                table: "stocks");

            migrationBuilder.RenameColumn(
                name: "ticker",
                table: "stocks",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Exchange",
                table: "stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
