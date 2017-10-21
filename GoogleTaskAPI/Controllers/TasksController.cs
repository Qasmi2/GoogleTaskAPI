using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace GoogleTaskAPI.Controllers
{   
    public class TasksController : Controller
    {
        //
        // GET: /Tasks/
        public ActionResult Index()
        {
            return View();
        }
	}
}