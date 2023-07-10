using Domashna.Domain.DomainModels;
using Domashna.Domain.Identity;
using Domashna.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domashna.Domain;
using Domashna.Domain.DTO;

namespace Domashna.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AplicationUser> userManager;
        public AdminController(IOrderService orderService, UserManager<AplicationUser> userManager)
        {
            this._orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            return this._orderService.getAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForTicket(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;

            foreach (var item in model)
            {
                var userCheck = userManager.FindByEmailAsync(item.Email).Result;

                if (userCheck == null)
                {
                    var user = new AplicationUser
                    {
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = userManager.CreateAsync(user, item.Password).Result;

                    status = status && result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
