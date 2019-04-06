using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomer.Helpers;
using coreCustomer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreCustomer.Controllers
{

    [Route("book")]
    public class BookController : Controller
    {
        coreHotelRoomBookingContext context = new coreHotelRoomBookingContext();
        [Route("index")]
        public IActionResult Index()
        {
            var book = SessionHelper.GetObjectFromJson<List<Item>>
                    (HttpContext.Session, "Book");
               ViewBag.book = book;
            if (ViewBag.book == null)
            {
                return RedirectToAction("EmptyBooking");
            }
            else
            {
                ViewBag.total = book.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);
                ViewBag.totalitem = book.Count();
            }
            return View();
        }


        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Book") == null)
            {
                List<Item> book = new List<Item>();
                book.Add(new Item
                {
                    HotelRooms = context.HotelRooms.Find(id),
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJon(HttpContext.Session, "Book", book);

            }


            else
            {
                List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                    (HttpContext.Session, "Book");
                int index = isExit(id);
                if (index != -1)
                {
                    book[index].Quantity++;
                }

                else
                {
                    book.Add(new Item
                    {
                        HotelRooms = context.HotelRooms.Find(id),
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJon(HttpContext.Session, "Book", book);
                }

            }

            HotelRooms hotelRooms = context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelRooms;
            int hid = ViewBag.HotelRoom.HotelId;
            Hotels hotels = context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotels;
            return RedirectToAction("Details","HotelRoom",new { @id = hid });

        }

        [Route("remove/{id}")]

        public IActionResult Remove(int id)
        {
            List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            int index = isExit(id);
            book.RemoveAt(index);
            SessionHelper.SetObjectAsJon(HttpContext.Session, "Book", book);

            int count = 0;
            foreach(var item in book)
            {
                count++;
            }
            if (count != 0)
            {
                int j = int.Parse(HttpContext.Session.GetString("CartItem"));
                j--;
                HttpContext.Session.SetString("CartItem", j.ToString());
            }
            else
            {
                HttpContext.Session.Remove("CartItem");
                if (index == 0)
                {
                    return View("Empty Booking");
                }


                    
            }

            return RedirectToAction("Index");

        }

        private int isExit(int id)
        {
            List<Item> book = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "Book");
            for (int i = 0; i < book.Count; i++)
            {
                if (book[i].HotelRooms.RoomId.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        [Route("EmptyBooking")]
        public IActionResult EmptyBooking()
        {
            return View();
        }


        
          [HttpGet]
        public IActionResult CheckOut(int id)
        {
            var customers = context.Customers.Where(x => x.CustomerId == id).SingleOrDefault();
            var book = SessionHelper.GetObjectFromJson<List<Item>>
                  (HttpContext.Session, "Book");
            ViewBag.book = book;
            ViewBag.total = book.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);
            ViewBag.totalitem = book.Count();
            TempData["total"] = ViewBag.total;
            TempData["cid"] = customers.CustomerId;
            return View(customers);

        }
       

        [HttpPost]
        public IActionResult CheckOut(Customers customer)
        {

            var amount = TempData["total"];
            var cid = (TempData["cid"]).ToString();
          HttpContext.Session.SetString("cID",cid.ToString());

         
            DateTime cin = DateTime.Parse(HttpContext.Session.GetString("CheckIn"));
            DateTime cout = DateTime.Parse(HttpContext.Session.GetString("CheckOut"));
          
            Bookings bookings = new Bookings()
            {
                BookingPrice = Convert.ToSingle(amount),
                BookingDate = DateTime.Now,
                CheckIn = cin,
                CheckOut=cout,
                CustomerId = int.Parse(cid)
            };

            ViewBag.Book = bookings;
            context.Bookings.Add(bookings);
            context.SaveChanges();


            var booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Book");
            List<BookingDetails> bookingDetails = new List<BookingDetails>();
            for (int i = 0; i < booking.Count; i++)
            {
                BookingDetails bookingdetail = new BookingDetails()
                {
                    BookingId = bookings.BookingId,
                    RoomId = booking[i].HotelRooms.RoomId,
                    Qunatity = booking[i].Quantity
                };
                bookingDetails.Add(bookingdetail);

            }

            bookingDetails.ForEach(n => context.BookingDetails.Add(n));
            context.SaveChanges();
            TempData["cust"] = cid;
            ViewBag.booking = null;
            return RedirectToAction("Invoice");

        }


        [Route("invoice")]
        [HttpGet]
        public IActionResult Invoice()
        {
            int custId = int.Parse(TempData["cust"].ToString());
            Customers customers = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            ViewBag.Customers = customers;

            var booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Book");
            ViewBag.book = booking;
            booking = null;
            SessionHelper.SetObjectAsJon(HttpContext.Session, "Book", booking);
            HttpContext.Session.Remove("CartItem");
            //ViewBag.total = booking.Sum(item => item.HotelRooms.RoomPrice * item.Quantity);

            return View();
        }

        [Route("order")]
        [HttpGet]
        public IActionResult OrderHistory()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            var booking = context.Bookings.Where(x => x.CustomerId == custId).ToList();
            ViewBag.bkng = booking;
            return View();

        }


        [Route("historydetails")]
        [HttpGet]
        public IActionResult History(int id)
        {
            var book = context.BookingDetails.Where(x => x.BookingId == id).ToList();
            ViewBag.HistoryDetails = book;
            List<HotelRooms> hotelroom = new List<HotelRooms>();


            foreach (var item in ViewBag.HistoryDetails)
            {
                int idd = Convert.ToInt32(item.RoomId);
                HotelRooms hr = context.HotelRooms.Where(x => x.RoomId == idd).SingleOrDefault();
                hotelroom.Add(hr);
            }
            ViewBag.HotelRoom = hotelroom;

            return View();
        }
    }

}