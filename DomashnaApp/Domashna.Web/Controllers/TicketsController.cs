using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

using Microsoft.AspNetCore.Identity;
using Domashna.Repository.Interface;
using Domashna.Domain.DTO;
using Domashna.Domain.DomainModels;
using Domashna.Service.Interface;

namespace Domashna.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _TicketService;
  
        public TicketsController(ITicketService _TicketService)
        {
            _TicketService = _TicketService;
        }

        public IActionResult Index()
        {
            var allTickets =this._TicketService.GetAllTickets();
            return View(allTickets);
        }
        public IActionResult AddTicketToCard(Guid? id)
        {
            var model = this._TicketService.GetShoppingCartInfo(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicketToCard([Bind("TicketId", "Quantity")]AddToShoppingCardDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result= this._TicketService.AddToShoppingCart(item, userId);
            if(result)
            {
                return RedirectToAction("Index", "Tickets");
            }
            return View(item);
        }
       
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = this._TicketService.GetDetailsForTicket(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TicketName,TicketImage,Price,Rating,data")] Tickets Ticket)
        {
            if (ModelState.IsValid)
            {
                
                this._TicketService.CreateNewTicket(Ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(Ticket);
        }


        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = this._TicketService.GetDetailsForTicket(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            return View(Ticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,TicketName,TicketImage,Price,Rating,data")] Tickets Ticket)
        {
            if (id != Ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._TicketService.UpdeteExistingTicket(Ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(Ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Ticket);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = this._TicketService.GetDetailsForTicket(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._TicketService.DeleteTicket(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return this._TicketService.GetDetailsForTicket(id) != null;
        }
    }
}
