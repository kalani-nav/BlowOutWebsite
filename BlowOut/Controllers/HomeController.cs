using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;


namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        private RentalsContext db = new RentalsContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            ViewBag.SelectInstrument = "Select An Instrument To Rent";
            return View(db.Instruments.ToList());
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [Bind(Include = "ClientID,FirstName,LastName,Address,City,State,Zip,Email,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client); //adds client to database 
                db.SaveChanges(); // saves database

                //lookup instument in the database by ID
                Instrument instrument = db.Instruments.Find(id);
                // just in case things get crazy
                if (instrument == null)
                {
                    return HttpNotFound();
                }
                instrument.ClientID = client.ClientID;
                //db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Summary", new { ClientID=client.ClientID, InstrumentID=instrument.InstrumentID });
            }

            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            Instrument instrument = db.Instruments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
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