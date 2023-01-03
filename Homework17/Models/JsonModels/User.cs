using System.ComponentModel.DataAnnotations;

namespace Homework17.Models.JsonModels
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public DateTime CreationAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
