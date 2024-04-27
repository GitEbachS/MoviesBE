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

        }
    }
}
