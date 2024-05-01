using Microsoft.EntityFrameworkCore;
using MoviesBE.Dto;
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
                        Genres = m.Genres.Select(g => new { g.Id, g.Name }), // Include genres

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


            //***get top reviewed 20 movies
            app.MapGet("/movies/toprated", (MoviesBEDbContext db) =>
            {
                var movies = db.Movies
                    .Include(m => m.Genres)
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
                          Genres = m.Genres.Select(g => new { g.Id, g.Name }), // Include genres
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
                          Genres = m.Genres.Select(g => new { g.Id, g.Name }), // Include genres
                      })
                    .ToList();
            });

            //***Search movies by Title
            app.MapGet("/movies/search/{query}", (MoviesBEDbContext db, string query) =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return Results.BadRequest("Search query cannot be empty");
                }

                var filteredMovies = db.Movies
                    .Include(m => m.Genres) // Include genres
                    .Where(m => m.Title.ToLower().Contains(query.ToLower()))
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Image,
                        m.Description,
                        DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                        m.MovieRating,
                        Genres = m.Genres.Select(g => new { g.Id, g.Name }), // Include genres
                    })
                    .ToList();

                if (filteredMovies.Count == 0)
                {
                    return Results.NotFound("No movies found for the given search query.");
                }
                else
                {
                    return Results.Ok(filteredMovies);
                }
            });


            //***delete movie
            app.MapDelete("/movies/remove/{id}", (MoviesBEDbContext db, int id) =>
            {
                var movieToDelete = db.Movies
                                    .Include(m => m.Genres)
                                    .Include(m => m.Reviews)
                                    .FirstOrDefault(m => m.Id == id);

                if (movieToDelete == null)
                {
                    return Results.NotFound();
                }

                db.Movies.Remove(movieToDelete);
                db.SaveChanges();

                return Results.Ok(movieToDelete);
            });

            //***create movie
            app.MapPost("/movies", (MoviesBEDbContext db, MovieToUpdateDto newMovieDto) =>
            {
                var newMovie = new Movie
                {
                    Title = newMovieDto.Title,
                    Description = newMovieDto.Description,
                    Image = newMovieDto.Image,
                    DateReleased = newMovieDto.DateReleased,
                    Genres = new List<Genre>()
                };

                // Add the new movie to the database context
                db.Movies.Add(newMovie);

                // Add genres to the new movie
                foreach (var genreId in newMovieDto.GenreIds)
                {
                    var genre = db.Genres.Find(genreId);
                    if (genre != null)
                    {
                        newMovie.Genres.Add(genre);
                    }
                }

                db.SaveChanges();

                return Results.Created($"/movies/{newMovie.Id}", newMovie);
            });

            //**update Movie
            app.MapPut("/movies/{id}", (MoviesBEDbContext db, MovieToUpdateDto updateMovieDto, int id) =>
            {
                var movieToUpdate = db.Movies
                                        .Include(m => m.Genres)
                                        .FirstOrDefault(m => m.Id == id);

                if (movieToUpdate == null)
                {
                    return Results.NotFound();
                }

                // Update movie properties
                movieToUpdate.Title = updateMovieDto.Title;
                movieToUpdate.Description = updateMovieDto.Description;
                movieToUpdate.Image = updateMovieDto.Image;
                movieToUpdate.DateReleased = updateMovieDto.DateReleased;

                // Update movie's genres
                movieToUpdate.Genres.Clear(); // Remove existing genres

                foreach (var genreId in updateMovieDto.GenreIds)
                {
                    var genre = db.Genres.Find(genreId);
                    if (genre != null)
                    {
                        movieToUpdate.Genres.Add(genre);
                    }
                }

                db.SaveChanges();
                return Results.Ok(movieToUpdate);
            });

            //movie recommendations
            //add movie recommendation
            app.MapPost("/recommendations/new", (MoviesBEDbContext db, RecommendationsDto newRecDto) =>
            {
                // Check if the movie and user exist
                if (!db.Movies.Any(m => m.Id == newRecDto.SingleMovieId) || !db.Users.Any(u => u.Id == newRecDto.RecUserId) || !db.Movies.Any(m => m.Id == newRecDto.RecommendedMovieId))
                {
                    return Results.NotFound();
                }

                Recommendation newRecommendation = new()
                {
                    RecUserId = newRecDto.RecUserId,
                    SingleMovieId = newRecDto.SingleMovieId,
                    RecommendedMovieId = newRecDto.RecommendedMovieId
                };

                db.Recommendations.Add(newRecommendation);
                db.SaveChanges();
                return Results.Created($"/recommendations/{newRecommendation.Id}", newRecommendation);

            });

            // Delete recommendation from user's recommended list for a specific movie
            app.MapDelete("/users/{userId}/deleteRecommendation/{recMovieId}/fromMovie/{movieId}", (MoviesBEDbContext db, int recMovieId, int userId, int movieId) =>
            {
                var movieRecToRemove = db.Recommendations
                                        .Where(r => r.RecUserId == userId && r.RecommendedMovieId == recMovieId && r.SingleMovieId == movieId)
                                        .FirstOrDefault();

                if (movieRecToRemove == null)
                {
                    return Results.NotFound();
                }

                db.Recommendations.Remove(movieRecToRemove);
                db.SaveChanges();
                return Results.Ok("Success!");
            });

            //get user's recommended movie list
            app.MapGet("/singleUser/recommendations/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                var recommendationList = db.Users
                                            .Include(u => u.Recommendations)
                                            .Where(u => u.Id == userId)
                                            .Select(u => new
                                            {
                                                u.Id,
                                                u.Name,
                                                u.Email,
                                                u.Image,
                                                u.IsAdmin,
                                                u.Uid,
                                                RecommendedMovies = u.Recommendations.Select(r => r.RecommendedMovie).Select(m => new
                                                {
                                                    m.Id,
                                                    m.Title,
                                                    m.Image,
                                                    m.Description,
                                                    DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                                                    m.MovieRating,
                                                    Genres = m.Genres.Select(g => new { g.Id, g.Name })
                                                })
                                            })
                                            .FirstOrDefault();

                if (recommendationList == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(recommendationList);
            });

            //get single movie's recommended movie list
            app.MapGet("/singleMovie/recommendations/{movieId}", (MoviesBEDbContext db, int movieId) =>
            {
                var recommendationList = db.Movies
                                            .Include(m => m.Recommendations)
                                                .ThenInclude(r => r.RecUser)
                                            .Where(m => m.Id == movieId)
                                            .Select(m => new
                                            {
                                                m.Id,
                                                m.Title,
                                                m.Image,
                                                m.Description,
                                                DateReleased = m.DateReleased.ToString("MM/dd/yyyy"),
                                                m.MovieRating,
                                                Genres = m.Genres.Select(g => new { g.Id, g.Name }),
                                                RecommendedMovies = m.Recommendations.Select(r => new
                                                {
                                                    RecommendedMovie = r.RecommendedMovie,
                                                    RecUserName = r.RecUser.Name
                                                }).Select(recommendedMovie => new
                                                {
                                                    recommendedMovie.RecommendedMovie.Id,
                                                    recommendedMovie.RecommendedMovie.Title,
                                                    recommendedMovie.RecommendedMovie.Image,
                                                    recommendedMovie.RecommendedMovie.Description,
                                                    DateReleased = recommendedMovie.RecommendedMovie.DateReleased.ToString("MM/dd/yyyy"),
                                                    recommendedMovie.RecommendedMovie.MovieRating,
                                                    Genres = recommendedMovie.RecommendedMovie.Genres.Select(g => new { g.Id, g.Name }),
                                                    RecUserName = recommendedMovie.RecUserName // RecUser's name
                                                })
                                            })
                                            .FirstOrDefault();

                if (recommendationList == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(recommendationList);
            });



        }
    }
}
