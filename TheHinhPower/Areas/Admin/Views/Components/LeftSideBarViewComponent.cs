using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHinhPower.Data.Entities;
using TheHinhPower.Data.Enum;
using TheHinhPower.Service.Interfaces;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Areas.Admin.Views.Components
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        private IFunctionService _functionService;
        private IMemoryCache _memoryCache;
        private IHttpContextAccessor _httpContextAccessor;
        public LeftSideBarViewComponent(IFunctionService functionService, IMemoryCache memoryCache, IHttpContextAccessor httpContextAccessor)
        {
            _functionService = functionService;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var role = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Roles");
            List<FunctionViewModel> functions = new List<FunctionViewModel>()
                {
                    new FunctionViewModel() {Id = "Categoty_Product", Name = "Danh mục sản phẩm",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/Admin/CategoryProduct",IconCss = "pe-7s-box2"  },
                    new FunctionViewModel() {Id = "Product", Name = "Sản phẩm",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/Admin/Product",IconCss = "pe-7s-box2"  },

                };
            return View(functions);
        }
    }
}
