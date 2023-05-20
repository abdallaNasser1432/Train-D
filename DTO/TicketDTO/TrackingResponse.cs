namespace Train_D.DTO.TicketDTO
{
    public record TrackingResponse
    {
        public string FromStation { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan ArrivalTime { get; init; }
        public int TrainId { get; init; }
        public decimal Longitude { get; init; }
        public decimal Latitude { get; init; }
    }
}
