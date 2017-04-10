using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayCard.Models;

namespace BirthdayCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public string Index()
        //{
        //    return "Hello World";
        //}

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendCardForm()
        {
            var myBirthdayMessage = new BirthdayMessage
            {
                BirthdayMessageId = 1,
                To = "George@test.com",
                From = "Katherine@test.com",
                MessageBody = "Hippy Birthday!"
            };
            return View(myBirthdayMessage);
        }

        [HttpPost]
        public ActionResult SendCardForm(Models.BirthdayMessage bdayResponse)
        {
            if (ModelState.IsValid)
            {
                return View("BirthdayCardView", bdayResponse);
            }
            else
            {
                return View();
            }
        }

    }
}