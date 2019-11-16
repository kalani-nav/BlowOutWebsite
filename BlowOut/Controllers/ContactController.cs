using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.response = "Please call Support at<strong><u> 801-555-1212 </u></ strong >.Thank you!";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string name)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("painting.grey164@gmail.com", "Victoria");
                    var receiverEmail = new MailAddress(email, name);
                    var password = "TreeFalling1";
                    var subject = "Welcome to Blowout";
                    var body = "We appreciate you coming to our site. We hope to continue buisness with you. Have a great day!";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    ViewBag.response = "<p>Thank you " + name + ". We will send an email to " + email + " </p>";
                    return View("Email");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        [HttpGet]
        public ActionResult email(string name, string email)
        {
            ViewBag.response = "<p>Thank you " + name + ". We will send an email to " + email + " </p>";
            return View();

        }
    }
}