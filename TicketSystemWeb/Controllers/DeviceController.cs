using LOGIC.DeviceLogic;
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
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly DeviceLogic deviceLogic = new();

        public DeviceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<DeviceViewModel> objDeviceList = _db.Devices;

            return View(objDeviceList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceViewModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.ClientId = 0;
                obj.TicketId = 0;
                var result = deviceLogic.CreateNewDevice((int)obj.ClientId, (int)obj.TicketId, obj.DeviceName, obj.DeviceVersion, obj.Brand, obj.OsVersion, obj.SerialNumber);
                TempData["success"] = "Apparaat succesvol toegevoegd";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult View(int? deviceId)
        {

            if (deviceId == null || deviceId == 0)
            {
                return NotFound();
            }

            var deviceFromDb = _db.Devices.Find(deviceId);

            if (deviceFromDb == null)
            {
                return NotFound();
            }

            return View(deviceFromDb);
        }
        //GET
        public IActionResult Edit(int? deviceId)
        {
            if (deviceId == null || deviceId == 0)
            {
                return NotFound();
            }

            var deviceFromDb = _db.Devices.Find(deviceId);


            if (deviceFromDb == null)
            {
                return NotFound();
            }

            return View(deviceFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Devices.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Apparaat succesvol aangepast";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //GET
        public IActionResult Delete(int? deviceId)
        {
            if (deviceId == null || deviceId == 0)
            {
                return NotFound();
            }

            var deviceFromDb = _db.Devices.Find(deviceId);

            if (deviceFromDb == null)
            {
                return NotFound();
            }
            return View(deviceFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? deviceId)
        {
            var obj = _db.Devices.Find(deviceId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Devices.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Apparaat succesvol verwijderd";
            return RedirectToAction("Index");
        }
    }
}
