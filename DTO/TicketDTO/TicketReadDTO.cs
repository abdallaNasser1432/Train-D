namespace Train_D.DTO.TicketDTO
{
    public record TicketReadDTO
    {
        public int TicketId { get; init; }
        public string PassangerName { get; set; }
    }
}
