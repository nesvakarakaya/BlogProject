using System.ComponentModel.DataAnnotations;

namespace blogProject.Models
{
    public class CreateUserViewModel
    {



        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 10 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "RePassword is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 10 characters.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
        
        public string Locked { get; set; }


        [Required(ErrorMessage = "Please Select Role.")]
        public string Role { get; set; } = "user";


    }


}
