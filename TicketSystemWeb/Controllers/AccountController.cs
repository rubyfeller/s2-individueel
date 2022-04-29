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

        public List<EmployeeAccountViewModel> TransferViewAll()
        {
            List<EmployeeAccountViewModel> newEmployeeList = new();
            //TicketViewModel viewmodel = new TicketViewModel();
            var employeeList = _EmployeeLogic.GetEmployees();

            foreach (var employee in employeeList)
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
            var newEmployeeList = TransferViewAll();
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
