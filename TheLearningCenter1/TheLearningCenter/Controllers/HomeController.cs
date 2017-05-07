using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLearningCenter.Business;
using TheLearningCenter.Models;


namespace TheLearningCenter.Controllers
{
    [Logging]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IClassMasterManager classMasterManager;
        private readonly IUserClassManager userClassManager;

        public HomeController(IClassMasterManager classMasterManager,
                              IUserClassManager userClassManager)
        {
            this.classMasterManager = classMasterManager;
            this.userClassManager = userClassManager;
        }
        public ActionResult Index()
        {
            // temporary test of Global Exception Handling
            // int x = 1;       // add me
            // x = x / (x - 1); // add me

            return View();   // Home page
        }

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public double Price { get; set; }
        //public int Sessions { get; set; }


        public ActionResult ClassList()
        {

            var classes = classMasterManager.ClassMasters
                .Select(t => new TheLearningCenter.Models.ClassMasterModel( t.Id,
                     t.Name,
                     t.Description,
                     t.Price,
                     t.Sessions ))
               .ToArray();

            var classMasterViewModel = new TheLearningCenter.Models.ClassMasterViewModel 
            {
                ClassMasters = classes
            };

           return View(classMasterViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult StudentClasses()
        {
            //  ... Session["User"] not implemented yet
            var user = (TheLearningCenter.Models.UserModel)Session["User"];

            //int userId = 1;

            //var userClasses = userClassManager.GetAll(userId)
            //             .Select(t => new TheLearningCenter.Models.UserClassModel(
            //                  t.UserId,
            //                  t.ClassId
            //                  ))
            //            .ToArray();
            //
            // return View(userClasses);


            var studentClasses = userClassManager.GetAll(user.Id)
                          .Select(t => new TheLearningCenter.Models.StudentClassesViewModel(
                               t.UserId,
                               t.ClassId,
                               t.ClassName,
                               t.ClassDescription,
                               t.ClassPrice
                               ))
                         .ToArray();

            return View(studentClasses);
        }

        [HttpGet]
        public ActionResult EnrollInClass()
        {

            // get all the classes to populate the drop down in the form
            var classes = classMasterManager.ClassMasters
                             .Select(t => new TheLearningCenter.Models.ClassMasterModel(t.Id,
                                  t.Name,
                                  t.Description,
                                  t.Price,
                                  t.Sessions))
                            .ToArray();

            // get Session["User"] 
            var user = (TheLearningCenter.Models.UserModel)Session["User"];

            EnrollInClassViewModel enrollInClassModelData = new EnrollInClassViewModel
            {
                ClassMasters = classes,
                UserId = user.Id
            };

            return View(enrollInClassModelData);
        }

        [HttpPost]
        public ActionResult EnrollInClass(Models.EnrollInClassViewModel enrollInClassData)
        {
            if (ModelState.IsValid)
            {
                // insert new row into the database 
                var user = (TheLearningCenter.Models.UserModel)Session["User"];

                var userClass = userClassManager.Add(user.Id, enrollInClassData.ClassId);

                // NOTE:  userClass may be null if the User is already enrolled ??


                //  the below is done in StudentClasses
                //var userClasses = userClassManager.GetAll(enrollInClassData.UserId)
                //    .Select(t => new TheLearningCenter.Models.UserClassModel(t.UserId, t.ClassId))
                //    .ToArray();

                //  Redirect 
                //  Dan Instructor comments
                //  Post should almost always to a Redirect or RedirectToAction.
                //  Because after they add the record 
                //  ...you should show them that the record was added 
                //  ...and then move to the home page or someplace where they can continue working.
                return RedirectToAction("StudentClasses");
            }
            else
            {
                // enrollInClassData  is missing the list of classes at this point !

                // get all the classes to populate the drop down in the form
                var classes = classMasterManager.ClassMasters
                                 .Select(t => new TheLearningCenter.Models.ClassMasterModel(t.Id,
                                      t.Name,
                                      t.Description,
                                      t.Price,
                                      t.Sessions))
                                .ToArray();

                enrollInClassData.ClassMasters = classes;

                return View(enrollInClassData);
            }
 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}