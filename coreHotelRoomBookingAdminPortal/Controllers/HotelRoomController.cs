using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelRoomController : Controller
    {
        HotelRoomDbContext context;
        public HotelRoomController(HotelRoomDbContext _context)
        {
            context = _context;
        }

        //Index
        public IActionResult Index()
        {
            var hotelrooms = context.HotelRooms.ToList();
            return View(hotelrooms);
        }

        //CREATE
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.hotelrooms = new SelectList(context.Hotels, "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("RoomType", "RoomPrice", "RoomDescription", "RoomImage")]HotelRoom H1)
        {
            if (ModelState.IsValid)
            {
                context.HotelRooms.Add(H1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(H1);

        }

        //DETAILS
        public ViewResult Details(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.
                Where(x => x.RoomId == id).SingleOrDefault();
            return View(hotelroom);

        }

        //DELETE

        [HttpGet]
        public ViewResult Delete(int id)
        {
            HotelRoom hotelroom = context.HotelRooms.Find(id);
            ViewBag.hotelrooms =
          new SelectList(context.Hotels, "HotelId", "HotelName", hotelroom.HotelId);
            return View(hotelroom);
        }

        [HttpPost]
        public ActionResult Delete(int id, HotelRoom H1)
        {
            var hotelroom = context.HotelRooms.
                Where(x => x.RoomId == id).SingleOrDefault();
            context.HotelRooms.Remove(hotelroom);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HotelRoom hotelroom = context.HotelRooms
                .Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.hotelrooms =
                new SelectList(context.Hotels, "HotelId", "HotelName", hotelroom.HotelId);
            return View(hotelroom);
        }


        [HttpPost]
        public ActionResult Edit(int id,HotelRoom H1)
        {
            HotelRoom hotelroom = context.HotelRooms
                .Where(x => x.RoomId == id).SingleOrDefault();
            hotelroom.RoomType = H1.RoomType;
            hotelroom.RoomPrice = H1.RoomPrice;
            hotelroom.RoomDescription = H1.RoomDescription;
            hotelroom.RoomImage = H1.RoomImage;
            hotelroom.HotelId = H1.HotelId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}