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
        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Cillian_Murphy-2014.jpg/800px-Cillian_Murphy-2014.jpg",
        Email = "alice@example.com",
        IsAdmin = true,
        Uid = "123"
    },
    new User
    {
        Id = 2,
        Name = "Fletcher",
        Image = "https://media.gq-magazine.co.uk/photos/5d13ad12976fa30cf6f3b2a2/1:1/w_1280,h_1280,c_limit/HP.jpg",
        Email = "bob@example.com",
        IsAdmin = true,
        Uid = "345"
    },
    new User
    {
        Id = 3,
        Name = "Charlie",
        Image = "https://s2.r29static.com/bin/entry/c71/0,0,2000,2400/720x864,85/1909057/image.webp",
        Email = "charlie@example.com",
        IsAdmin = true,
        Uid = "345"
    },
    new User
    {
        Id = 4,
        Name = "Mary",
        Image = "https://s.hdnux.com/photos/01/17/67/35/20936552/6/1200x0.jpg",
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
        Image = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg",
        Description = "A thief who enters the dreams of others to steal secrets from their subconscious.",
        DateReleased = new DateTime(2010, 7, 16)
    },
    new Movie
    {
        Id = 3,
        Title = "The Social Network",
        Image = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p8078163_p_v8_ad.jpg",
        Description = "A story about the founders of the social-networking website, Facebook.",
        DateReleased = new DateTime(2010, 10, 1)
    },
   
    new Movie
    {
        Id = 4,
        Title = "The Avengers",
        Image = "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
        Description = "Earth's mightiest heroes must come together and learn to fight as a team.",
        DateReleased = new DateTime(2012, 5, 4)
    },
    new Movie
    {
        Id = 5,
        Title = "Interstellar",
        Image = "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
        Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
        DateReleased = new DateTime(2014, 11, 7)
    },
    new Movie
    {
        Id = 6,
        Title = "Mad Max: Fury Road",
        Image = "https://i.redd.it/mad-max-fury-road-2015-this-live-action-film-by-george-v0-h5q7wvt2yw2b1.jpg?width=793&format=pjpg&auto=webp&s=555a1a328f8cbbaea8fc814aa0be022c8af0da7b",
        Description = "A woman rebels against a tyrannical ruler in postapocalyptic Australia.",
        DateReleased = new DateTime(2015, 5, 15)
    },
    new Movie
    {
        Id = 7,
        Title = "Black Panther",
        Image = "https://lumiere-a.akamaihd.net/v1/images/p_blackpanther_19754_4ac13f07.jpeg?region=0%2C0%2C540%2C810",
        Description = "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.",
        DateReleased = new DateTime(2018, 2, 16)
    },
    new Movie
    {
        Id = 8,
        Title = "Parasite",
        Image = "https://miro.medium.com/v2/resize:fit:1400/1*QJYVaaRVrOF_0tlksmCYIQ.jpeg",
        Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
        DateReleased = new DateTime(2019, 10, 11)
    },
    new Movie
    {
        Id = 9,
        Title = "Joker",
        Image = "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg",
        Description = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime.",
        DateReleased = new DateTime(2019, 10, 4)
    },
    new Movie
    {
        Id = 10,
        Title = "Avengers: Endgame",
        Image = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_.jpg",
        Description = "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
        DateReleased = new DateTime(2019, 4, 26)
    },
    new Movie
{
    Id = 11,
    Title = "The Dark Knight",
    Image = "https://images.moviesanywhere.com/bd47f9b7d090170d79b3085804075d41/c6140695-a35f-46e2-adb7-45ed829fc0c0.jpg",
    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
    DateReleased = new DateTime(2008, 7, 18)
},
new Movie
{
    Id = 12,
    Title = "Avatar",
    Image = "https://m.media-amazon.com/images/I/91N1lG+LBIS._AC_UF1000,1000_QL80_.jpg",
    Description = "A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
    DateReleased = new DateTime(2009, 12, 18)
},
new Movie
{
    Id = 13,
    Title = "Toy Story 3",
    Image = "https://m.media-amazon.com/images/M/MV5BMTgxOTY4Mjc0MF5BMl5BanBnXkFtZTcwNTA4MDQyMw@@._V1_.jpg",
    Description = "The toys are mistakenly delivered to a day-care center instead of the attic right before Andy leaves for college, and it's up to Woody to convince the other toys that they weren't abandoned and to return home.",
    DateReleased = new DateTime(2010, 6, 18)
},
new Movie
{
    Id = 14,
    Title = "Harry Potter and the Deathly Hallows: Part 2",
    Image = "https://images.moviesanywhere.com/5f0537520f90b687fc5db7f241affc4c/842c4e03-abee-4260-a170-bff52e63519a.jpg",
    Description = "Harry, Ron, and Hermione search for Voldemort's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.",
    DateReleased = new DateTime(2011, 7, 15)
},
new Movie
{
    Id = 15,
    Title = "The Hunger Games",
    Image = "https://m.media-amazon.com/images/M/MV5BMjA4NDg3NzYxMF5BMl5BanBnXkFtZTcwNTgyNzkyNw@@._V1_.jpg",
    Description = "Katniss Everdeen voluntarily takes her younger sister's place in the Hunger Games, a televised competition in which two teenagers from each of the twelve Districts of Panem are chosen at random to fight to the death.",
    DateReleased = new DateTime(2012, 3, 23)
},
new Movie
{
    Id = 16,
    Title = "Frozen",
    Image = "https://lumiere-a.akamaihd.net/v1/images/p_frozen_18373_3131259c.jpeg",
    Description = "When the newly crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition.",
    DateReleased = new DateTime(2013, 11, 27)
},
new Movie
{
    Id = 17,
    Title = "Guardians of the Galaxy",
    Image = "https://upload.wikimedia.org/wikipedia/en/3/33/Guardians_of_the_Galaxy_%28film%29_poster.jpg",
    Description = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
    DateReleased = new DateTime(2014, 8, 1)
},
new Movie
{
    Id = 18,
    Title = "The Martian",
    Image = "https://m.media-amazon.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_.jpg",
    Description = "An astronaut becomes stranded on Mars after his team assume him dead, and must rely on his ingenuity to find a way to signal to Earth that he is alive.",
    DateReleased = new DateTime(2015, 10, 2)
},
new Movie
{
    Id = 19,
    Title = "La La Land",
    Image = "https://static.wikia.nocookie.net/filmguide/images/2/28/La_La_Land.png/revision/latest?cb=20220422085615",
    Description = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
    DateReleased = new DateTime(2016, 12, 9)
},
new Movie
{
    Id = 20,
    Title = "Get Out",
    Image = "https://upload.wikimedia.org/wikipedia/en/a/a3/Get_Out_poster.png",
    Description = "A young African-American visits his white girlfriend's parents for the weekend, where his simmering uneasiness about their reception of him eventually reaches a boiling point.",
    DateReleased = new DateTime(2017, 2, 24)
},
new Movie
{
    Id = 21,
    Title = "Spider-Man: Into the Spider-Verse",
    Image = "https://m.media-amazon.com/images/M/MV5BMjMwNDkxMTgzOF5BMl5BanBnXkFtZTgwNTkwNTQ3NjM@._V1_.jpg",
    Description = "Teen Miles Morales becomes the Spider-Man of his universe, and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.",
    DateReleased = new DateTime(2018, 12, 14)
},
new Movie
{
    Id = 22,
    Title = "1917",
    Image = "https://m.media-amazon.com/images/M/MV5BOTdmNTFjNDEtNzg0My00ZjkxLTg1ZDAtZTdkMDc2ZmFiNWQ1XkEyXkFqcGdeQXVyNTAzNzgwNTg@._V1_.jpg",
    Description = "Two young British soldiers during the First World War are given an impossible mission: deliver a message deep in enemy territory that will stop 1,600 men, and one of the soldiers' brothers, from walking straight into a deadly trap.",
    DateReleased = new DateTime(2019, 12, 25)
},
new Movie
{
    Id = 23,
    Title = "Tenet",
    Image = "https://m.media-amazon.com/images/M/MV5BMzU3YWYwNTQtZTdiMC00NjY5LTlmMTMtZDFlYTEyODBjMTk5XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg",
    Description = "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time.",
    DateReleased = new DateTime(2020, 9, 3)
},
new Movie
{
    Id = 24,
    Title = "Soul",
    Image = "https://m.media-amazon.com/images/M/MV5BZGE1MDg5M2MtNTkyZS00MTY5LTg1YzUtZTlhZmM1Y2EwNmFmXkEyXkFqcGdeQXVyNjA3OTI0MDc@._V1_.jpg",
    Description = "A musician who has lost his passion for music is transported out of his body and must find his way back with the help of an infant soul learning about herself.",
    DateReleased = new DateTime(2020, 12, 25)
},
new Movie
{
    Id = 25,
    Title = "The Shawshank Redemption",
    Image = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_.jpg",
    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
    DateReleased = new DateTime(1994, 10, 14)
},
new Movie
{
    Id = 26,
    Title = "Forrest Gump",
    Image = "https://m.media-amazon.com/images/I/410KAWNjZiL._AC_UF1000,1000_QL80_.jpg",
    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
    DateReleased = new DateTime(1994, 7, 6)
},
new Movie
{
    Id = 27,
    Title = "The Matrix",
    Image = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
    DateReleased = new DateTime(1999, 3, 31)
},
new Movie
{
    Id = 28,
    Title = "Gladiator",
    Image = "https://m.media-amazon.com/images/M/MV5BMDliMmNhNDEtODUyOS00MjNlLTgxODEtN2U3NzIxMGVkZTA1L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
    DateReleased = new DateTime(2000, 5, 5)
},
new Movie
{
    Id = 29,
    Title = "Pirates of the Caribbean: The Curse of the Black Pearl",
    Image = "https://m.media-amazon.com/images/M/MV5BNGYyZGM5MGMtYTY2Ni00M2Y1LWIzNjQtYWUzM2VlNGVhMDNhXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
    Description = "Blacksmith Will Turner teams up with eccentric pirate Captain Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies who are now undead.",
    DateReleased = new DateTime(2003, 7, 9)
},
new Movie
{
    Id = 30,
    Title = "The Lord of the Rings: The Return of the King",
    Image = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
    DateReleased = new DateTime(2003, 12, 17)
},
new Movie
{
    Id = 31,
    Title = "The Incredibles",
    Image = "https://m.media-amazon.com/images/M/MV5BMTY5OTU0OTc2NV5BMl5BanBnXkFtZTcwMzU4MDcyMQ@@._V1_.jpg",
    Description = "A family of undercover superheroes, while trying to live the quiet suburban life, are forced into action to save the world.",
    DateReleased = new DateTime(2004, 11, 5)
},
new Movie
{
    Id = 32,
    Title = "The Departed",
    Image = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p162564_p_v8_ag.jpg",
    Description = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.",
    DateReleased = new DateTime(2006, 10, 6)
},
new Movie
{
    Id = 33,
    Title = "No Country for Old Men",
    Image = "https://upload.wikimedia.org/wikipedia/en/8/8b/No_Country_for_Old_Men_poster.jpg",
    Description = "Violence and mayhem ensue after a hunter stumbles upon a drug deal gone wrong and more than two million dollars in cash near the Rio Grande.",
    DateReleased = new DateTime(2007, 11, 21)
},
new Movie
{
    Id = 34,
    Title = "Up",
    Image = "https://upload.wikimedia.org/wikipedia/en/0/05/Up_%282009_film%29.jpg",
    Description = "Seventy-eight year old Carl Fredricksen travels to Paradise Falls in his home equipped with balloons, inadvertently taking a young stowaway.",
    DateReleased = new DateTime(2009, 5, 29)
},
new Movie
{
    Id = 35,
    Title = "Gravity",
    Image = "https://m.media-amazon.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@._V1_.jpg",
    Description = "Two astronauts work together to survive after an accident leaves them stranded in space.",
    DateReleased = new DateTime(2013, 10, 4)
},
new Movie
{
    Id = 36,
    Title = "Whiplash",
    Image = "https://i.ebayimg.com/images/g/pLYAAOSw3v5Yt~VZ/s-l1600.jpg",
    Description = "A promising young drummer enrolls at a cutthroat music conservatory where his dreams of greatness are mentored by an instructor who will stop at nothing to realize a student's potential.",
    DateReleased = new DateTime(2014, 10, 15)
},
new Movie
{
    Id = 37,
    Title = "The Revenant",
    Image = "https://m.media-amazon.com/images/M/MV5BMDE5OWMzM2QtOTU2ZS00NzAyLWI2MDEtOTRlYjIxZGM0OWRjXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_.jpg",
    Description = "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.",
    DateReleased = new DateTime(2015, 12, 25)
},
new Movie
{
    Id = 38,
    Title = "Knives Out",
    Image = "https://m.media-amazon.com/images/M/MV5BMGUwZjliMTAtNzAxZi00MWNiLWE2NzgtZGUxMGQxZjhhNDRiXkEyXkFqcGdeQXVyNjU1NzU3MzE@._V1_.jpg",
    Description = "A detective investigates the death of a patriarch of an eccentric, combative family.",
    DateReleased = new DateTime(2019, 11, 27)
},
new Movie
{
    Id = 39,
    Title = "Blade Runner 2049",
    Image = "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_.jpg",
    Description = "A young blade runner's discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who's been missing for thirty years.",
    DateReleased = new DateTime(2017, 10, 6)
},
new Movie
{
    Id = 40,
    Title = "The Irishman",
    Image = "https://upload.wikimedia.org/wikipedia/en/8/80/The_Irishman_poster.jpg",
    Description = "A mob hitman recalls his possible involvement with the slaying of Jimmy Hoffa.",
    DateReleased = new DateTime(2019, 11, 27)
}
});
    }
    public MoviesBEDbContext(DbContextOptions<MoviesBEDbContext> context) : base(context)
    {
        }
    }


