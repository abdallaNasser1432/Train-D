using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train_D.Models
{
    public class User : IdentityUser
    {
        public override string NormalizedUserName { get => UserName; set => base.NormalizedUserName = UserName; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [NotMapped]
        public string Password { get; set; }
        
        public DateTime? BirthDay { get; set; }

        [MaxLength(10)]
        public string City { get; set; }

        public virtual Card_Info Card { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        #nullable enable
        public byte[]? Image { get; set; }
    }
}
