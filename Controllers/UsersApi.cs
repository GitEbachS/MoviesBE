using MoviesBE.Models;
using Microsoft.EntityFrameworkCore;
using MoviesBE.Dto;


namespace MoviesBE.Controllers
{
    public class UsersApi
    {
        public static void Map(WebApplication app)
        {
            //check user
            app.MapGet("/checkuser/{uid}", (MoviesBEDbContext db, string uid) =>
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
                    IsAdmin = true,
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
        }
    }
}
