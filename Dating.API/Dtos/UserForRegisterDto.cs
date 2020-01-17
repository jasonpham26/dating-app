using System.ComponentModel.DataAnnotations;

namespace Dating.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength= 4, ErrorMessage= "Password must be longer than 4 characters")]
        public string Password { get; set; }
    }
}