using System.ComponentModel.DataAnnotations;

namespace AF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
