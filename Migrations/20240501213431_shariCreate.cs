using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesBE.Migrations
{
    public partial class shariCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 34, 31, 397, DateTimeKind.Local).AddTicks(9014));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 4, 29, 19, 36, 14, 536, DateTimeKind.Local).AddTicks(9748));
        }
    }
}
