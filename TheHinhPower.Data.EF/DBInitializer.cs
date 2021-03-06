﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHinhPower.Data.Entities;
using TheHinhPower.Data.Enum;

namespace TheHinhPower.Data.EF
{
    public class DBInitializer
    {
        private readonly AppDBContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DBInitializer(AppDBContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Manager",
                    NormalizedName = "Manager",
                    Description = "Manager"
                });
            }
            if (!_userManager.Users.Any())
            {
                 await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    PhoneNumber = "234234",
                    Email = "admin@gmail.com",
                    Status = Status.Active,
                }, "123456");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
                
                
            }
            if (!_context.CategoryProducts.Any())
            {
                List<CategoryProduct> categoryProducts = new List<CategoryProduct>()
                {
                    new CategoryProduct("Muối ăn", "12", "8", "5", "10"),
                    new CategoryProduct("Muối tắm", "8", "5", "3", "10"),
                    new CategoryProduct("Hộp đặt chân", "5", "3", "2", "10"),
                    new CategoryProduct("Đá liếm động vật", "5", "3", "2", "10"),
                    new CategoryProduct("Đèn", "5", "3", "2", "10"),
                };
                _context.CategoryProducts.AddRange(categoryProducts);
            }
            await _context.SaveChangesAsync();
        }
    }
}
