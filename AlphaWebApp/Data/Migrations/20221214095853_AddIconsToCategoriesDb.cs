using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIconsToCategoriesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "Categories");
        }
    }
}
