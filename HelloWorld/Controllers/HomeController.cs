using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;


namespace HelloWorld.Controllers
{

    // [ExceptionHandling]
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // Exception Handling
        // What if the Exception is not in the Controller?
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    base.OnException(filterContext);
        //}

        // GET: Home
        public ActionResult Index()
        {
            try
            {
                int x = 1;  // add me
                x = x / (x - 1); // add me
            }
            catch (DivideByZeroException ex)
            {
                // ignore exception
                // log the exception to a log file
                // send an email to the developer team
            }

            return View();
        }

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
            //return View("Thanks", guestResponse);
        }

        // ==================================================
        //  Dependency Injection
        // ==================================================
        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        public ActionResult Products()
        {
            return View(productRepository.Products);
        }

        // ==================================================
        //  before Dependency Injection
        // ==================================================

        //public ActionResult Product()
        //{
        //    var myProduct = new Product
        //    {
        //        ProductId = 1,
        //        Name = "Kayak",
        //        Description = "A boat for one person",
        //        Category = "water-sports",
        //        Price = 200m,
        //    };
        //
        //    return View(myProduct);
        //}

        //public ActionResult Products()
        //{
        //    var products = new Product[]
        //    {
        //        new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount=10},
        //        new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount=45},
        //        new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount=1},
        //        new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount=0},
        //    };
        //
        //    return View(products);
        //}


    }
}