namespace Train_D.DTO.TripDtos
{
    public record ClaassDTO
    {
        public string ClassName { get; init; }

        public int Coaches { get; init; }

        public int NumberOfSeatsCoach { get; init; }

        public decimal ClassPrice { get; init; }

    }
}
