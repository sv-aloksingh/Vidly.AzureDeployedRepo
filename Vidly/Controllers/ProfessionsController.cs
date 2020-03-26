using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class ProfessionsController : Controller
    {
        ApplicationDbContext _context;

        public ProfessionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Professions
        public ActionResult Courses()
        {
            return View("Courses");
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