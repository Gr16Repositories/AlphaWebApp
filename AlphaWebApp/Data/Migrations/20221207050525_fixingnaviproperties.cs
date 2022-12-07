using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixingnaviproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_UserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionTypes_Subscriptions_SupscriptionId",
                table: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionTypes_SupscriptionId",
                table: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SupscriptionId",
                table: "SubscriptionTypes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionTypeId",
                table: "Subscriptions",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_SubscriptionTypes_SubscriptionTypeId",
                table: "Subscriptions",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_SubscriptionTypes_SubscriptionTypeId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_SubscriptionTypeId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "SupscriptionId",
                table: "SubscriptionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionTypes_SupscriptionId",
                table: "SubscriptionTypes",
                column: "SupscriptionId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionTypes_Subscriptions_SupscriptionId",
                table: "SubscriptionTypes",
                column: "SupscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
