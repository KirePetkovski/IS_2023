using Domashna.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Domain.DomainModels
{
    public class Tickets : BaseEntity
    {
        public string MovieName { get; set; }
        public string Zarn { get; set; }
        public DateTime DateAvailable { get; set; }   
        public double TicketPrice { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public virtual ICollection<TicketInOrder> TicketInOrders { get; set; }
    }
}
