using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addusersTow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
