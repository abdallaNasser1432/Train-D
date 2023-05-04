namespace Train_D.DTO.TripDtos
{
    public record SearchTripResultDTO
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int TripId { get; set; }
    }
}
