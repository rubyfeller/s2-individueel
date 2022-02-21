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
                return RedirectToAction();
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
    }
}

