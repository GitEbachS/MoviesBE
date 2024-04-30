using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesBE.Migrations
{
    public partial class watchlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.MoviesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersId",
                table: "MovieUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 4, 27, 12, 7, 34, 647, DateTimeKind.Local).AddTicks(5990));
        }
    }
}
