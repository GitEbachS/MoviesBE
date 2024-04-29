using MoviesBE.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesBE.Dto
{
    public class MovieToUpdateDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
