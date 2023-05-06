using System.ComponentModel.DataAnnotations;

namespace Train_D.DTO.TripDtos
{
    public record SeatDTO
    {
        public int SeatNumber { get; set; }

        public int Coach { get; set; }

        public string Class { get; set; }
    }
}
