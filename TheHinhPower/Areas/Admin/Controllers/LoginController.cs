using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheHinhPower.Data.Entities;
using TheHinhPower.Data.Enum;
using TheHinhPower.Service.ViewModels;
using TheHinhPower.Utilities.Dtos;

namespace TheHinhPower.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                //return RedirectToAction("Index", "Home", new { area = "Admin" });
                return Redirect("/Admin/Home/Index");
            }
            return View();
        }
        public async Task<IActionResult> Authen(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if(user == null)
                {
                    return new OkObjectResult(new GenericResult(false, "Tài khoản không tồn tại!"));
                }
                if(user.Status == Status.InActive)
                {
                    return new OkObjectResult(new GenericResult(false, "Tài khoản đã bị khóa!"));
                }
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return new OkObjectResult(new GenericResult(true));
                    //return RedirectToAction("Index", "Home", new { area = "Admin" });
                    //return Redirect("/Admin/Home/Index");
                }
                else
                {
                    return new OkObjectResult(new GenericResult(false, "Tên đăng nhập hoặc mật khẩu không đúng"));
                }
            }
            return new OkObjectResult(new GenericResult(false, "Có lỗi xảy ra"));
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Admin/Login/Index");
        }
    }
}