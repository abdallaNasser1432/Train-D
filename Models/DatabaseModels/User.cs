using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train_D.Models
{
    public class User : IdentityUser
    {
        // To make normalizedUserName case-senstive
        public override string NormalizedUserName { get => UserName; set => base.NormalizedUserName = UserName; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [NotMapped]
        public string Password { get; set; }
        

        [MaxLength(20)]
        public string City { get; set; }

        // (one to one ) relationship with card_info Table
        public Card_Info Card { get; set; }

        // (many to one ) relationship with Tickets Table
        public List<Ticket> Tickets { get; set; }

        #nullable enable
        public byte[]? Image { get; set; }

        
    }
}
