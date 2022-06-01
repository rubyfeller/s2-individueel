using LOGIC.Entities;
using LOGIC.Interfaces;
using LOGIC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicketSystemWeb.ViewModels;

namespace TicketSystemWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeLogic _EmployeeLogic;
        public AccountController(IEmployeeLogic EmployeeLogic)
        {
            _EmployeeLogic = EmployeeLogic;
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<Employee> GetEmployees()
        {
            return _EmployeeLogic.GetEmployees();
        }

        public List<EmployeeAccountViewModel> TransferViewAll(List<Employee> employees)
        {
            List<EmployeeAccountViewModel> newEmployeeList = new();

            foreach (var employee in employees)
            {
                newEmployeeList.Add(new EmployeeAccountViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Password = employee.Password,
                    CompetenceLevel = employee.CompetenceLevel,
                    Role = employee.Role

                });
            }
            return newEmployeeList;
        }

        public IActionResult Info()
        {
            List<EmployeeAccountViewModel> newEmployeeList = TransferViewAll(GetEmployees());
            return View(newEmployeeList);
        }

        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Login(EmployeeAccountViewModel obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Password == "medewerker")
                {
                    TempData["employee"] = 1;
                    TempData["success"] = "Succesvol ingelogd als medewerker";
                    return RedirectToAction("Index", "Home");

                }
                if (obj.Password == "administrator")
                {
                    TempData["administrator"] = 2;
                    TempData["success"] = "Succesvol ingelogd als administrator";
                    return RedirectToAction("Index", "Home");
                }
                if (obj.Password == "klant")
                {
                    TempData["klant"] = 3;
                    TempData["success"] = "Succesvol ingelogd als klant";
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
