using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class ProfessionsController : Controller
    {
        // GET: Professions
        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Tutorials()
        {
            return View();
        }

        public ActionResult Youtube()
        {
            return View();
        }
    }
}