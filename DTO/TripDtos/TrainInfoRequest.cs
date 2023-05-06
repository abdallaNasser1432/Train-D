using System.Diagnostics.CodeAnalysis;

namespace Train_D.DTO.TripDtos
{
    public record TrainInfoRequest
    {
        [NotNull]
        public int TripId { get; init; }
        [NotNull]
        public DateTime Date { get; init; }
    }
}
