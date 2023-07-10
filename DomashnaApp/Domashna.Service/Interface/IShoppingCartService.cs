using Domashna.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteTicketFromSoppingCart(string userId, Guid productId);
        bool order(string userId);
    }
}
