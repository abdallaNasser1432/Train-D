using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train_D.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }


        public DateTime Date { get; set; }

        public int SeatNumber { get; set; }

        public int Coach { get; set; }

        [MaxLength(2), Required]
        public string Class { get; set; }


        public decimal Amount { get; set; }

        public int? TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        
        public string UserId { get; set; }
        public int TrainId { get; set; }
        public int TripId { get; set; }

        // ( one to many ) relationship with Trips Table
        public virtual Trip Trip { get; set; }
        
        // (one to many ) relationship with Users Table
        public virtual User User { get; set; }

    }
}
