using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }


        // GET: /HelloWorld/Welcome/
        public String Welcome(String name,int id)
        {
            return "Xin chao " +name+ " co ID = "+id;
        }


        // GET: /HelloWorld/Ahihi/
        public String Ahihi()
        {
            return "Ahihi action was called by name";
        }

        // GET: /HelloWorld/Ahihi/
        public String Test(String name)
        {
            return "Ahihih name = " + name;
        }
    }
}