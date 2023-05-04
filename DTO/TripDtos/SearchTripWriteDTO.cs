using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Train_D.DTO.TripDtos
{
    
    public record SearchTripWriteDTO
    {
        [NotNull]
        public string FromStation { get; init; }
        [NotNull]
        public string ToStation { get; init; }
        [NotNull]
        public DateTime Date { get; init; }
    }
}
