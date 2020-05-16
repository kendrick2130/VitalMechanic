using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalMechanic.Migrations
{
    public partial class DeletedCarModelsfromCarGarage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModels",
                table: "CarGarage");

            migrationBuilder.CreateIndex(
                name: "IX_CarGarage_CarModelsId",
                table: "CarGarage",
                column: "CarModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarGarage_CarModels_CarModelsId",
                table: "CarGarage",
                column: "CarModelsId",
                principalTable: "CarModels",
                principalColumn: "CarModelsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarGarage_CarModels_CarModelsId",
                table: "CarGarage");

            migrationBuilder.DropIndex(
                name: "IX_CarGarage_CarModelsId",
                table: "CarGarage");

            migrationBuilder.AddColumn<string>(
                name: "CarModels",
                table: "CarGarage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
