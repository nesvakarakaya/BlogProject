using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogProject.Entities
{
    [Table("Users")]
    public class User
    {

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool Locked { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;


    }
}
