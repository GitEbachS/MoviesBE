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
            app.MapGet("/reviews/singleMovie/{movieId}", (MoviesBEDbContext db, int movieId) =>
            {
                var reviewList = db.Reviews
                                    .Where(r => r.MovieId == movieId)
                                    .OrderByDescending(r => r.DateCreated)
                                    .Select(r => new
                                    {
                                        r.Id,
                                        r.UserId,
                                        AuthorName = db.Users.Where(u => u.Id == r.UserId).Select(u => u.Name)
                                        .FirstOrDefault(),
                                        AuthorImage = db.Users.Where(u =>u.Id == r.UserId).Select(ai => ai.Image).FirstOrDefault(),
                                        r.MovieId,
                                        r.Rating,
                                        r.CommentReview,
                                        DateCreated = r.DateCreated.ToString("MM/dd/yyyy"),
                                    })
                                    .ToList();

                return Results.Ok(reviewList);
            });

            //get reviews by userId
            app.MapGet("/reviews/singleUser/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                var reviewList = db.Reviews
                                    .Where(r => r.UserId == userId)
                                    .OrderByDescending (r => r.DateCreated)
                                    .Select(r => new
                                    {
                                        r.Id,
                                        r.UserId,
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

            // get review by movieId and userId - if the user has reviewed a movie, get that review
            app.MapGet("/reviews/{movieId}/user/{userId}", (MoviesBEDbContext db, int movieId, int userId) =>
            {
                var singleReview = db.Reviews
                    .Where(m => m.MovieId == movieId && m.UserId == userId)
                    .FirstOrDefault();

                if (singleReview == null)
                {
                    return Results.Empty;
                }

                return Results.Ok(singleReview);
            });

            // create review
            app.MapPost("/reviews", (MoviesBEDbContext db, Review newReview) =>
            {
                db.Reviews.Add(newReview);
                db.SaveChanges();
                return Results.Created($"/reviews/{newReview.Id}", newReview);
            });

            // update review
            app.MapPut("/reviews/{id}", (MoviesBEDbContext db, int id, Review review) =>
            {
                var reviewToUpdate = db.Reviews.FirstOrDefault(r => r.Id == id);
                
                if (reviewToUpdate == null)
                {
                    return Results.NotFound();
                }

                reviewToUpdate.Rating = review.Rating;
                reviewToUpdate.CommentReview = review.CommentReview;

                db.SaveChanges();
                return Results.Ok();
            });

            app.MapDelete("/reviews/{id}", (MoviesBEDbContext db, int id) =>
            {
                var reviewToDelete = db.Reviews.FirstOrDefault(x => x.Id == id);

                if (reviewToDelete == null)
                {
                    return Results.NotFound();
                }
                
                db.Reviews.Remove(reviewToDelete);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}
