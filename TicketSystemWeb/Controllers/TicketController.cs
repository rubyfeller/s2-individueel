using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicketSystemWeb.Models;
using TicketSystemWeb.ViewModels;

namespace TicketSystemWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketLogic _ITicketLogic;
        private readonly ICommentLogic _ICommentLogic;
        private readonly IDeviceLogic _IDeviceLogic;

        public TicketController(ITicketLogic TicketLogic, ICommentLogic CommentLogic, IDeviceLogic DeviceLogic)
        {
            _ITicketLogic = TicketLogic;
            _ICommentLogic = CommentLogic;
            _IDeviceLogic = DeviceLogic;
        }

        public List<Ticket> GetTickets()
        {
            int ticketLevel = 0;

            if (TempData.ContainsKey("employee") || TempData.ContainsKey("administrator"))
            {
                if (TempData.ContainsKey("employee"))
                {
                    ticketLevel = (int)TempData["ticketLevel"];
                    //ticketLevel = (int)TempData["employee"];
                }

                if (TempData.ContainsKey("administrator"))
                {
                    ticketLevel = (int)TempData["ticketLevel"];
                    //ticketLevel = (int)TempData["administrator"];
                }
            }

            if (TempData == null)
            {
                ticketLevel = 0;
            }

            TempData.Keep("employee");
            TempData.Keep("administrator");
            TempData.Keep("ticketLevel");
            List<Ticket> ticketList = _ITicketLogic.GetTickets(ticketLevel);
            return ticketList;
        }

        public Ticket GetSpecificTicket(int ticketid)
        {
            Ticket ticket = _ITicketLogic.GetTicket(ticketid);

            return ticket;
        }

        public List<TicketViewModel> TransferTicketListToViewModel(List<Ticket> ticketList)
        {
            List<TicketViewModel> newTicketList = new();
            foreach (var tickets in ticketList)
            {
                newTicketList.Add(new TicketViewModel
                {
                    TicketId = tickets.TicketId,
                    TicketSubject = tickets.TicketSubject,
                    TicketContent = tickets.TicketContent,
                    TicketCategory = (TicketViewModel.TicketCategories)tickets.TicketCategory,
                    TicketPriority = (TicketViewModel.TicketPriorities)tickets.TicketPriority,
                    TicketStatus = (TicketViewModel.TicketStatuses)tickets.TicketStatus,
                    CreatedDateTime = tickets.CreatedDateTime,
                });
            }
            return newTicketList;
        }

        public TicketViewModel TransferTicketToViewModel(Ticket ticket)
        {
            TicketViewModel currTicket = new TicketViewModel
            {
                TicketId = ticket.TicketId,
                DeviceId = ticket.DeviceId,
                TicketSubject = ticket.TicketSubject,
                TicketContent = ticket.TicketContent,
                TicketCategory = (TicketViewModel.TicketCategories)ticket.TicketCategory,
                TicketPriority = (TicketViewModel.TicketPriorities)ticket.TicketPriority,
                TicketStatus = (TicketViewModel.TicketStatuses)ticket.TicketStatus,
                TicketLevel = (TicketViewModel.TicketLevels)ticket.TicketLevel,
                ResponsibleEmployee = ticket.ResponsibleEmployee,
                ClientId = ticket.ClientId,
                CreatedDateTime = ticket.CreatedDateTime,
                Comments = (List<Comment>)ticket.Comments,
                Employee = ticket.Employee,
                Device = ticket.Device,
                Employees = (List<Employee>)ticket.Employees,
                Client = ticket.Client
            };

            return currTicket;
        }

        public IActionResult Index()
        {
            var newTicketList = TransferTicketListToViewModel(GetTickets());
            if (newTicketList != null)
            {
                return View(newTicketList);
            }

            else
            {
                return View();
            }
        }

        //GET
        public IActionResult Create()
        {
            var deviceList = _IDeviceLogic.GetDevices();

            ViewBag.Devices = deviceList;

            return View();
        }

        //GET
        public IActionResult View(int ticketId)
        {
            if (ticketId == 0)
            {
                return NotFound();
            }

            TicketViewModel specificTicket = TransferTicketToViewModel(GetSpecificTicket(ticketId));

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
                TicketDTO ticketDto = new TicketDTO
                {
                    TicketSubject = obj.TicketSubject,
                    TicketContent = obj.TicketContent,
                    TicketCategory = (TicketDTO.TicketCategories)(int)obj.TicketCategory,
                    TicketPriority = (TicketDTO.TicketPriorities)(int)obj.TicketPriority,
                    TicketStatus = (TicketDTO.TicketStatuses)(int)obj.TicketStatus,
                    CreatedDateTime = obj.CreatedDateTime,
                    DeviceId = obj.DeviceId
                };
                var result = _ITicketLogic.AddTicket(ticketDto);

                if (result != 0)
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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateComment(CommentViewModel obj, int id)
        {
            if (ModelState.IsValid)
            {
                int TicketId = id;
                CommentDTO commentDto = new CommentDTO
                {
                    CommentContent = obj.CommentContent,
                    TicketId = TicketId,
                };
                var result = _ICommentLogic.AddComment(commentDto);

                if (result != 0)
                {
                    TempData["success"] = "Reactie succesvol toegevoegd";
                }
                else
                {
                    TempData["error"] = "Reactie niet toegevoegd";
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

            TicketViewModel specificTicket = TransferTicketToViewModel(GetSpecificTicket(ticketId));


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
                TicketDTO ticketDto = new TicketDTO
                {
                    TicketId = obj.TicketId,
                    TicketSubject = obj.TicketSubject,
                    TicketContent = obj.TicketContent,
                    TicketCategory = (TicketDTO.TicketCategories)(int)obj.TicketCategory,
                    TicketPriority = (TicketDTO.TicketPriorities)(int)obj.TicketPriority,
                    TicketStatus = (TicketDTO.TicketStatuses)(int)obj.TicketStatus,
                    TicketLevel = (TicketDTO.TicketLevels)(int)obj.TicketLevel,
                    ResponsibleEmployee = obj.ResponsibleEmployee,
                    CreatedDateTime = obj.CreatedDateTime,
                };
                var result = _ITicketLogic.UpdateTicket(ticketDto);

                if (result != 0)
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

            TicketViewModel specificTicket = TransferTicketToViewModel(GetSpecificTicket(ticketId));

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

            if (result == true)
            {
                TempData["success"] = "Ticket succesvol verwijderd";
            }
            else
            {
                TempData["error"] = "Ticket niet verwijderd";
            }
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComment(CommentViewModel obj)
        {
            var result = _ICommentLogic.DeleteComment(obj.CommentId);

            if (result == true)
            {
                TempData["success"] = "Reactie succesvol verwijderd";
            }
            else
            {
                TempData["error"] = "Reactie niet verwijderd";
            }
            return RedirectToAction("Index");
        }
    }
}
