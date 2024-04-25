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

        }
    }
}
