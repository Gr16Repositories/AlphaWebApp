using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addigCategriesListToSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubscriptionId",
                table: "Categories",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Subscriptions_SubscriptionId",
                table: "Categories",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Subscriptions_SubscriptionId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubscriptionId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Categories");
        }
    }
}
