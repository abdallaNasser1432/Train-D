using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Train_D.Models
{
    public class Card_Info
    {
        [MaxLength(20)]
        public string CardNumber { get; set; }

        [Required,MaxLength(8)]
        public string ExpDate { get; set; }

        [MaxLength(3), MinLength(3), Required]
        public string CVV { get; set; }

        
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
