using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalMechanic.Migrations
{
    public partial class addedVehicleMilestones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleMileStones",
                columns: table => new
                {
                    MileStoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarGarageId = table.Column<int>(nullable: false),
                    MileageId = table.Column<int>(nullable: false),
                    MileStones = table.Column<int>(nullable: false),
                    Descriptions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMileStones", x => x.MileStoneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMileStones");
        }
    }
}
