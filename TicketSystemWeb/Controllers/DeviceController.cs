using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public List<Device> GetDevices()
        {
            return _IDeviceLogic.GetDevices();
        }

        public Device GetDevice(int deviceid)
        {
            return _IDeviceLogic.GetDevice(deviceid);
        }

        public List<DeviceViewModel> TransferViewAll(List<Device> deviceList)
        {
            List<DeviceViewModel> newDeviceList = new();

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

        public DeviceViewModel TransferViewSpecific(Device device)
        {
            DeviceViewModel specificDevice = new DeviceViewModel
            {
                DeviceId = device.DeviceId,
                ClientId = 0,
                TicketId = 0,
                DeviceName = device.DeviceName,
                DeviceVersion = device.DeviceVersion,
                Brand = device.Brand,
                OsVersion = device.OsVersion,
                SerialNumber = device.SerialNumber,
            };

            return specificDevice;
        }


        public IActionResult Index()
        {
            List<DeviceViewModel> deviceList = TransferViewAll(GetDevices());
            return View(deviceList);
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
                DeviceDTO deviceDto = new DeviceDTO
                {
                    DeviceId = obj.DeviceId,
                    ClientId = obj.ClientId,
                    TicketId = obj.TicketId,
                    DeviceName = obj.DeviceName,
                    DeviceVersion = obj.DeviceVersion,
                    Brand = obj.Brand,
                    OsVersion = obj.OsVersion,
                    SerialNumber = obj.SerialNumber,
                };
                var result = _IDeviceLogic.AddDevice(deviceDto);

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

            DeviceViewModel specificDevice = TransferViewSpecific(GetDevice(deviceId));

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

            DeviceViewModel specificDevice = TransferViewSpecific(GetDevice(deviceId));


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
                DeviceDTO deviceDto = new DeviceDTO
                {
                    DeviceId = obj.DeviceId,
                    ClientId = obj.ClientId,
                    TicketId = obj.TicketId,
                    DeviceName = obj.DeviceName,
                    DeviceVersion = obj.DeviceVersion,
                    Brand = obj.Brand,
                    OsVersion = obj.OsVersion,
                    SerialNumber = obj.SerialNumber,
                };
                var result = _IDeviceLogic.UpdateDevice(deviceDto);

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

            DeviceViewModel specificDevice = TransferViewSpecific(GetDevice(deviceId));

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

            if (result == true)
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
