using MoviesBE.Models;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Dto;

namespace MoviesBE.Controllers
{
    public class ReviewsApi
    {
        public static void Map(WebApplication app)
        {
            //get reviews by movieId
            app.MapGet("/reviews/{movieId}", (MoviesBEDbContext db, int movieId) =>
            {
                var reviewList = db.Reviews
                                    .Where(r => r.MovieId == movieId)
                                    .OrderByDescending(r => r.DateCreated)
                                    .Select(r => new
                                    {
                                        r.Id,
                                        AuthorName = db.Users.Where(u => u.Id == r.UserId).Select(u => u.Name)
                                        .FirstOrDefault(),
                                        r.MovieId,
                                        r.Rating,
                                        r.CommentReview,
                                        DateCreated = r.DateCreated.ToString("MM/dd/yyyy"),
                                    })
                                    .ToList();

                return Results.Ok(reviewList);
            });

            //get reviews by userId
            app.MapGet("/reviews/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                var reviewList = db.Reviews
                                    .Where(r => r.UserId == userId)
                                    .OrderByDescending (r => r.DateCreated)
                                    .Select(r => new
                                    {
                                        r.Id,
                                        AuthorName = db.Users.Where(u => u.Id == r.UserId).Select(u => u.Name)
                                        .FirstOrDefault(),
                                        r.MovieId,
                                        r.Rating,
                                        r.CommentReview,
                                        DateCreated = r.DateCreated.ToString("MM/dd/yyyy"),
                                    })
                                    .ToList();

                return Results.Ok(reviewList);
            });

        }
    }
}
