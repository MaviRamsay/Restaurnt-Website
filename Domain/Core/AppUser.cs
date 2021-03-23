using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Restaurant_Website.Domain.Core
{
    public class AppUser : IdentityUser
    {
        public ICollection<Cart> Cart { get; set; }
    }
}
