using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Universitate.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    FacultateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studenti_Facultati_FacultateId",
                        column: x => x.FacultateId,
                        principalTable: "Facultati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cursuri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    ProfesorId = table.Column<int>(nullable: true),
                    FacultateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursuri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursuri_Facultati_FacultateId",
                        column: x => x.FacultateId,
                        principalTable: "Facultati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursuri_Profesori_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursStudentLink",
                columns: table => new
                {
                    cursId = table.Column<int>(nullable: false),
                    studentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursStudentLink", x => new { x.cursId, x.studentId });
                    table.ForeignKey(
                        name: "FK_CursStudentLink_Cursuri_cursId",
                        column: x => x.cursId,
                        principalTable: "Cursuri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursStudentLink_Studenti_studentId",
                        column: x => x.studentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursStudentLink_studentId",
                table: "CursStudentLink",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursuri_FacultateId",
                table: "Cursuri",
                column: "FacultateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursuri_ProfesorId",
                table: "Cursuri",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_FacultateId",
                table: "Studenti",
                column: "FacultateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursStudentLink");

            migrationBuilder.DropTable(
                name: "Cursuri");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Profesori");

            migrationBuilder.DropTable(
                name: "Facultati");
        }
    }
}
