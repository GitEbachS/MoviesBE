using MoviesBE.Models;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace MoviesBE.Controllers
{
    public class UsersApi
    {
        public static void Map(WebApplication app)
        {
            //check user
            app.MapPost("/checkuser/{uid}", (MoviesBEDbContext db, string uid) =>
            {
                var user = db.Users.Where(u => u.Uid == uid).FirstOrDefault();

                if (user == null)
                {
                    return Results.NotFound("User not registered");
                }
                return Results.Ok(user);
            });

            //Create user
            app.MapPost("/users/register", (MoviesBEDbContext db, UpdateUserDto userDto) =>
            {
                User newUser = new()
                {
                    Name = userDto.Name,
                    Image = userDto.Image,
                    Email = userDto.Email,
                    Uid = userDto.Uid,
                    IsAdmin = false,
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                return Results.Created($"/users/{newUser.Id}", newUser);
            });

            //Update user
            app.MapPut("/users/{id}", (MoviesBEDbContext db, int id, UpdateUserDto userDto) =>
            {
                var userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);

                if (userToUpdate == null)
                {
                    return Results.NotFound();
                }
                userToUpdate.Name = userDto.Name;
                userToUpdate.Image = userDto.Image;
                userToUpdate.Email = userDto.Email;
                userToUpdate.Uid = userDto.Uid;
                

                db.SaveChanges();

                return Results.Ok(userToUpdate);
            });

            //get single user's details
            app.MapGet("/singleUser/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                User singleUser = db.Users.SingleOrDefault(user => user.Id == userId);
                if (singleUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleUser);
            });

            //add a movie to a user's watchlist
            app.MapPost("/user/addMovie", (MoviesBEDbContext db, UserMovieDto addUserMovieDto) =>
            {
                var singleUserListToUpdate = db.Users
                                            .Include(u => u.Movies)
                                            .FirstOrDefault(u => u.Id == addUserMovieDto.UserId);
                var movieToAdd = db.Movies
                                            .FirstOrDefault(m => m.Id == addUserMovieDto.MovieId);

                try
                {
                    singleUserListToUpdate.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }

            });

            //delete movie from user's watchlist
            app.MapDelete("/users/{userId}/deleteMovie/{movieId}", (MoviesBEDbContext db, int movieId, int userId) =>
            {

                var user = db.Users
                 .Include(u => u.Movies)
                 .FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {

                    return Results.NotFound();
                }
                var movieToRemove = db.Movies
                                    .FirstOrDefault(m => m.Id == movieId);
                if (movieToRemove == null)
                {
                    return Results.NotFound();
                }

                user.Movies.Remove(movieToRemove);
                db.SaveChanges();
                return Results.Ok();
            });

            //get user's movie list
            app.MapGet("/singleUser/watchlist/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                var watchList = db.Users
                                .Include(m => m.Movies)
                                .ThenInclude(m => m.Genres)
                                .Where(u => u.Id == userId)
                                 .Select(u => new
                                 {
                                     u.Id,
                                     u.Name,
                                     u.Email,
                                     u.Image,
                                     u.IsAdmin,
                                     Movies = u.Movies.Select(m => new
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

                if (watchList == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(watchList);
            });

            //get the watchlist by userId only (userobj is not in this)
            app.MapGet("/userId/watchlist/{userId}", (MoviesBEDbContext db, int userId) =>
            {
                var watchList = db.Users
                                .Include(u => u.Movies)
                                .ThenInclude(m => m.Genres)
                                .Where(u => u.Id == userId)
                                .Select(u => new
                                {
                                    Movies = u.Movies.Select(m => new
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

                if (watchList == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(watchList);
            });


        }
    }
}
