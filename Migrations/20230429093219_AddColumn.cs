using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("0cf2c15a-32c8-4d96-b42c-315223fe475e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("b2a67ddf-a229-4dbb-b269-92e8b74622e7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("f851e243-45b4-4350-8a2d-a0d0419d6b01"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Student",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Student",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("03431632-1b2e-4e9c-9bf5-96c851605a42"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "dungtct" },
                    { new Guid("1f3899c2-3d14-4786-bdcd-d02694ec5888"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8164), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8165), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8164), "huynq" },
                    { new Guid("4c755940-82a8-4343-b294-739b7c5d3888"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8139), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8142), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8141), "dattlt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("03431632-1b2e-4e9c-9bf5-96c851605a42"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("1f3899c2-3d14-4786-bdcd-d02694ec5888"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("4c755940-82a8-4343-b294-739b7c5d3888"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Student");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cf2c15a-32c8-4d96-b42c-315223fe475e"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2668), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2669), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2668), "huynq" },
                    { new Guid("b2a67ddf-a229-4dbb-b269-92e8b74622e7"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2690), "dungtct" },
                    { new Guid("f851e243-45b4-4350-8a2d-a0d0419d6b01"), new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2610), "", "", false, new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2613), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 28, 12, 26, 58, 535, DateTimeKind.Utc).AddTicks(2611), "dattlt" }
                });
        }
    }
}
