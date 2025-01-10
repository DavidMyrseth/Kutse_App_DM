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
            var currentHour = DateTime.Now.Hour;
            if (currentHour >= 5 && currentHour < 12)
            {
                ViewBag.Greeting = "Tere hommikust"; // Доброе утро
            }
            else if (currentHour >= 12 && currentHour < 17)
            {
                ViewBag.Greeting = "Tere päevast"; // Добрый день
            }
            else if (currentHour >= 17 && currentHour < 21)
            {
                ViewBag.Greeting = "Tere õhtust"; // Добрый вечер
            }
            else
            {
                ViewBag.Greeting = "Tere öösel"; // Доброй ночи
            }

            // Определение сообщения и картинки по месяцу
            var currentMonth = DateTime.Now.Month;
            switch (currentMonth)
            {
                case 1:
                    ViewBag.Message = "Head uut aastat!";
                    ViewBag.Image = "../Images/NewYear.jpg";
                    break;
                case 2:
                    ViewBag.Message = "Sõbrapäev on käes!";
                    ViewBag.Image = "../Images/Valentine.jpg";
                    break;
                case 3:
                    ViewBag.Message = "Kevad on tulemas!";
                    ViewBag.Image = "../Images/Spring.jpg";
                    break;
                case 12:
                    ViewBag.Message = "Häid jõule!";
                    ViewBag.Image = "../Images/Christmas.jpg";
                    break;
                default:
                    ViewBag.Message = "Ootame sind suure rõõmuga!";
                    ViewBag.Image = "../Images/Default.jpg";
                    break;
            }
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
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "david.mirsetSSS@gmail.com";
                WebMail.Password = "hclw huou slbk enkc";
                WebMail.From = "david.mirsetSSS@gmail.com";
                WebMail.Send("marina.oleinik@tthk.ee", "Vastus kutsele ", guest.Name + "vastas" + ((guest.WillAttend ?? false) ? " tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!"; // marina.oleinik@tthk.ee

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!" + ex.Message;
            }
        }
        public ActionResult Undux()
        {    
            return View();
        }
    }
}