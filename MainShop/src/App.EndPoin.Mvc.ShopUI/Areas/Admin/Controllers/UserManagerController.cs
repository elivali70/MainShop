using App.EndPoint.Mvc.ShopUI.Areas.Admin.Models.ViewModel.UserManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.EndPoint.Mvc.ShopUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;

        public UserManagerController(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var model=await _userManager.Users.Select(u =>new UserViewModel
            {
                Id= u.Id,
                Name=u.UserName,
                PhoneNumber=u.PhoneNumber,
                Email=u.Email,
                
            }).ToListAsync();
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Search(string? name)
        {
            

                if (string.IsNullOrEmpty(name))
                    return RedirectToAction("Index");
                var model = await _userManager.Users.Where(x => x.UserName.Contains(name)).Select(m => new UserViewModel
                {
                    Id = m.Id,
                    Name = m.UserName,
                    PhoneNumber = m.PhoneNumber,
                    Email = m.Email,

                }).ToListAsync();
            if (model.Count == 0)
            {
                ViewBag.Message = "کاربری با این مشخصات پیدا نشد.";
            }

            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int id)
        {
            var model = await _userManager.Users.Where(x => x.Id == id).Select(x => new ChangePasswordViewModel
            {
                UserId=x.Id

            }).SingleOrDefaultAsync();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.Where(x => x.Id == model.UserId).SingleOrDefaultAsync();
                if (user == null)
                    return NotFound();
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View(model);
                    }
                }

            }
            
           return RedirectToAction("Index");
        }
    }
}
