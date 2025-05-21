using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CoursesRobotsOuerfelliMohamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pistes",
                columns: table => new
                {
                    PisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LongueurMetres = table.Column<double>(type: "float", nullable: false),
                    NbrObstacles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pistes", x => x.PisteId);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    RobotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitesseMax = table.Column<double>(type: "float", nullable: false),
                    DateFabrication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoidsKg = table.Column<double>(type: "float", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.RobotId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CoursetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCourse = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PisteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CoursetId);
                    table.ForeignKey(
                        name: "FK_Courses_Pistes_PisteFk",
                        column: x => x.PisteFk,
                        principalTable: "Pistes",
                        principalColumn: "PisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    RobotFk = table.Column<int>(type: "int", nullable: false),
                    CourseFk = table.Column<int>(type: "int", nullable: false),
                    PositionFinale = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => new { x.RobotFk, x.CourseFk });
                    table.ForeignKey(
                        name: "FK_Participations_Courses_CourseFk",
                        column: x => x.CourseFk,
                        principalTable: "Courses",
                        principalColumn: "CoursetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Robots_RobotFk",
                        column: x => x.RobotFk,
                        principalTable: "Robots",
                        principalColumn: "RobotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PisteFk",
                table: "Courses",
                column: "PisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_CourseFk",
                table: "Participations",
                column: "CourseFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "Pistes");
        }
    }
}
