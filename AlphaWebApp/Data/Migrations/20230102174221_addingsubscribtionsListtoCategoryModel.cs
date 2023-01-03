using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingsubscribtionsListtoCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CategorySubscription",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubscription", x => new { x.CategoriesId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_CategorySubscription_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySubscription_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubscription_SubscriptionsId",
                table: "CategorySubscription",
                column: "SubscriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySubscription");

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
    }
}
