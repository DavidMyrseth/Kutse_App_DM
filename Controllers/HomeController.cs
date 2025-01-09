using Kutse_App_DM.Models;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App_DM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust!" : "Tere päevast!";
            return View();
        }
        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]

        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest); // функция для отправки письма с ответами
            if (ModelState.IsValid)
            { return View("Thanks", guest); }
            else
            { return View(); }
        }
        public void E_mail(Guest guest) 
        { 
            try
            {
                WebMail.SmtpServer = "stmp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "david.mirsetSSS@gmail.com";
                WebMail.Password = "";
                WebMail.From = "david.mirsetSSS@gmail.com";
                WebMail.Send = "marina.oleinik@tthk.ee", "Vastus kutsele",guest.Name + "vastas" + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
            }
        }
    }
}