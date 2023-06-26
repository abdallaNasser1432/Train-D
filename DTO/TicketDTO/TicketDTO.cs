namespace Train_D.DTO.TicketDTO
{
    public class TicketDTO
    {
        public string From { get; set; }
        public string To { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Duration { get; set; }
        public int TicketId { get; set; }
        public string PassengerName { get; set; }
        public DateTime Date { get; set; }
        public string ClassName { get; set; }
        public int CoachNumber { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
