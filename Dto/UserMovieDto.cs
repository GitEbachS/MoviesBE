using MoviesBE.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesBE.Dto
{
    public class UserMovieDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
