using LOGIC.DTO_s;
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

        public List<TicketViewModel> TransferViewAll()
        {
            List<TicketViewModel> newTicketList = new();
            //TicketViewModel viewmodel = new TicketViewModel();
            var ticketList = _ITicketLogic.GetTickets();

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

        public TicketViewModel TransferViewSpecfic(int ticketid)
        {
            List<TicketViewModel> newTicketList = new();
            List<CommentViewModel> specificCommentList = new();

            TicketViewModel viewmodel = null;
            var ticketList = _ITicketLogic.GetTicket(ticketid);
            foreach (var comments in specificCommentList)
            {
                CommentViewModel currComment = new CommentViewModel
                {
                    CommentId = comments.CommentId,
                    CommentContent = comments.CommentContent,
                };
                specificCommentList.Add(currComment);
            }
            foreach (var tickets in ticketList)
            {
                TicketViewModel currTicket = new TicketViewModel
                {
                    TicketId = tickets.TicketId,
                    TicketSubject = tickets.TicketSubject,
                    TicketContent = tickets.TicketContent,
                    TicketCategory = (TicketViewModel.TicketCategories)tickets.TicketCategory,
                    TicketPriority = (TicketViewModel.TicketPriorities)tickets.TicketPriority,
                    TicketStatus = (TicketViewModel.TicketStatuses)tickets.TicketStatus,
                    TicketLevel = (TicketViewModel.TicketLevels)tickets.TicketLevel,
                    CreatedDateTime = tickets.CreatedDateTime,
                    Comments = (List<LOGIC.Entities.Comment>)tickets.Comments,
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

        public List<DeviceViewModel> BindList() // bind list of devices to dropdown
        {
            List<DeviceViewModel> newDeviceList = new();
            DeviceViewModel viewmodel = new DeviceViewModel();
            var deviceList = _IDeviceLogic.GetDevices();

            foreach (var devices in deviceList)
            {
                newDeviceList.Add(new DeviceViewModel
                {
                    DeviceId = devices.DeviceId,
                    DeviceName = devices.DeviceName,
                });
            }
            return newDeviceList;
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
                TicketDTO ticketDto = new TicketDTO
                {
                    TicketSubject = obj.TicketSubject,
                    TicketContent = obj.TicketContent,
                    TicketCategory = (TicketDTO.TicketCategories)(int)obj.TicketCategory,
                    TicketPriority = (TicketDTO.TicketPriorities)(int)obj.TicketPriority,
                    TicketStatus = (TicketDTO.TicketStatuses)(int)obj.TicketStatus,
                    CreatedDateTime = obj.CreatedDateTime,
                };
                var result = _ITicketLogic.AddTicket(ticketDto);

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

                if (result != null)
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
                TicketDTO ticketDto = new TicketDTO
                {
                    TicketId = obj.TicketId,
                    TicketSubject = obj.TicketSubject,
                    TicketContent = obj.TicketContent,
                    TicketCategory = (TicketDTO.TicketCategories)(int)obj.TicketCategory,
                    TicketPriority = (TicketDTO.TicketPriorities)(int)obj.TicketPriority,
                    TicketStatus = (TicketDTO.TicketStatuses)(int)obj.TicketStatus,
                    TicketLevel = (TicketDTO.TicketLevels)(int)obj.TicketLevel,
                    CreatedDateTime = obj.CreatedDateTime,
                };
                var result = _ITicketLogic.UpdateTicket(ticketDto);

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
