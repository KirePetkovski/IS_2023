using Domashna.Domain.DTO;
using Domashna.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Service.Interface
{
    public interface ITicketService
    {
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
        void CreateNewTicket(Tickets p);
        void DeleteTicket(Guid id);
        List<Tickets> GetAllTickets();
        Tickets GetDetailsForTicket(Guid? id);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void UpdeteExistingTicket(Tickets p);
      
     
    }

}
