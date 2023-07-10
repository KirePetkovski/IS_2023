
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminApplication.Models
{
    public class TicketInOrder 
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid TicketId { get; set; }
        public Tickets Ticket { get; set; }
        public int Quantity { get; set; }
    }
}
