using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Train_D.DTO.ProfileDtos
{
    public record ProfileWriteDto
    {
        [NotNull]
        public string FirstName { get; init; }
        [NotNull]
        public string LastName { get; init; }
        [NotNull]
        public string City { get; init; }
        [NotNull]
        public string PhoneNumber { get; init; }
        [NotNull]
        public byte [] Image { get; init; }
    }
}
