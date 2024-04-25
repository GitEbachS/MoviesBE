using MoviesBE.Models;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Dto;

namespace MoviesBE.Controllers
{
    public class MoviesApi
    {
        public static void Map(WebApplication app)
        {
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

        }
    }
}
