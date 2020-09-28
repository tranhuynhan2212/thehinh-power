using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatatableHelper;
using Microsoft.AspNetCore.Mvc;
using TheHinhPower.Data.Entities;
using TheHinhPower.Service.Interfaces;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryProductController : Controller
    {
        private IBaseService<CategoryProduct, CategoryProductViewModel, Guid> _baseService;

        public CategoryProductController(IBaseService<CategoryProduct, CategoryProductViewModel, Guid> baseService)
        {
            _baseService = baseService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Data(RequestData requestData)
        {
            var resultData = _baseService.GetAllData(requestData);
            return Json(resultData);
        }
    }
}