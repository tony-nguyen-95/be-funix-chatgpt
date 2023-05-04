using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Funix.HannahAssistant.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationship_StudentContact_StickyNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("03431632-1b2e-4e9c-9bf5-96c851605a42"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("1f3899c2-3d14-4786-bdcd-d02694ec5888"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("4c755940-82a8-4343-b294-739b7c5d3888"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentContactId",
                table: "StickyNote",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_StickyNote_StudentContactId",
                table: "StickyNote",
                column: "StudentContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_StickyNote_StudentContact_StudentContactId",
                table: "StickyNote",
                column: "StudentContactId",
                principalTable: "StudentContact",
                principalColumn: "StudentContactId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StickyNote_StudentContact_StudentContactId",
                table: "StickyNote");

            migrationBuilder.DropIndex(
                name: "IX_StickyNote_StudentContactId",
                table: "StickyNote");

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("65350e9b-110b-474b-a138-fec65fca564e"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("7415ae5f-f537-443e-85c7-68e7c0157ed1"));

            //migrationBuilder.DeleteData(
            //    table: "User",
            //    keyColumn: "UserId",
            //    keyValue: new Guid("b1054a49-1acb-46c4-a3e8-c63d5eb21236"));

            migrationBuilder.DropColumn(
                name: "StudentContactId",
                table: "StickyNote");

            //migrationBuilder.InsertData(
            //    table: "User",
            //    columns: new[] { "UserId", "CreatedDate", "FunixEmail", "FunixId", "IsDeleted", "LoginDate", "Password", "UpdatedDate", "UserName" },
            //    values: new object[,]
            //    {
            //        { new Guid("03431632-1b2e-4e9c-9bf5-96c851605a42"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8208), "dungtct" },
            //        { new Guid("1f3899c2-3d14-4786-bdcd-d02694ec5888"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8164), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8165), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8164), "huynq" },
            //        { new Guid("4c755940-82a8-4343-b294-739b7c5d3888"), new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8139), "", "", false, new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8142), "6BFCC4026B5F162799A6DC8305C09DB9C1674AC616BD5C7422A45FBB6D0816AC163047C47A1F426F4F4C6B5B5042C671EABC4FDC7310FD5B183EEF59DC274604", new DateTime(2023, 4, 29, 9, 32, 18, 947, DateTimeKind.Utc).AddTicks(8141), "dattlt" }
            //    });
        }
    }
}
