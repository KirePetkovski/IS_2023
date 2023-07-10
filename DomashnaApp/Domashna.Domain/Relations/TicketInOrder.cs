using Domashna.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Domain.Relations
{
    public class TicketInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid TicketId { get; set; }
        public Tickets Ticket { get; set; }
        public int Quantity { get; set; }
    }
}
