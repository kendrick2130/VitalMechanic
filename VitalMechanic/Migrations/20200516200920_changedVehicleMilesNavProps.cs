using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalMechanic.Migrations
{
    public partial class changedVehicleMilesNavProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleMiles_CarGarageID",
                table: "VehicleMiles",
                column: "CarGarageID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMiles_CarGarage_CarGarageID",
                table: "VehicleMiles",
                column: "CarGarageID",
                principalTable: "CarGarage",
                principalColumn: "CarGarageID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMiles_CarGarage_CarGarageID",
                table: "VehicleMiles");

            migrationBuilder.DropIndex(
                name: "IX_VehicleMiles_CarGarageID",
                table: "VehicleMiles");
        }
    }
}
