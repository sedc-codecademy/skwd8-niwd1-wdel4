using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.WebModels.ViewModels;

namespace SEDC.Lamazon.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService,
                               IUserService userService,
                               IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult ListOrders()
        {
            int userId = 1;
            List<OrderViewModel> userOrders = _orderService.GetAllOrders()
                                                            .Where(x => x.User.Id == userId)
                                                            .ToList();
            return View(userOrders);
        }

        public IActionResult ListAllOrders()
        {
            List<OrderViewModel> orders = _orderService.GetAllOrders().ToList();
            return View(orders);
        }
    }
}
