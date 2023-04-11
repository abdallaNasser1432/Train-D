using Microsoft.EntityFrameworkCore;

namespace Train_D.Models
{
    [Owned]
    public class RefreshTokens
    {
        public string Token { get; set; }
        
        public DateTime ExpiresOn { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

        public DateTime CreatedOn { get; set; }
        
        public DateTime? RevokOn { get; set; }

        public bool IsActive => RevokOn == null && !IsExpired ;


    }
}
