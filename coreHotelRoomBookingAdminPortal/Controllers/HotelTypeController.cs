using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreHotelRoomBookingAdminPortal.Controllers
{
    public class HotelTypeController : Controller
    {
        HotelRoomDbContext context;

        public HotelTypeController(HotelRoomDbContext _context)
        {
            context = _context;
        }

        //public HotelTypeController()
        //{

        //}

      

        public IActionResult Index()
        {
            var hoteltype= context.HotelTypes.ToList();
            return View(hoteltype);
        }

        //CREATE
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("HotelTypeName","HotelTypeDescription")]HotelType H1)

        {if (ModelState.IsValid)
            {
                context.HotelTypes.Add(H1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(H1);
        }


        //DETAILS
        public IActionResult Details(int id)
        {
            HotelType hoteltype = context.HotelTypes.
                Where(x => x.HotelTypeId == id).SingleOrDefault();
            return View(hoteltype);

        }

        //DELETE

        [HttpGet]
        public ActionResult Delete(int id)
        {
            HotelType hoteltype = context.HotelTypes.Find(id);
            return View(hoteltype);
        }
        [HttpPost]
        public ActionResult Delete(int id, HotelType ht1)
        {
            var hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            context.HotelTypes.Remove(hoteltype);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HotelType hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == id).SingleOrDefault();
            return View(hoteltype);
        }
        [HttpPost]
        public ActionResult Edit(HotelType ht1)
        {
            HotelType hoteltype = context.HotelTypes.Where(x => x.HotelTypeId == ht1.HotelTypeId).SingleOrDefault();
            hoteltype.HotelTypeId = ht1.HotelTypeId;
            hoteltype.HotelTypeName = ht1.HotelTypeName;
            hoteltype.HotelTypeDescription = ht1.HotelTypeDescription;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}



    





  