using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Models;

namespace MoviesBE.Controllers
{
    public class GenresApi
    {
        public static void Map(WebApplication app)
        {
            //***get all genres
            app.MapGet("/genres", (MoviesBEDbContext db) =>
            {
                return db.Genres.ToList();
            });

            //get movie's by genre
            app.MapGet("/genres/{id}/movies", (MoviesBEDbContext db, int id) =>
            {
                var movies = db.Genres
                    .Include(m => m.Movies)
                    .Where(g => g.Id == id)
                    .Select(m => m.Movies
                        .Select(m => new { 
                            m.Id,
                            m.Title,
                            m.Genres,
                            m.Image
                        }))
                    .ToList();
                if (movies == null)
                {
                    return Results.Empty;
                }

                return Results.Ok(movies);
            });
        }
    }
}
