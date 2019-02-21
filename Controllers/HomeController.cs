using PersonalSiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
        public ActionResult Resume()
        {
            ViewBag.Title = "R&eacute;sum&eacute";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            //Create a body for the email
            string body = string.Format("Name: {0}<br/>Email: {1}" +
                "<br/>Subject: {2}<br/>Message:<br/>{3}",
                contact.Name,
                contact.Email,
                contact.Subject,
                contact.Message);
            //Create and configure the Mail message
            MailMessage msg = new MailMessage(
                "no-reply@andrewkpearson.com", //this must be from your hosting account
                "the1aperson@gmail.com",//TO email address you want it sent 
                contact.Subject, //Subject for email header
                body
                );
            //Configure the Mail message object
            msg.IsBodyHtml = true;
            msg.CC.Add("the1aperson@gmail.com");//simply adds a carbon copy
            //Create and Configure the SMTP Client
            SmtpClient client = new SmtpClient("mail.andrewkpearson.com");//mail.yourdomain.com
            client.Credentials = new NetworkCredential("no-reply@andrewkpearson.com", "Scooter90!");
            //Send Message
            using (client)
            {
                try
                {
                    client.Send(msg);
                }
                catch
                {
                    ViewBag.ErrorMessage = "There was an error sending your email.  Please try again.";
                    return View();
                }
            }
            //Send them to the Contact Confirmation View
            //we haven't created this yet
            //TODO Create Contact Confirmation View and pass them through here
            return View("ContactConfirmation", contact);
        }
        public ActionResult Projects()
        {
            ViewBag.Title = "Projects";
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        }//end class
            
    }//end nm
