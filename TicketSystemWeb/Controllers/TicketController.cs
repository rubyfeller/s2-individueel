using LOGIC.Interfaces;
using LOGIC.TicketLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TicketSystemWeb.Models;

namespace TicketSystemWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketLogic _ITicketLogic;

        public TicketController(ITicketLogic TicketLogic)
        {
            _ITicketLogic = TicketLogic;
        }

        public List<TicketViewModel> TransferViewAll()
        {
            List<TicketViewModel> newTicketList = new();
            TicketViewModel viewmodel = new TicketViewModel();
            var ticketList = _ITicketLogic.GetTickets();

            foreach (var tickets in ticketList)
            {
                newTicketList.Add(new TicketViewModel
                {
                    TicketId = tickets.TicketId,
                    TicketSubject = tickets.TicketSubject,
                    TicketContent = tickets.TicketContent,
                    TicketCategory = (TicketViewModel.ticketCategories)tickets.TicketCategory,
                    TicketPriority = (TicketViewModel.ticketPriorities)tickets.TicketPriority,
                    TicketStatus = (TicketViewModel.ticketStatuses)tickets.TicketStatus,
                    CreatedDateTime = tickets.CreatedDateTime,

                });
            }
            return newTicketList;
        }

        public TicketViewModel TransferViewSpecfic(int ticketid)
        {
            List<TicketViewModel> newTicketList = new();
            TicketViewModel viewmodel = null;
            var ticketList = _ITicketLogic.GetTicket(ticketid);

            foreach (var tickets in ticketList)
            {
                TicketViewModel currTicket = new TicketViewModel
                {
                    TicketId = tickets.TicketId,
                    TicketSubject = tickets.TicketSubject,
                    TicketContent = tickets.TicketContent,
                    TicketCategory = (TicketViewModel.ticketCategories)tickets.TicketCategory,
                    TicketPriority = (TicketViewModel.ticketPriorities)tickets.TicketPriority,
                    TicketStatus = (TicketViewModel.ticketStatuses)tickets.TicketStatus,
                    CreatedDateTime = tickets.CreatedDateTime,
                };
                newTicketList.Add(currTicket);
                viewmodel = currTicket;
            }
            return viewmodel;
        }

        public IActionResult Index()
        {
            var newTicketList = TransferViewAll();
            return View(newTicketList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //GET
        public IActionResult View(int ticketId)
        {
            if (ticketId == 0)
            {
                return NotFound();
            }

            var specificTicket = TransferViewSpecfic(ticketId);

            if (specificTicket == null)
            {
                return NotFound();
            }
            else
            {
                return View(specificTicket);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = _ITicketLogic.AddTicket(obj.TicketSubject, obj.TicketContent, obj.CreatedDateTime, (int)obj.TicketCategory, (int)obj.TicketPriority, (int)obj.TicketStatus);

                if (result != null)
                {
                    TempData["success"] = "Ticket succesvol toegevoegd";
                }
                else
                {
                    TempData["error"] = "Ticket niet toegevoegd";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int ticketId)
        {
            if (ticketId == 0)
            {
                return NotFound();
            }

            var specificTicket = TransferViewSpecfic(ticketId);


            if (specificTicket == null)
            {
                return NotFound();
            }
            else
            {
                return View(specificTicket);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = _ITicketLogic.UpdateTicket(obj.TicketId, obj.TicketSubject, obj.TicketContent, obj.CreatedDateTime, (int)obj.TicketCategory, (int)obj.TicketPriority, (int)obj.TicketStatus);

                if (result != null)
                {
                    TempData["success"] = "Ticket succesvol aangepast";
                }
                else
                {
                    TempData["error"] = "Ticket niet aangepast";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int ticketId)
        {
            if (ticketId == 0)
            {
                return NotFound();
            }

            var specificTicket = TransferViewSpecfic(ticketId);

            if (specificTicket == null)
            {
                return NotFound();
            }

            return View(specificTicket);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(TicketViewModel obj)
        {
            var result = _ITicketLogic.DeleteTicket(obj.TicketId);

            if (result != null)
            {
                TempData["success"] = "Apparaat succesvol verwijderd";
            }
            else
            {
                TempData["error"] = "Apparaat niet verwijderd";
            }
            return RedirectToAction("Index");
        }
    }
}
