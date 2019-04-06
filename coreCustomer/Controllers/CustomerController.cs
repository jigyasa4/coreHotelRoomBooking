using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCustomer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace coreHotelRoomBookingUserPanel.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        coreHotelRoomBookingContext context = new coreHotelRoomBookingContext();
        [Route("index")]
        public IActionResult Index()
        {
            
            return View();
        }


        [Route("mylogin")]
        [HttpPost]
        public IActionResult MyLogin(string username, string password)
        {
            var user = context.Customers.Where(x => x.FirstName == username).SingleOrDefault();
            ViewBag.cust = user;
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.FirstName;
                int custId = ViewBag.cust.CustomerId;
              
                //var passWord = user.UserPassword;
                if (username != null && password != null && username.Equals(userName) && password.Equals("12345"))
                {
                    HttpContext.Session.SetString("uname", username);
                    HttpContext.Session.SetString("cID", custId.ToString());
                    return RedirectToAction("CheckOut", "Book", new { @id = custId });
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View("Index");
                }
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }

        [Route("create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create(Customers c1)
        {
            context.Customers.Add(c1);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [Route("edit")]
        [HttpGet]
        public ActionResult Edit()
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            var  user = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();
            return View(user);
        }


        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(Customers ht1)
        {
            int custId = int.Parse(HttpContext.Session.GetString("cID"));
            Customers user = context.Customers.Where(x => x.CustomerId == custId).SingleOrDefault();

            user.FirstName = ht1.FirstName;
            user.LastName = ht1.LastName;
            user.ContactNumber = ht1.ContactNumber;
            user.Address = ht1.Address;
            user.EmailId = ht1.EmailId;
            user.Country = ht1.Country;
            user.State = ht1.State;
            user.Zip = ht1.Zip;
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}