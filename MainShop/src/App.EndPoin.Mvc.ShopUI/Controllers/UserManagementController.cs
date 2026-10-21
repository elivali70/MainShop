using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Mvc.ShopUI.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
