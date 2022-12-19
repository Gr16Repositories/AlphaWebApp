using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class subtypeuserIdtostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId1",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId1",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId1",
                table: "Subscriptions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId1",
                table: "Subscriptions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
