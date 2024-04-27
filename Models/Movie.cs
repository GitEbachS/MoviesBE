using System.ComponentModel.DataAnnotations;
namespace MoviesBE.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public DateTime DateReleased { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public List<Review> Reviews { get; set; }
    public decimal MovieRating
        {
            get
            {
                if (Reviews != null && Reviews.Any())
                {
                decimal value = (Reviews.Sum(r => r.Rating) / Reviews.Count());
                return Math.Round(value, 2);
                }
                return 0;
            }
        }
}