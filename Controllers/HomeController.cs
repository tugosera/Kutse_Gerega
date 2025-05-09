﻿using Kutse_App.Models;
using kutse_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Kutse.Models;

namespace kutse_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            int month = DateTime.Now.Month;
            
            switch (month)
            {
                case 1:
                    ViewBag.Holiday = "Hea uut aastat!";
                    break;
                default:
                    ViewBag.Holiday = "";
                    break;

            }
            ViewBag.Message = "Palun tule! Ootan sind minu poele!";
            ViewBag.PicturePath = hour < 10 ? "../Images/hommikust_zxccat.png" : (hour < 17 ? "../Images/den_zxccat.png" : (hour < 21 ? "../Images/vecher_zxccat.png" : "../Images/noch_zxccat.png")); 
            ViewBag.Greeting = hour < 10 ? "Hommikust!" : (hour < 17 ? "Päevast!" : (hour < 21 ? "Õhtust!" : "Head ööd!"));
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
            E_Mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        public void E_Mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "tarikpikarik@gmail.com";
                WebMail.Password = "jwvq nlic uouq fxzx";
                WebMail.From = "tarikpikarik@gmail.com";
                WebMail.Send(guest.Email, "Vastus kutsele", guest.Name + " Vastus " + ((guest.WillAttend ?? false) ?
                    "tuleb poele " : "ei tule poele"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception;
            }
        }

        GuestContext db = new GuestContext();
        [Authorize]
        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }

        HolidayContext DB = new HolidayContext();
        [Authorize]
        public ActionResult Holiday()
        {
            IEnumerable<Holiday> holidays = DB.Holidays;
            return View(holidays);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);  
            db.SaveChanges();
            return RedirectToAction("Guests");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }
        public ActionResult CreateHoliday()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHoliday(Kutse.Models.Holiday holiday)
        {
            if (ModelState.IsValid)
            {
                DB.Holidays.Add(holiday);      // Добавление в базу
                DB.SaveChanges();              // Сохранение изменений
                return RedirectToAction("Holiday"); // ✅ Исправлено: переход к списку праздников
            }

            return View(holiday); // Если данные невалидны, остаёмся на форме
        }
    }
}