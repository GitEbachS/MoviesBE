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
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Image,
                        m.Description,
                        DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                        m.MovieRating,
                    })
                    .ToList();
            });

            //***get single movie
            app.MapGet("/movies/{movieId}", (MoviesBEDbContext db, int movieId) =>
            {
                return db.Movies
                    .Where(m => m.Id == movieId)
                    .Include(m => m.Genres)
                    .Include(m => m.Reviews)
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Image,
                        m.Description,
                        DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                        m.MovieRating,
                        Genres = m.Genres.Select(g => new { g.Id, g.Name }), // Include genres
                        Reviews = m.Reviews.Select(r => new
                        {
                            r.Id,
                            r.Rating,
                            r.UserId,
                            r.MovieId,
                            r.CommentReview,
                            DateCreated = r.DateCreated.ToString("MM/dd/yyyy"),
                        }) // Include reviews
                    })
                    .FirstOrDefault();
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
                      .Select(m => new
                      {
                          m.Id,
                          m.Title,
                          m.Image,
                          m.Description,
                          DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                          m.MovieRating,
                      })
                    .ToList();

                return topRatedMovies;
            });

            //***get recent 20 movies
            app.MapGet("/movies/recent", (MoviesBEDbContext db) =>
            {
                return db.Movies
                    .OrderByDescending(m => m.DateReleased)
                    .Take(20)
                      .Select(m => new
                      {
                          m.Id,
                          m.Title,
                          m.Image,
                          m.Description,
                          DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                          m.MovieRating,
                      })
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
