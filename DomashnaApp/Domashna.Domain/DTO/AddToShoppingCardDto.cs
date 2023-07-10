using System;
using System.Collections.Generic;
using System.Text;
using Domashna.Domain.DomainModels;

namespace Domashna.Domain.DTO
{
    public class AddToShoppingCardDto
    {
        public Tickets SelectedTicket { get; set; }
        public Guid SelectedTicketId { get; set; }
        public int Quantity { get; set; }
    }
}
