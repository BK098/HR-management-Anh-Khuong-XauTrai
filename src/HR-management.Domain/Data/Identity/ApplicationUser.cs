
using Microsoft.AspNetCore.Identity;

namespace HR_management.Domain.Data.Identity
{
    public class ApplicationUser //: IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
