using Domashna.Domain.Identity;
using Domashna.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual AplicationUser Owner { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }

    }
}
