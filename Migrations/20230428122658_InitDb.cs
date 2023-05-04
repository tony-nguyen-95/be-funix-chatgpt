using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    CertificateId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.CertificateId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempCertificate",
                columns: table => new
                {
                    TempCertificateId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCertificate", x => x.TempCertificateId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempCourse",
                columns: table => new
                {
                    TempCourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TotalWeekLearning = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCourse", x => x.TempCourseId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    FunixId = table.Column<string>(type: "varchar(255)", nullable: false),
                    FunixEmail = table.Column<string>(type: "varchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LoginDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlanStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlanEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CertificateId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempCertificateCourse",
                columns: table => new
                {
                    TempCertificateCourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TempCourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TempCertificateId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCertificateCourse", x => x.TempCertificateCourseId);
                    table.ForeignKey(
                        name: "FK_TempCertificateCourse_TempCertificate_TempCertificateId",
                        column: x => x.TempCertificateId,
                        principalTable: "TempCertificate",
                        principalColumn: "TempCertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCertificateCourse_TempCourse_TempCourseId",
                        column: x => x.TempCourseId,
                        principalTable: "TempCourse",
                        principalColumn: "TempCourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempCourseWeeklySchedule",
                columns: table => new
                {
                    TempCourseScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    TotalQuiz = table.Column<int>(type: "int", nullable: false),
                    TotalLab = table.Column<int>(type: "int", nullable: false),
                    TotalPT = table.Column<int>(type: "int", nullable: false),
                    TotalAssignment = table.Column<int>(type: "int", nullable: false),
                    IsFinalExam = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TempCourseId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCourseWeeklySchedule", x => x.TempCourseScheduleId);
                    table.ForeignKey(
                        name: "FK_TempCourseWeeklySchedule_TempCourse_TempCourseId",
                        column: x => x.TempCourseId,
                        principalTable: "TempCourse",
                        principalColumn: "TempCourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempSubject",
                columns: table => new
                {
                    TempSubjectId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TempCourseId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempSubject", x => x.TempSubjectId);
                    table.ForeignKey(
                        name: "FK_TempSubject_TempCourse_TempCourseId",
                        column: x => x.TempCourseId,
                        principalTable: "TempCourse",
                        principalColumn: "TempCourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hannah",
                columns: table => new
                {
                    HannahId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hannah", x => x.HannahId);
                    table.ForeignKey(
                        name: "FK_Hannah_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TempLession",
                columns: table => new
                {
                    TempLessionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TempSubjectId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempLession", x => x.TempLessionId);
                    table.ForeignKey(
                        name: "FK_TempLession_TempSubject_TempSubjectId",
                        column: x => x.TempSubjectId,
                        principalTable: "TempSubject",
                        principalColumn: "TempSubjectId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FunixId = table.Column<string>(type: "varchar(255)", nullable: false),
                    FunixEmail = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HannahId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Hannah_HannahId",
                        column: x => x.HannahId,
                        principalTable: "Hannah",
                        principalColumn: "HannahId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lession",
                columns: table => new
                {
                    LessionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false),
                    LessionType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SubjectId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lession", x => x.LessionId);
                    table.ForeignKey(
                        name: "FK_Lession_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HannahStudent",
                columns: table => new
                {
                    HannahStudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsSupport = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HannahId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HannahStudent", x => x.HannahStudentId);
                    table.ForeignKey(
                        name: "FK_HannahStudent_Hannah_HannahId",
                        column: x => x.HannahId,
                        principalTable: "Hannah",
                        principalColumn: "HannahId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HannahStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentCertificate",
                columns: table => new
                {
                    StudentCertificateId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CertificateId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCertificate", x => x.StudentCertificateId);
                    table.ForeignKey(
                        name: "FK_StudentCertificate_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCertificate_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentContact",
                columns: table => new
                {
                    StudentContactId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContact", x => x.StudentContactId);
                    table.ForeignKey(
                        name: "FK_StudentContact_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StickyNote",
                columns: table => new
                {
                    StickyNoteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HannahStudentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickyNote", x => x.StickyNoteId);
                    table.ForeignKey(
                        name: "FK_StickyNote_HannahStudent_HannahStudentId",
                        column: x => x.HannahStudentId,
                        principalTable: "HannahStudent",
                        principalColumn: "HannahStudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StickyNote_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cf2c15a-32c8-4d96-b42c-315223fe475e"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2668), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2669), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2668), "huynq" },
                    { new Guid("b2a67ddf-a229-4dbb-b269-92e8b74622e7"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "dungtct" },
                    { new Guid("f851e243-45b4-4350-8a2d-a0d0419d6b01"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2610), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2613), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2611), "dattlt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CertificateId",
                table: "Course",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Hannah_UserId",
                table: "Hannah",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HannahStudent_HannahId",
                table: "HannahStudent",
                column: "HannahId");

            migrationBuilder.CreateIndex(
                name: "IX_HannahStudent_StudentId",
                table: "HannahStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lession_SubjectId",
                table: "Lession",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StickyNote_HannahStudentId",
                table: "StickyNote",
                column: "HannahStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StickyNote_StudentId",
                table: "StickyNote",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HannahId",
                table: "Student",
                column: "HannahId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCertificate_CertificateId",
                table: "StudentCertificate",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCertificate_StudentId",
                table: "StudentCertificate",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentContact_StudentId",
                table: "StudentContact",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseId",
                table: "Subject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCertificateCourse_TempCertificateId",
                table: "TempCertificateCourse",
                column: "TempCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCertificateCourse_TempCourseId",
                table: "TempCertificateCourse",
                column: "TempCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCourseWeeklySchedule_TempCourseId",
                table: "TempCourseWeeklySchedule",
                column: "TempCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TempLession_TempSubjectId",
                table: "TempLession",
                column: "TempSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TempSubject_TempCourseId",
                table: "TempSubject",
                column: "TempCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lession");

            migrationBuilder.DropTable(
                name: "StickyNote");

            migrationBuilder.DropTable(
                name: "StudentCertificate");

            migrationBuilder.DropTable(
                name: "StudentContact");

            migrationBuilder.DropTable(
                name: "TempCertificateCourse");

            migrationBuilder.DropTable(
                name: "TempCourseWeeklySchedule");

            migrationBuilder.DropTable(
                name: "TempLession");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "HannahStudent");

            migrationBuilder.DropTable(
                name: "TempCertificate");

            migrationBuilder.DropTable(
                name: "TempSubject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TempCourse");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Hannah");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
