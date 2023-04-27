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

        public string PaymentId { get; set; }


        public string UserId { get; set; }
        public int TrainId { get; set; }
        public int TripId { get; set; }

        public  Trip Trip { get; set; }
        public  User User { get; set; }

    }
}
