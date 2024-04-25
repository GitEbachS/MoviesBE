using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesBE.Migrations
{
    public partial class EbachCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 19, 52, 35, 334, DateTimeKind.Local).AddTicks(5810));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4151));
        }
    }
}
