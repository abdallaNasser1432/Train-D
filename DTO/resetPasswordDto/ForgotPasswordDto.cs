using System.Diagnostics.CodeAnalysis;

namespace Train_D.DTO.resetPasswordDto
{
    public class ForgotPasswordDto
    {
        [NotNull]
        public string Email { get; set; }
    }
}
