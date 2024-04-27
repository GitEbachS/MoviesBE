using Microsoft.EntityFrameworkCore;
using MoviesBE.Models;

namespace MoviesBE.Controllers
{
    public class MoviesApi
    {
        public static void Map(WebApplication app)
        {
            //***get all movies
            app.MapGet("/movies", (MoviesBEDbContext db) =>
            {
                return db.Movies
                    .Include(m => m.Genres)
                    .Include(m => m.Reviews)
                    .ToList();
            });

            //***get single movie
            app.MapGet("/movies/{movieId}", (MoviesBEDbContext db, int movieId) =>
            {
                return db.Movies
                    .Include(m => m.Genres)
                    .Include(m => m.Reviews)
                    .FirstOrDefault(m => m.Id == movieId);
            });

            //get top reviewed 20 movies
                app.MapGet("/movies/toprated", (MoviesBEDbContext db) =>
                {
                    var movies = db.Movies
                        .Include(m => m.Reviews)
                        .ToList();

                    var topRatedMovies = movies
                        .OrderByDescending(m => m.MovieRating)
                        .Take(20)
                        .ToList();

                    return topRatedMovies; 
                });

            //***get recent 20 movies
            app.MapGet("/movies/recent", (MoviesBEDbContext db) =>
            {
                return db.Movies
                    .OrderByDescending(m => m.DateReleased)
                    .Take(20)
                    .ToList();
            });
            //Search movies by Title
            app.MapGet("/movies/search/{query}", (MoviesBEDbContext db, string query) =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return Results.BadRequest("Search query cannot be empty");
                }

                var filteredPosts = db.Movies.Where(m => m.Title.ToLower().Contains(query.ToLower())).ToList();

                if (filteredPosts.Count == 0)
                {
                    return Results.NotFound("No posts found for the given search query.");
                }
                else
                {
                    return Results.Ok(filteredPosts);
                }
            });

        }
    }
}
