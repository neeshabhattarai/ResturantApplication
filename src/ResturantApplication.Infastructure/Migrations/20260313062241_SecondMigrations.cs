using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApplication.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Dish",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Dish",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Rooms_RoomId",
                table: "Dish",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
