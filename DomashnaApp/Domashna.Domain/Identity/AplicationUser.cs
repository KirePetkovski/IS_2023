using Domashna.Domain;
using Domashna.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Domashna.Domain.Identity
{
    public class AplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}
