using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TicketSystemWeb.Data;
using TicketSystemWeb.Models;

namespace TicketSystemWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Ticket> objTicketList = _db.Tickets;

            return View(objTicketList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //GET
        public IActionResult View(int? ticketId)
        {

            if (ticketId == null || ticketId == 0)
            {
                return NotFound();
            }

            var ticketFromDb = _db.Tickets.Find(ticketId);

            if (ticketFromDb == null)
            {
                return NotFound();
            }
            List<string> ticketStatusList = new List<string>
            {
                "Open",
                "In behandeling",
                "Gesloten"
            };

            ViewBag.ticketStatusList = ticketStatusList;
            return View(ticketFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Ticket succesvol aangemaakt";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? ticketId)
        {
            if (ticketId == null || ticketId == 0)
            {
                return NotFound();
            }

            var ticketFromDb = _db.Tickets.Find(ticketId);


            if (ticketFromDb == null)
            {
                return NotFound();
            }
            List<string> ticketStatusList = new List<string>
            {
                "Open",
                "In behandeling",
                "Gesloten"
            };

            ViewBag.ticketStatusList = ticketStatusList;
            return View(ticketFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Ticket succesvol aangepast";
                return RedirectToAction("Index");
            }
            List<string> ticketStatusList = new List<string>
            {
                "Open",
                "In behandeling",
                "Gesloten"
            };

            ViewBag.ticketStatusList = ticketStatusList;
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? ticketId)
        {
            if (ticketId == null || ticketId == 0)
            {
                return NotFound();
            }

            var ticketFromDb = _db.Tickets.Find(ticketId);

            if (ticketFromDb == null)
            {
                return NotFound();
            }
            return View(ticketFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? ticketId)
        {
            var obj = _db.Tickets.Find(ticketId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Tickets.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Ticket succesvol verwijderd";
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReply(int ticketId, Ticket obj)
        {
            obj.replyId = ticketId;
            obj.ticketId = 309;

            obj.ticketSubject = "Reactie op ticket";

            _db.Tickets.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Reactie succesvol geplaatst";

            return RedirectToAction("Index");

        }

        //    //POST
        //    public IActionResult ReplyPOST(int? ticketId, Ticket obj)
        //    {
        //        _db.Add(obj);
        //        obj.ticketContent = "test IDE";
        //        obj.replyId = (int)ticketId;
        //        _db.SaveChanges();

        //        TempData["success"] = "Reactie succesvol geplaatst";
        //        return RedirectToAction("Index");

    }
}