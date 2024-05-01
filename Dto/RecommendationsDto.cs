using MoviesBE.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesBE.Dto
{
    public class RecommendationsDto
    {
        public int RecUserId { get; set; }

        public int SingleMovieId { get; set; }

        public int RecommendedMovieId { get; set; }
    }
}
