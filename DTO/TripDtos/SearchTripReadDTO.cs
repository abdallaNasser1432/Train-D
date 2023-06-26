using Newtonsoft.Json;

namespace Train_D.DTO.TripDtos
{
    public record SearchTripReadDTO
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int TripId { get; set; }
        public int TrainId { get; set; }
        public int totalseats { get; set; }
    }
}
