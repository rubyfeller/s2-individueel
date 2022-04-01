using LOGIC.DeviceLogic;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TicketSystemWeb.Models;

namespace TicketSystemWeb.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceLogic _IDeviceLogic;

        public DeviceController(IDeviceLogic DeviceLogic)
        {
            _IDeviceLogic = DeviceLogic;
        }

        public List<DeviceViewModel> TransferViewAll()
        {
            List<DeviceViewModel> newDeviceList = new();
            DeviceViewModel viewmodel = new DeviceViewModel();
            var deviceList = _IDeviceLogic.GetDevices();

            foreach (var devices in deviceList)
            {
                newDeviceList.Add(new DeviceViewModel
                {
                    DeviceId = devices.DeviceId,
                    ClientId = devices.ClientId,
                    TicketId = devices.TicketId,
                    DeviceName = devices.DeviceName,
                    DeviceVersion = devices.DeviceVersion,
                    Brand = devices.Brand,
                    OsVersion = devices.OsVersion,
                    SerialNumber = devices.SerialNumber,

                });
            }
            return newDeviceList;
        }

        public DeviceViewModel TransferViewSpecfic(int deviceid)
        {
            List<DeviceViewModel> newDeviceList = new();
            DeviceViewModel viewmodel = null;
            var deviceList = _IDeviceLogic.GetDevice(deviceid);

            foreach (var devices in deviceList)
            {
                DeviceViewModel currDevice = new DeviceViewModel
                {
                    DeviceId = devices.DeviceId,
                    ClientId = devices.ClientId,
                    TicketId = devices.TicketId,
                    DeviceName = devices.DeviceName,
                    DeviceVersion = devices.DeviceVersion,
                    Brand = devices.Brand,
                    OsVersion = devices.OsVersion,
                    SerialNumber = devices.SerialNumber,
                };
                newDeviceList.Add(currDevice);
                viewmodel = currDevice;
            }
            return viewmodel;
        }

        public IActionResult Index()
        {
            var newDeviceList = TransferViewAll();
            return View(newDeviceList);
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
                var result = _IDeviceLogic.AddDevice((int)obj.ClientId, (int)obj.TicketId, obj.DeviceName, obj.DeviceVersion, obj.Brand, obj.OsVersion, obj.SerialNumber);

                if (result != null)
                {
                    TempData["success"] = "Apparaat succesvol toegevoegd";
                }
                else
                {
                    TempData["error"] = "Apparaat niet toegevoegd";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult View(int deviceId)
        {

            if (deviceId == 0)
            {
                return NotFound();
            }

            var specificDevice = TransferViewSpecfic(deviceId);

            if (specificDevice == null)
            {
                return NotFound();
            }
            else
            {
                return View(specificDevice);
            }
        }

        //GET
        public IActionResult Edit(int deviceId)
        {
            if (deviceId == 0)
            {
                return NotFound();
            }

            var specificDevice = TransferViewSpecfic(deviceId);


            if (specificDevice == null)
            {
                return NotFound();
            }
            else
            {
                return View(specificDevice);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeviceViewModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.ClientId = 0;
                obj.TicketId = 0;
                var result = _IDeviceLogic.UpdateDevice(obj.DeviceId, (int)obj.ClientId, (int)obj.TicketId, obj.DeviceName, obj.DeviceVersion, obj.Brand, obj.OsVersion, obj.SerialNumber);

                if (result != null)
                {
                    TempData["success"] = "Apparaat succesvol aangepast";
                }
                else
                {
                    TempData["error"] = "Apparaat niet aangepast";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int deviceId)
        {
            if (deviceId == 0)
            {
                return NotFound();
            }

            var specificDevice = TransferViewSpecfic(deviceId);

            if (specificDevice == null)
            {
                return NotFound();
            }

            return View(specificDevice);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(DeviceViewModel obj)
        {
            var result = _IDeviceLogic.DeleteDevice(obj.DeviceId);

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
