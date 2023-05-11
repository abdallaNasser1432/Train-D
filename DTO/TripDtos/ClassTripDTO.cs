namespace Train_D.DTO.TripDtos
{
    public record ClassTripDTO : ClaassDTO
    {
        public TimeSpan StartTime { get; init; }

        public TimeSpan ArrivalTime { get; init; }

        public int TrainId { get; init; }
    }
}
