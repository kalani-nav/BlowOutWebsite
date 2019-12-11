using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class UpdateDataController : Controller
    {
        private RentalsContext db = new RentalsContext();
        public static List<ClientInstuments> ClientInstuments = new List<ClientInstuments>();
        // GET: UpdateData
        [Authorize]
        public ActionResult Index()
        {
            ClientInstuments.Clear();
            foreach (Instrument instrument in db.Instruments)
            {
                ClientInstuments newClientInst = new ClientInstuments();
                newClientInst.instruments = instrument;
                //checking to see if client id = 0 because if it is then the client is null and should not be assigned
                if (instrument.ClientID != 0)
                {
                    newClientInst.clients = db.Clients.Find(instrument.ClientID);
                }
                ClientInstuments.Add(newClientInst);
            }
            return View(ClientInstuments.ToList());
        }
        // GET: Clients/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // GET: Clients/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ClientID,FirstName,LastName,Address,City,State,Zip,Email,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }
        // GET: Clients/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, int? InsID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id, int? InsID)
        {
            Instrument instrument = db.Instruments.FirstOrDefault(i => i.InstrumentID == InsID);
            if (instrument == null) return HttpNotFound();
            instrument.ClientID = 0; // Only OrderID is Updated because client was deleted
            db.SaveChanges();

            //// actually deleting the client
            //Client client = db.Clients.Find(id);
            //db.Clients.Remove(client);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}