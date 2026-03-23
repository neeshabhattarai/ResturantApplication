using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApplication.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dish_DishId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DishId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Dish",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dish_RoomId",
                table: "Dish",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_RoomId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Dish");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DishId",
                table: "Rooms",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dish_DishId",
                table: "Rooms",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
