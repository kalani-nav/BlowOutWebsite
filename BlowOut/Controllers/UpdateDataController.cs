using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class UpdateDataController : Controller
    {
        private RentalsContext db = new RentalsContext();
        public static List<ClientInstuments> ClientInstuments = new List<ClientInstuments>();
        // GET: UpdateData
        public ActionResult Index()
        {
            foreach (Instrument instrument in db.Instruments)
            {
                ClientInstuments newClientInst = new ClientInstuments();
                newClientInst.instruments = instrument;
                newClientInst.clients = db.Clients.Find(instrument.ClientID);
                ClientInstuments.Add(newClientInst);
            }
            return View(ClientInstuments);
        }
    }
}