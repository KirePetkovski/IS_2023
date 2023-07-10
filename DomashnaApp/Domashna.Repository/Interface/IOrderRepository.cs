using Domashna.Domain.DomainModels;
using Domashna.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);

    }
}
