using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesBE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateReleased = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    CommentReview = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    MoviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Drama" },
                    { 3, "Action" },
                    { 4, "Science Fiction" },
                    { 5, "Comedy" },
                    { 6, "Western" },
                    { 7, "Romance" },
                    { 8, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateReleased", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bright, fragrant, and sweet", "https://m.media-amazon.com/images/I/514z-fxF0uL._SX300_SY300_QL70_FMwebp_.jpg", "Thor: The Dark World" },
                    { 2, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "A thief who enters the dreams of others to steal secrets from their subconscious.", "https://m.media-amazon.com/images/I/91l3cX6a4ZL._SL1500_.jpg", "Inception" },
                    { 3, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A story about the founders of the social-networking website, Facebook.", "https://m.media-amazon.com/images/I/51DnOUsPegL._AC_SY679_.jpg", "The Social Network" },
                    { 4, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earth's mightiest heroes must come together and learn to fight as a team.", "https://m.media-amazon.com/images/I/81vTHovrz+L._AC_SY679_.jpg", "The Avengers" },
                    { 5, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "https://m.media-amazon.com/images/I/91jlm3rVKOL._AC_SY679_.jpg", "Interstellar" },
                    { 6, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A woman rebels against a tyrannical ruler in postapocalyptic Australia.", "https://m.media-amazon.com/images/I/61A8Ezv0YRL._AC_SY679_.jpg", "Mad Max: Fury Road" },
                    { 7, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.", "https://m.media-amazon.com/images/I/91Nz5QZvb0L._AC_SY679_.jpg", "Black Panther" },
                    { 8, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", "https://m.media-amazon.com/images/I/81MCeOFWFJL._AC_SY679_.jpg", "Parasite" },
                    { 9, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime.", "https://m.media-amazon.com/images/I/71hXrd1cmRL._AC_SY679_.jpg", "Joker" },
                    { 10, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", "https://m.media-amazon.com/images/I/81ai9zxNP1L._AC_SY679_.jpg", "Avengers: Endgame" },
                    { 11, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://m.media-amazon.com/images/I/81rXmI0jeyL._AC_SY679_.jpg", "The Dark Knight" },
                    { 12, new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.", "https://m.media-amazon.com/images/I/71ZMrPH9ZGL._AC_SY679_.jpg", "Avatar" },
                    { 13, new DateTime(2010, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it's up to Woody to convince the other toys that they weren't abandoned and to return home.", "https://m.media-amazon.com/images/I/81OBK2NcFgL._AC_SY679_.jpg", "Toy Story 3" },
                    { 14, new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.", "https://m.media-amazon.com/images/I/81RKysa9WKL._AC_SY679_.jpg", "Harry Potter and the Deathly Hallows: Part 2" },
                    { 15, new DateTime(2012, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katniss Everdeen voluntarily takes her younger sister's place in the Hunger Games, a televised competition in which two teenagers from each of the twelve Districts of Panem are chosen at random to fight to the death.", "https://m.media-amazon.com/images/I/81e2SCdrPpL._AC_SY679_.jpg", "The Hunger Games" },
                    { 16, new DateTime(2013, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition.", "https://m.media-amazon.com/images/I/91J8E6vOUwL._AC_SY679_.jpg", "Frozen" },
                    { 17, new DateTime(2014, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", "https://m.media-amazon.com/images/I/81WXT06J7gL._AC_SY679_.jpg", "Guardians of the Galaxy" },
                    { 18, new DateTime(2015, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "An astronaut becomes stranded on Mars after his team assume him dead, and must rely on his ingenuity to find a way to signal to Earth that he is alive.", "https://m.media-amazon.com/images/I/71jSJ1hM1XL._AC_SY679_.jpg", "The Martian" },
                    { 19, new DateTime(2016, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.", "https://m.media-amazon.com/images/I/71r6Pw6OBFLL._AC_SY679_.jpg", "La La Land" },
                    { 20, new DateTime(2017, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A young African-American visits his white girlfriend's parents for the weekend, where his simmering uneasiness about their reception of him eventually reaches a boiling point.", "https://m.media-amazon.com/images/I/81E6rLEqRgL._AC_SY679_.jpg", "Get Out" },
                    { 21, new DateTime(2018, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teen Miles Morales becomes the Spider-Man of his universe, and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.", "https://m.media-amazon.com/images/I/71rWhfYP7-L._AC_SY679_.jpg", "Spider-Man: Into the Spider-Verse" },
                    { 22, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Two young British soldiers during the First World War are given an impossible mission: deliver a message deep in enemy territory that will stop 1,600 men, and one of the soldiers' brothers, from walking straight into a deadly trap.", "https://m.media-amazon.com/images/I/81bzWVm-M-L._AC_SY679_.jpg", "1917" },
                    { 23, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.", "https://m.media-amazon.com/images/I/71bS40TWqgL._AC_SY679_.jpg", "Tenet" },
                    { 24, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A musician who has lost his passion for music is transported out of his body and must find his way back with the help of an infant soul learning about herself.", "https://m.media-amazon.com/images/I/71cZKuCFpEL._AC_SY679_.jpg", "Soul" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CommentReview", "DateCreated", "MovieId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Excellent movie, highly recommended.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4047), 1, 5, 1 },
                    { 2, "Enjoyed it, but pacing was a bit slow.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4125), 2, 4, 2 },
                    { 3, "Decent movie, but expected more from the storyline.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4129), 3, 3, 3 },
                    { 4, "Absolutely loved it, couldn't stop thinking about it!", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4132), 4, 5, 4 },
                    { 5, "Great action scenes, but the plot was a bit predictable.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4136), 5, 4, 1 },
                    { 6, "Average movie, nothing too special.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4139), 6, 3, 2 },
                    { 7, "One of the best movies I've seen in a long time!", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4142), 7, 5, 3 },
                    { 8, "Really enjoyed it, great performances from the cast.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4145), 8, 4, 4 },
                    { 9, "Hilarious movie, had me laughing from start to finish!", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4148), 9, 4, 1 },
                    { 10, "Some funny moments, but overall a bit too silly for my taste.", new DateTime(2024, 4, 23, 18, 22, 27, 554, DateTimeKind.Local).AddTicks(4151), 10, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "IsAdmin", "Name", "Uid" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "https://example.com/images/alice.jpg", true, "Alex", "123" },
                    { 2, "bob@example.com", "https://example.com/images/bob.jpg", true, "Fletcher", "345" },
                    { 3, "charlie@example.com", "https://example.com/images/charlie.jpg", true, "Charlie", "345" },
                    { 4, "mary@example.com", "https://example.com/images/mary.jpg", true, "Mary", "567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
