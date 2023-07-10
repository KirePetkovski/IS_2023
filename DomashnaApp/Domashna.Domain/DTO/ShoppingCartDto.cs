using System;
using System.Collections.Generic;
using System.Text;
using Domashna.Domain.DomainModels;
using Domashna.Domain.Relations;

namespace Domashna.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart> Tickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
