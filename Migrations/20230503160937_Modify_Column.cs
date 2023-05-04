using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject");

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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Lession");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Lession");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Subject",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lession",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneDate",
                table: "Lession",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Course",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Course",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("70c1f13f-86ef-4c16-a7b7-45a5eb5373fc"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2296), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2301), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2299), "dattlt" },
            //        { new Guid("c8a27ab2-3b1b-44b7-ada4-3f3857fef4cc"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2476), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2477), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2476), "dungtct" },
            //        { new Guid("d33bacc5-595a-43cb-b287-8551c4c00a73"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2444), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2446), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2445), "huynq" }
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject");

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("70c1f13f-86ef-4c16-a7b7-45a5eb5373fc"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("c8a27ab2-3b1b-44b7-ada4-3f3857fef4cc"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("d33bacc5-595a-43cb-b287-8551c4c00a73"));

            migrationBuilder.DropColumn(
                name: "DoneDate",
                table: "Lession");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Subject",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lession",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Lession",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Lession",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Course",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Course",
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
            //        { new Guid("3c29e829-078b-41c1-8aec-04d7b6a8c48b"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1345), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1347), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1346), "huynq" },
            //        { new Guid("bfdb2db5-5500-413d-97cb-d1937a7ee39e"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1280), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1283), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1282), "dattlt" },
            //        { new Guid("f6aa560a-7c10-4cde-b6f9-f5786d7b96c3"), new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1367), "", "", false, new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1368), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 15, 3, 5, 139, DateTimeKind.Utc).AddTicks(1368), "dungtct" }
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId");
        }
    }
}
