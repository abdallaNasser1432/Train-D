using System.ComponentModel.DataAnnotations;

namespace Train_D.DTO.changePasswordDtos
{
    public class ChangePasswrodRequest
    {
        [Required(ErrorMessage ="CurrentPasswrod is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "NewPasswrod is required")]
        public string NewPassword { get; set; }
    }
}
