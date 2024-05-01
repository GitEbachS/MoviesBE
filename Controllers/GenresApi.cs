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
                var genre = db.Genres.FirstOrDefault(x => x.Id == id);
                var movies = db.Movies
                    .Include(m => m.Genres)
                    .Where(g => g.Genres.Contains(genre))
                    .Select(m => new
                        {
                            m.Id,
                            m.Image,
                            m.Title,
                            m.Genres,
                        })
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
