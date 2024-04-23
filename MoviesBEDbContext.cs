using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Models;
public class MoviesBEDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>().HasData(new User[]
{
    new User
    {
        Id = 1,
        Name = "Alex",
        Image = "https://example.com/images/alice.jpg",
        Email = "alice@example.com",
        IsAdmin = true,
        Uid = "123"
    },
    new User
    {
        Id = 2,
        Name = "Fletcher",
        Image = "https://example.com/images/bob.jpg",
        Email = "bob@example.com",
        IsAdmin = true,
        Uid = "345"
    },
    new User
    {
        Id = 3,
        Name = "Charlie",
        Image = "https://example.com/images/charlie.jpg",
        Email = "charlie@example.com",
        IsAdmin = true,
        Uid = "345"
    },
    new User
    {
        Id = 4,
        Name = "Mary",
        Image = "https://example.com/images/mary.jpg",
        Email = "mary@example.com",
        IsAdmin = true,
        Uid = "567"
    }
});

        modelBuilder.Entity<Review>().HasData(new Review[]
{
    new Review
    {
        Id = 1,
        Rating = 5,
        UserId = 1,
        MovieId = 1,
        CommentReview = "Excellent movie, highly recommended.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 2,
        Rating = 4,
        UserId = 2,
        MovieId = 2,
        CommentReview = "Enjoyed it, but pacing was a bit slow.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 3,
        Rating = 3,
        UserId = 3,
        MovieId = 3,
        CommentReview = "Decent movie, but expected more from the storyline.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 4,
        Rating = 5,
        UserId = 4,
        MovieId = 4,
        CommentReview = "Absolutely loved it, couldn't stop thinking about it!",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 5,
        Rating = 4,
        UserId = 1,
        MovieId = 5,
        CommentReview = "Great action scenes, but the plot was a bit predictable.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 6,
        Rating = 3,
        UserId = 2,
        MovieId = 6,
        CommentReview = "Average movie, nothing too special.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 7,
        Rating = 5,
        UserId = 3,
        MovieId = 7,
        CommentReview = "One of the best movies I've seen in a long time!",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 8,
        Rating = 4,
        UserId = 4,
        MovieId = 8,
        CommentReview = "Really enjoyed it, great performances from the cast.",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 9,
        Rating = 4,
        UserId = 1,
        MovieId = 9,
        CommentReview = "Hilarious movie, had me laughing from start to finish!",
        DateCreated = DateTime.Now
    },
    new Review
    {
        Id = 10,
        Rating = 3,
        UserId = 1,
        MovieId = 10,
        CommentReview = "Some funny moments, but overall a bit too silly for my taste.",
        DateCreated = DateTime.Now
    }
});


        modelBuilder.Entity<Genre>().HasData(new Genre[]
{
    new Genre { Id = 1, Name = "Horror" },
    new Genre { Id = 2, Name = "Drama" },
    new Genre { Id = 3, Name = "Action" },
    new Genre { Id = 4, Name = "Science Fiction" },
    new Genre { Id = 5, Name = "Comedy" },
    new Genre { Id = 6, Name = "Western" },
    new Genre { Id = 7, Name = "Romance" },
    new Genre { Id = 8, Name = "Fantasy" }
});

        modelBuilder.Entity<Movie>().HasData(new Movie[]
{
    new Movie
    {
        Id = 1,
        Title = "Thor: The Dark World",
        Image = "https://m.media-amazon.com/images/I/514z-fxF0uL._SX300_SY300_QL70_FMwebp_.jpg",
        Description = "Bright, fragrant, and sweet",
        DateReleased = new DateTime(2013, 11, 8)
    },
    new Movie
    {
        Id = 2,
        Title = "Inception",
        Image = "https://m.media-amazon.com/images/I/91l3cX6a4ZL._SL1500_.jpg",
        Description = "A thief who enters the dreams of others to steal secrets from their subconscious.",
        DateReleased = new DateTime(2010, 7, 16)
    },
    new Movie
    {
        Id = 3,
        Title = "The Social Network",
        Image = "https://m.media-amazon.com/images/I/51DnOUsPegL._AC_SY679_.jpg",
        Description = "A story about the founders of the social-networking website, Facebook.",
        DateReleased = new DateTime(2010, 10, 1)
    },
   
    new Movie
    {
        Id = 4,
        Title = "The Avengers",
        Image = "https://m.media-amazon.com/images/I/81vTHovrz+L._AC_SY679_.jpg",
        Description = "Earth's mightiest heroes must come together and learn to fight as a team.",
        DateReleased = new DateTime(2012, 5, 4)
    },
    new Movie
    {
        Id = 5,
        Title = "Interstellar",
        Image = "https://m.media-amazon.com/images/I/91jlm3rVKOL._AC_SY679_.jpg",
        Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
        DateReleased = new DateTime(2014, 11, 7)
    },
    new Movie
    {
        Id = 6,
        Title = "Mad Max: Fury Road",
        Image = "https://m.media-amazon.com/images/I/61A8Ezv0YRL._AC_SY679_.jpg",
        Description = "A woman rebels against a tyrannical ruler in postapocalyptic Australia.",
        DateReleased = new DateTime(2015, 5, 15)
    },
    new Movie
    {
        Id = 7,
        Title = "Black Panther",
        Image = "https://m.media-amazon.com/images/I/91Nz5QZvb0L._AC_SY679_.jpg",
        Description = "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.",
        DateReleased = new DateTime(2018, 2, 16)
    },
    new Movie
    {
        Id = 8,
        Title = "Parasite",
        Image = "https://m.media-amazon.com/images/I/81MCeOFWFJL._AC_SY679_.jpg",
        Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
        DateReleased = new DateTime(2019, 10, 11)
    },
    new Movie
    {
        Id = 9,
        Title = "Joker",
        Image = "https://m.media-amazon.com/images/I/71hXrd1cmRL._AC_SY679_.jpg",
        Description = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime.",
        DateReleased = new DateTime(2019, 10, 4)
    },
    new Movie
    {
        Id = 10,
        Title = "Avengers: Endgame",
        Image = "https://m.media-amazon.com/images/I/81ai9zxNP1L._AC_SY679_.jpg",
        Description = "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
        DateReleased = new DateTime(2019, 4, 26)
    },
    new Movie
{
    Id = 11,
    Title = "The Dark Knight",
    Image = "https://m.media-amazon.com/images/I/81rXmI0jeyL._AC_SY679_.jpg",
    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
    DateReleased = new DateTime(2008, 7, 18)
},
new Movie
{
    Id = 12,
    Title = "Avatar",
    Image = "https://m.media-amazon.com/images/I/71ZMrPH9ZGL._AC_SY679_.jpg",
    Description = "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
    DateReleased = new DateTime(2009, 12, 18)
},
new Movie
{
    Id = 13,
    Title = "Toy Story 3",
    Image = "https://m.media-amazon.com/images/I/81OBK2NcFgL._AC_SY679_.jpg",
    Description = "The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it's up to Woody to convince the other toys that they weren't abandoned and to return home.",
    DateReleased = new DateTime(2010, 6, 18)
},
new Movie
{
    Id = 14,
    Title = "Harry Potter and the Deathly Hallows: Part 2",
    Image = "https://m.media-amazon.com/images/I/81RKysa9WKL._AC_SY679_.jpg",
    Description = "Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.",
    DateReleased = new DateTime(2011, 7, 15)
},
new Movie
{
    Id = 15,
    Title = "The Hunger Games",
    Image = "https://m.media-amazon.com/images/I/81e2SCdrPpL._AC_SY679_.jpg",
    Description = "Katniss Everdeen voluntarily takes her younger sister's place in the Hunger Games, a televised competition in which two teenagers from each of the twelve Districts of Panem are chosen at random to fight to the death.",
    DateReleased = new DateTime(2012, 3, 23)
},
new Movie
{
    Id = 16,
    Title = "Frozen",
    Image = "https://m.media-amazon.com/images/I/91J8E6vOUwL._AC_SY679_.jpg",
    Description = "When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition.",
    DateReleased = new DateTime(2013, 11, 27)
},
new Movie
{
    Id = 17,
    Title = "Guardians of the Galaxy",
    Image = "https://m.media-amazon.com/images/I/81WXT06J7gL._AC_SY679_.jpg",
    Description = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
    DateReleased = new DateTime(2014, 8, 1)
},
new Movie
{
    Id = 18,
    Title = "The Martian",
    Image = "https://m.media-amazon.com/images/I/71jSJ1hM1XL._AC_SY679_.jpg",
    Description = "An astronaut becomes stranded on Mars after his team assume him dead, and must rely on his ingenuity to find a way to signal to Earth that he is alive.",
    DateReleased = new DateTime(2015, 10, 2)
},
new Movie
{
    Id = 19,
    Title = "La La Land",
    Image = "https://m.media-amazon.com/images/I/71r6Pw6OBFLL._AC_SY679_.jpg",
    Description = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
    DateReleased = new DateTime(2016, 12, 9)
},
new Movie
{
    Id = 20,
    Title = "Get Out",
    Image = "https://m.media-amazon.com/images/I/81E6rLEqRgL._AC_SY679_.jpg",
    Description = "A young African-American visits his white girlfriend's parents for the weekend, where his simmering uneasiness about their reception of him eventually reaches a boiling point.",
    DateReleased = new DateTime(2017, 2, 24)
},
new Movie
{
    Id = 21,
    Title = "Spider-Man: Into the Spider-Verse",
    Image = "https://m.media-amazon.com/images/I/71rWhfYP7-L._AC_SY679_.jpg",
    Description = "Teen Miles Morales becomes the Spider-Man of his universe, and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.",
    DateReleased = new DateTime(2018, 12, 14)
},
new Movie
{
    Id = 22,
    Title = "1917",
    Image = "https://m.media-amazon.com/images/I/81bzWVm-M-L._AC_SY679_.jpg",
    Description = "Two young British soldiers during the First World War are given an impossible mission: deliver a message deep in enemy territory that will stop 1,600 men, and one of the soldiers' brothers, from walking straight into a deadly trap.",
    DateReleased = new DateTime(2019, 12, 25)
},
new Movie
{
    Id = 23,
    Title = "Tenet",
    Image = "https://m.media-amazon.com/images/I/71bS40TWqgL._AC_SY679_.jpg",
    Description = "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.",
    DateReleased = new DateTime(2020, 9, 3)
},
new Movie
{
    Id = 24,
    Title = "Soul",
    Image = "https://m.media-amazon.com/images/I/71cZKuCFpEL._AC_SY679_.jpg",
    Description = "A musician who has lost his passion for music is transported out of his body and must find his way back with the help of an infant soul learning about herself.",
    DateReleased = new DateTime(2020, 12, 25)
}
});

    }
    public MoviesBEDbContext(DbContextOptions<MoviesBEDbContext> context) : base(context)
    {
        }
    }


