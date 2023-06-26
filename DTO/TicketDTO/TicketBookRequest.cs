using System.Diagnostics.CodeAnalysis;

namespace Train_D.DTO.TicketDTO
{
    public record TicketBookRequest
    {
        [NotNull]
        public int TripId { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
        [NotNull]
        public int SeatNumber { get; set; }
        [NotNull]
        public int Coach { get; set; }
        [NotNull]
        public string Class { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        [NotNull]
        public string PaymentId { get; set; }
    }
}
