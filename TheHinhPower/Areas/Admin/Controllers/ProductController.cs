using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatatableHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheHinhPower.Data.Entities;
using TheHinhPower.Service.Interfaces;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IBaseService<Product, ProductViewModel, Guid> _baseService;
        public ProductController(IBaseService<Product, ProductViewModel, Guid> baseService)
        {
            _baseService = baseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEdit(Guid id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEdit(ProductViewModel productViewModel)
        {
            return View();
        }
        public IActionResult Data(RequestData requestData)
        {
            var result = _baseService.GetAllData(requestData);
            return Json(result);
        }

    }
}