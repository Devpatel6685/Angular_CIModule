using System.ComponentModel.DataAnnotations;


namespace CIPlatform.DAL.ViewModels
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}