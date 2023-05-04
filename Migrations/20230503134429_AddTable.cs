using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Hannah_HannahId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_HannahId",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("65350e9b-110b-474b-a138-fec65fca564e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("7415ae5f-f537-443e-85c7-68e7c0157ed1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("b1054a49-1acb-46c4-a3e8-c63d5eb21236"));

            migrationBuilder.DropColumn(
                name: "HannahId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "TempSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "TempLession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "TempCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "StudentCertificate",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanEndDate",
                table: "StudentCertificate",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanStartDate",
                table: "StudentCertificate",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Student",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hannah",
                type: "longtext",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("023e63b6-059c-46a5-9b7b-2dc02ca3a32e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("e2d9fca9-6e28-4229-a689-23e91fff7220"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("e67359ba-e618-4c61-a31f-5c8930fdc2e0"));

            migrationBuilder.DropColumn(
                name: "No",
                table: "TempSubject");

            migrationBuilder.DropColumn(
                name: "No",
                table: "TempLession");

            migrationBuilder.DropColumn(
                name: "No",
                table: "TempCourse");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "StudentCertificate");

            migrationBuilder.DropColumn(
                name: "PlanEndDate",
                table: "StudentCertificate");

            migrationBuilder.DropColumn(
                name: "PlanStartDate",
                table: "StudentCertificate");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hannah");

            migrationBuilder.AddColumn<Guid>(
                name: "HannahId",
                table: "Student",
                type: "char(36)",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("65350e9b-110b-474b-a138-fec65fca564e"), new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1516), "", "", false, new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1518), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1517), "dattlt" },
            //        { new Guid("7415ae5f-f537-443e-85c7-68e7c0157ed1"), new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1605), "", "", false, new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1606), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1605), "dungtct" },
            //        { new Guid("b1054a49-1acb-46c4-a3e8-c63d5eb21236"), new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1584), "", "", false, new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1585), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 2, 2, 0, 39, 434, DateTimeKind.Utc).AddTicks(1584), "huynq" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Student_HannahId",
                table: "Student",
                column: "HannahId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Hannah_HannahId",
                table: "Student",
                column: "HannahId",
                principalTable: "Hannah",
                principalColumn: "HannahId");
        }
    }
}
