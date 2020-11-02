using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.Services;
using SEDC.Lamazon.WebModels.ViewModels;

namespace SEDC.Lamazon.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Products()
        {
            List<ProductViewModel> products = _productService.GetAllProducts().ToList();
            return View(products);
        }
    }
}
