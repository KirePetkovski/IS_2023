using Domashna.Domain.DomainModels;
using Domashna.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
