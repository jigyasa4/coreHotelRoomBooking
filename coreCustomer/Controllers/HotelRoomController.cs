using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomer.Helpers;
using coreCustomer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreCustomer.Controllers
{
    public class HotelRoomController : Controller
    {
        coreHotelRoomBookingContext context = new coreHotelRoomBookingContext();
        public IActionResult Index()
        {
            var hotelRoom = context.HotelRooms.ToList();
            return View(hotelRoom);

        }
        public ViewResult Details(int id)
        {
            var hotelroom = context.HotelRooms.Where(x => x.HotelId == id).ToList();
            return View(hotelroom);
        }


        public ViewResult Details1(int id)
        {
            HotelRooms hotelroom = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelroom;

            int hid = ViewBag.HotelRoom.HotelId;
            Hotels hotels = context.Hotels.Where(x => x.HotelId == hid).SingleOrDefault();
            ViewBag.Hotel = hotels;
            RoomFacilities roomFacilities = context.RoomFacilities.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.RoomFacility = roomFacilities;
            return View();
        }
    }
}