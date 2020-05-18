using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalMechanic.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarGarage",
                columns: table => new
                {
                    CarGarageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarYear = table.Column<int>(nullable: false),
                    CarMake = table.Column<string>(nullable: true),
                    CarModelsId = table.Column<int>(nullable: false),
                    CarModels = table.Column<string>(nullable: true),
                    DriveTran = table.Column<string>(nullable: true),
                    EngineSize = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarGarage", x => x.CarGarageID);
                });

            migrationBuilder.CreateTable(
                name: "CarMakes",
                columns: table => new
                {
                    CarMakesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakes", x => x.CarMakesId);
                });

            migrationBuilder.CreateTable(
                name: "CarYear",
                columns: table => new
                {
                    CarYearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfMake = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarYear", x => x.CarYearId);
                });

            migrationBuilder.CreateTable(
                name: "DriveTrans",
                columns: table => new
                {
                    DriveTranID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveTranType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTrans", x => x.DriveTranID);
                });

            migrationBuilder.CreateTable(
                name: "EngineSizes",
                columns: table => new
                {
                    EngineSizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineSizes", x => x.EngineSizeId);
                });

            migrationBuilder.CreateTable(
                name: "MileStones",
                columns: table => new
                {
                    MileStoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleMileStones = table.Column<int>(nullable: false),
                    MileStoneDescription = table.Column<string>(nullable: true),
                    CarGarageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MileStones", x => x.MileStoneId);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMiles",
                columns: table => new
                {
                    MileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarGarageID = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMiles", x => x.MileId);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    CarModelsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    CarMakesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.CarModelsId);
                    table.ForeignKey(
                        name: "FK_CarModels_CarMakes_CarMakesId",
                        column: x => x.CarMakesId,
                        principalTable: "CarMakes",
                        principalColumn: "CarMakesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarMakesId",
                table: "CarModels",
                column: "CarMakesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarGarage");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarYear");

            migrationBuilder.DropTable(
                name: "DriveTrans");

            migrationBuilder.DropTable(
                name: "EngineSizes");

            migrationBuilder.DropTable(
                name: "MileStones");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "VehicleMiles");

            migrationBuilder.DropTable(
                name: "CarMakes");
        }
    }
}
