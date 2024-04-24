using System.ComponentModel.DataAnnotations;
namespace MoviesBE.Models;
    public class Review
    {
    public int Id { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public string CommentReview { get; set; }
    public DateTime DateCreated { get; set; }
}

