using System.ComponentModel.DataAnnotations;

namespace blogProject.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public bool Locked { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string Role { get; set; } = "user";

    }
}
