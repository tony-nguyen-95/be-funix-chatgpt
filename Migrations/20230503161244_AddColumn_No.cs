using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_No : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Lession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("5663f96a-8f11-4be4-9aba-9f797219cf48"), new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5979), "", "", false, new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5980), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5979), "dungtct" },
            //        { new Guid("8f6de8f3-e029-4412-8870-2f8221790c7e"), new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5954), "", "", false, new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5957), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5955), "huynq" },
            //        { new Guid("eb417692-7120-47c7-a035-1e0fd2847d7b"), new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5896), "", "", false, new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5899), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 12, 44, 875, DateTimeKind.Utc).AddTicks(5898), "dattlt" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("5663f96a-8f11-4be4-9aba-9f797219cf48"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("8f6de8f3-e029-4412-8870-2f8221790c7e"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("eb417692-7120-47c7-a035-1e0fd2847d7b"));

            migrationBuilder.DropColumn(
                name: "No",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Lession");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Course");

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("70c1f13f-86ef-4c16-a7b7-45a5eb5373fc"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2296), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2301), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2299), "dattlt" },
            //        { new Guid("c8a27ab2-3b1b-44b7-ada4-3f3857fef4cc"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2476), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2477), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2476), "dungtct" },
            //        { new Guid("d33bacc5-595a-43cb-b287-8551c4c00a73"), new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2444), "", "", false, new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2446), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 5, 3, 16, 9, 37, 620, DateTimeKind.Utc).AddTicks(2445), "huynq" }
            //    });
        }
    }
}
