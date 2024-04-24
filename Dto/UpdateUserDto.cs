using MoviesBE.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesBE.Dto
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Image {  get; set; }
        public string Uid { get; set; }
    }
}
