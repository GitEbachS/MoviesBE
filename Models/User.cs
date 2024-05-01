using System.ComponentModel.DataAnnotations;
namespace MoviesBE.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
    public List<Recommendation> Recommendations { get; set; }
    public ICollection<Movie> Movies { get; set; }

    public string Uid { get; set; }
}