﻿using Domashna.Domain.DomainModels;
using Domashna.Domain;
using Domashna.Repository.Interface;
using Domashna.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
