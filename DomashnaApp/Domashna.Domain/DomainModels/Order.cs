using Domashna.Domain.Identity;
using Domashna.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public AplicationUser User { get; set; }

        public virtual ICollection<TicketInOrder> TicketInOrders { get; set; }
    }
}
