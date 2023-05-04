using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_CoursePlanningWeeklySchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("023e63b6-059c-46a5-9b7b-2dc02ca3a32e"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("e2d9fca9-6e28-4229-a689-23e91fff7220"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("e67359ba-e618-4c61-a31f-5c8930fdc2e0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "StudentCertificate",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "CoursePlanningWeeklySchedule",
                columns: table => new
                {
                    CoursePlanningWeeklyScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WeekOfYear = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TotalQuiz = table.Column<int>(type: "int", nullable: false),
                    TotalLab = table.Column<int>(type: "int", nullable: false),
                    TotalPT = table.Column<int>(type: "int", nullable: false),
                    TotalAss = table.Column<int>(type: "int", nullable: false),
                    TotalFinal = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlanningWeeklySchedule", x => x.CoursePlanningWeeklyScheduleId);
                    table.ForeignKey(
                        name: "FK_CoursePlanningWeeklySchedule_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("3c29e829-078b-41c1-8aec-04d7b6a8c48b"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1345), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1347), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1346), "huynq" },
            //        { new Guid("bfdb2db5-5500-413d-97cb-d1937a7ee39e"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1280), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1283), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1282), "dattlt" },
            //        { new Guid("f6aa560a-7c10-4cde-b6f9-f5786d7b96c3"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1367), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1368), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1368), "dungtct" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlanningWeeklySchedule_CourseId",
                table: "CoursePlanningWeeklySchedule",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePlanningWeeklySchedule");

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("3c29e829-078b-41c1-8aec-04d7b6a8c48b"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("bfdb2db5-5500-413d-97cb-d1937a7ee39e"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("f6aa560a-7c10-4cde-b6f9-f5786d7b96c3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "StudentCertificate",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("023e63b6-059c-46a5-9b7b-2dc02ca3a32e"), new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7214), "", "", false, new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7217), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7216), "dattlt" },
            //        { new Guid("e2d9fca9-6e28-4229-a689-23e91fff7220"), new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7279), "", "", false, new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7280), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7279), "huynq" },
            //        { new Guid("e67359ba-e618-4c61-a31f-5c8930fdc2e0"), new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7311), "", "", false, new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7312), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 13, 44, 29, 219, DateTimeKind.Utc).AddTicks(7312), "dungtct" }
            //    });
        }
    }
}
