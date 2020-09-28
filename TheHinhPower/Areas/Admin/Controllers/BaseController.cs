using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TheHinhPower.Data.EF;

namespace TheHinhPower.Areas.Admin.Controllers
{
    [Area("Admin")]
    public abstract class BaseController : Controller
    {
        protected AppDBContext _context;
        protected IHttpContextAccessor _httpContextAccessor { get; }
        protected IToastNotification _toastNotification;

        protected BaseController(AppDBContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastNotification)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastNotification;
        }
    }
}