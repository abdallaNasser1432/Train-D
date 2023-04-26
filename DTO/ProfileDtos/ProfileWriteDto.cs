using System.ComponentModel.DataAnnotations;

namespace Train_D.DTO.ProfileDtos
{
    public record ProfileWriteDto
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string City { get; init; }
        [Required]
        public string PhoneNumber { get; init; }
    }
}
