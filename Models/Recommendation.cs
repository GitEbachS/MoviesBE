using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBE.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public int RecUserId { get; set; }
        public User RecUser { get; set; }

        public int SingleMovieId { get; set; }
        public Movie SingleMovie { get; set; }

        public int RecommendedMovieId { get; set; }
        public Movie RecommendedMovie { get; set; }

    }
}