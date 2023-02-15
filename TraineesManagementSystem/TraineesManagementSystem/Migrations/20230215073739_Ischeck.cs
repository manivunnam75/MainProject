using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineesManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Ischeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ischeck",
                table: "Traineesdetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ischeck",
                table: "Traineesdetails");
        }
    }
}
