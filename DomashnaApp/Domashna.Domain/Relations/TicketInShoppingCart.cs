using Domashna.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Domain.Relations
{
    public class TicketInShoppingCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public virtual Tickets CurrnetTicket { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart UserCart { get; set; }

        public int Quantity { get; set; }
    }
}
