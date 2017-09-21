using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class UserController : Controller
    {
        IList<Models.User> userList = new List<Models.User>() {
                        new Models.User(){ ID=1, name="Steve" },
                        new Models.User(){ ID=2, name="Bill" },
                        new Models.User(){ ID=3, name="Ram" },
                        new Models.User(){ ID=4, name="Ron" },
                        new Models.User(){ ID=5, name="Rob"}
                    };
        
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListUser()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.UserHandler sdb = new Models.UserHandler();
                    List<Models.User> list = sdb.GetUser();
                    ViewData["users"] = list;
                    ModelState.Clear();
                }
            }
            catch
            {
                return View();
            }

            return View("ListUser");
        }

        // Create new User, Show View
        public ActionResult CreateNewUser()
        {

            return View("CreateNewUser");
        }

        // Create new User, Add to database
        [HttpPost]
        public ActionResult CreateNewUser(Models.User user)
        {
            try
            {
                //if (string.IsNullOrEmpty(user.ID))
                //{
                //    ModelState.AddModelError("ID", "ID is require");
                //}

                if (string.IsNullOrEmpty(user.name))
                {
                    ModelState.AddModelError("name", "Name is require");
                }

                if (ModelState.IsValid)
                {
                    Models.UserHandler sdb = new Models.UserHandler();
                    if (sdb.AddUser(user))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }

                    return RedirectToAction("ListUser");
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

    }
}