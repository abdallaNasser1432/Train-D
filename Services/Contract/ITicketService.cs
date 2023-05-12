using Train_D.DTO.TicketDTO;


namespace Train_D.Services.Contract
{
    public interface ITicketService
    {
        bool Isvaild(string pay);
        Task<bool> IsExist(TicketBookRequest dto);
        Task<TicketReadDTO> Book(TicketBookRequest dto, string userId, string username);
        bool IsFound(string userId);
        Task<IEnumerable<TicketDTO>> GetTickets(string userId);

    }
}
