using App.EndPoint.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.WebSockets;

namespace App.EndPoint.Mvc.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> SeedData()
        {
            var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("AdminRole"));
            var costumerRoleResult = await _roleManager.CreateAsync(new IdentityRole<int>("CustomerRole"));
            var adminUserResult=await _userManager.CreateAsync(new IdentityUser<int>("admin"));
            if (adminRoleResult.Succeeded)
            {
                var adminUser=await _userManager.FindByNameAsync("admin");
               await _userManager.AddToRoleAsync(adminUser, "admin");
            }
            var testUserResult= await _userManager.CreateAsync(new IdentityUser<int>("test"));
            if (testUserResult.Succeeded)
            {
                var testUser= await _userManager.FindByNameAsync("test");
                await _userManager.AddToRoleAsync(testUser, "test");
            }
            return Ok();
        }
    }
}
