using Domashna.Domain.DomainModels;
using Domashna.Domain.DTO;
using Domashna.Domain.Relations;
using Domashna.Repository.Interface;
using Domashna.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domashna.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Tickets> _TicketsRepository;
        private readonly IRepository<TicketInShoppingCart> _TicketsInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public TicketService(IRepository<Tickets> TicketsRepository, IRepository<TicketInShoppingCart> TicketsInShoppingCartRepository, IUserRepository userRepository)
        {
            _TicketsRepository = TicketsRepository;
            _userRepository = userRepository;
            _TicketsInShoppingCartRepository = TicketsInShoppingCartRepository;
        }


        public bool AddToShoppingCart(AddToShoppingCardDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.SelectedTicketId != null && userShoppingCard != null)
            {
                var ticket = this.GetDetailsForTicket(item.SelectedTicketId);
                //{896c1325-a1bb-4595-92d8-08da077402fc}

                if (ticket != null)
                {
                    TicketInShoppingCart itemToAdd = new TicketInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CurrnetTicket = ticket,
                        TicketId = ticket.Id,
                        UserCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.TicketInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.TicketId == itemToAdd.TicketId).FirstOrDefault();

                    if (existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._TicketsInShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._TicketsInShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewTicket(Tickets p)
        {
            this._TicketsRepository.Insert(p);
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = this.GetDetailsForTicket(id);
            this._TicketsRepository.Delete(ticket);
        }

        public List<Tickets> GetAllTickets()
        {
            return this._TicketsRepository.GetAll().ToList();
        }

        public Tickets GetDetailsForTicket(Guid? id)
        {
            return this._TicketsRepository.Get(id);
        }

        public AddToShoppingCardDto GetShoppingCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForTicket(id);
            AddToShoppingCardDto model = new AddToShoppingCardDto
            {
                SelectedTicket = ticket,
                SelectedTicketId = ticket.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingTicket(Tickets p)
        {
            this._TicketsRepository.Update(p);
        }
    }


}
