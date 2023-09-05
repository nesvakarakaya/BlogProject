using System.ComponentModel.DataAnnotations;

namespace blogProject.Models
{
    public class EditUserViewModel
    {



        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
        public string Username { get; set; }

        [Required]     
        public string FullName { get; set; }

        

        public string Locked { get; set; }

        [Required(ErrorMessage = "Please Select Role.")]
        public string Role { get; set; } = "user";


    }


}
