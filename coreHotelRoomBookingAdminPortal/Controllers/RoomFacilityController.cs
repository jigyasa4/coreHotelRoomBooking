using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class RoomFacilityController : Controller
    {
        HotelRoomDbContext context;
        public RoomFacilityController(HotelRoomDbContext _context)
        {
            context = _context;
        }

        //Index
        public IActionResult Index()
        {
            var roomfacility = context.RoomFacilities.ToList();
            return View(roomfacility);
        }

        //Create
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotels = new SelectList(context.HotelRooms, "RoomId", "RoomId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoomFacilityDescription")]RoomFacility hf1)
        {if (ModelState.IsValid)
            {
                context.RoomFacilities.Add(hf1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hf1);
        }

        //Details

        public ViewResult Details(int id)
        {
            RoomFacility roomfacility = context.RoomFacilities.
                Where(x => x.RoomFacilityId == id).SingleOrDefault();
            return View(roomfacility);

        }

        //Delete

            [HttpGet]
        public ViewResult Delete(int id)
        {

            RoomFacility roomfacility = context.RoomFacilities.Find(id);
            ViewBag.hotelrooms =
          new SelectList(context.HotelRooms, "RoomId", "RoomId", roomfacility.RoomId);
            return View(roomfacility);
          
        }

        [HttpPost]
        public ActionResult Delete(int id,RoomFacility R1)
        {
            var roomfacility = context.RoomFacilities.
                   Where(x => x.RoomFacilityId == id).SingleOrDefault();
            context.RoomFacilities.Remove(roomfacility);
            context.SaveChanges();
            return RedirectToAction("Index");

        
        }

        //Edit

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomFacility roomfacility = context.RoomFacilities
                .Where(x => x.RoomFacilityId == id).SingleOrDefault();
            ViewBag.hotelrooms =
         new SelectList(context.HotelRooms, "RoomId", "RoomType", roomfacility.RoomId);
            return View(roomfacility);
        }


        [HttpPost]

        public ActionResult Edit(int id,RoomFacility H1)
        {
            RoomFacility roomfacility = context.RoomFacilities
                .Where(x => x.RoomFacilityId == id).SingleOrDefault();
             roomfacility.IsAvailable = H1.IsAvailable;
            roomfacility.Wifi = H1.Wifi;
            roomfacility.AirConditioner = H1.AirConditioner;
            roomfacility.Refrigerator = H1.Refrigerator;
            roomfacility.RoomFacilityDescription = H1.RoomFacilityDescription;
            roomfacility.RoomId = H1.RoomId;
            context.SaveChanges();
            return RedirectToAction("Index");

    }   }
}
