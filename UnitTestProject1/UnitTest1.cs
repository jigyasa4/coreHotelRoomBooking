using coreHotelRoomBookingAdminPortal.Controllers;
using coreHotelRoomBookingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       static HotelTypeController controller;


        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
          //controller = new HotelTypeController();
           context.WriteLine("HotelTypeController Instance Created");

        }

       [TestMethod]
       [TestCategory("HotelType")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestForIndexAction()
        {
            //Act
            ViewResult result = (ViewResult)controller.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ViewResult));
         


        }




        [TestMethod]
        [TestCategory("HotelType")]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(11)]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestForDetailsAction(int Id)
        {//Act
            IActionResult result = controller.Details(Id);
            ViewResult view = (ViewResult)result;

            //Arrange
          
            Assert.IsInstanceOfType(result,typeof(HotelType));
        }


       

    }
}
