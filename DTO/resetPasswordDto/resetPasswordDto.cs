using System.ComponentModel.DataAnnotations;

namespace Train_D.DTO.resetPasswordDto
{
    public class resetPasswordDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
