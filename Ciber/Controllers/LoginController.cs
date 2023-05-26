using Ciber.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ciber.Controllers
{
    public class LoginController : Controller
    {
        readonly string userName = "admin";
        readonly string password = "123456";
        public IActionResult Index()
        {
            if (HttpContext.Session.Get("Login") != null)
            {
                return Redirect("/Order/Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLogin model)
        {
            if (model.UserName == userName && model.Password == password)
            {
                HttpContext.Session.SetString("Login", userName);
                return Redirect("/Order/Index");
            }
            else
            {
                TempData["MsgLogin"] = "Login fail!";
                return Redirect("/Login");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }

    }
}
