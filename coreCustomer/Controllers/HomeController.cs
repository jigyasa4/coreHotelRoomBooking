using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreCustomer.Models;
using coreCustomer.Helpers;
using Microsoft.AspNetCore.Http;

namespace coreCustomer.Controllers
{
    public class HomeController : Controller
    {
        coreHotelRoomBookingContext context = new coreHotelRoomBookingContext();
        public IActionResult Index()
        {
            var hotel = context.Hotels.ToList();
          /*  List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            int count = 0;
            if (book != null)
            {
                foreach(var item in book)
                {
                    count++;

                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
            }*/
            return View(hotel);
        }
        public ViewResult Details(int id)
        {
            Hotels hotel = context.Hotels.
                Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotel;
            return View();

        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string search,string checkIn,string checkOut)
        {
            HttpContext.Session.SetString("Search", search.ToString());
            HttpContext.Session.SetString("CheckIn", checkIn.ToString());
            HttpContext.Session.SetString("CheckOut", checkOut.ToString());
            ViewBag.Hotel = context.Hotels.Where(x => x.HotelName == search || x.HotelCity == search || x.HotelState == search || search == null).ToList();
            return View(context.Hotels.Where(x => x.HotelName == search || search == null).ToList());
        }






    }
}
