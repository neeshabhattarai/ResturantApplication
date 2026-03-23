using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantApplication.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rooms",
                type: "text",
                nullable: true,
                defaultValue: "");
            migrationBuilder.Sql(@"
            UPDATE ""Rooms""
             SET ""UserId"" = (
             SELECT ""Id"" FROM ""AspNetUsers"" LIMIT 1
        );
    ");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Rooms",
                type: "text",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_UserId",
                table: "Rooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_UserId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rooms");
        }
    }
}
