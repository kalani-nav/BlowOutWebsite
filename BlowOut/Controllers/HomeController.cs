using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            ViewBag.SelectInstrument = "Select An Instrument To Rent";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //------------------------------------------------------------

        //INSTRUMENT METHODS

        public ActionResult Trumpet()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Trombone()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Tuba()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Flute()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Clarinet()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Saxophone()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}