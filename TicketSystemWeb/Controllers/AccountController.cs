using Microsoft.AspNetCore.Mvc;
using TicketSystemWeb.ViewModels;

namespace TicketSystemWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Login(EmployeeAccountViewModel obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Password == "test")
                {
                    TempData["employee"] = 1;
                    TempData["success"] = "Succesvol ingelogd als medewerker";
                    return RedirectToAction("Index", "Home");

                }
                if (obj.Password == "test2")
                {
                    TempData["administrator"] = 1;
                    TempData["success"] = "Succesvol ingelogd als administrator";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Niet ingelogd: controleer gegevens";
                }
            }
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Logout()
        {
            TempData.Remove("employee");
            TempData.Remove("administrator");
            TempData["success"] = "Succesvol uitgelogd";
            return RedirectToAction("Index");
        }
    }
}
