using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineesManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseAssigned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchesDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subbatchesdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBatchId = table.Column<int>(type: "int", nullable: false),
                    MainBatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubBatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseAssigned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subbatchesdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traineesdetails",
                columns: table => new
                {
                    IdentityKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreePercentage = table.Column<int>(type: "int", nullable: false),
                    DegreePassedOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineesdetails", x => x.IdentityKey);
                });

            migrationBuilder.CreateTable(
                name: "Traineesinsubbatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainBatchId = table.Column<int>(type: "int", nullable: false),
                    MainBatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubBatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseAssigned = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineesinsubbatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traineeswithbatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseAssigned = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeswithbatches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchesDetails");

            migrationBuilder.DropTable(
                name: "Subbatchesdetails");

            migrationBuilder.DropTable(
                name: "Traineesdetails");

            migrationBuilder.DropTable(
                name: "Traineesinsubbatches");

            migrationBuilder.DropTable(
                name: "Traineeswithbatches");
        }
    }
}
