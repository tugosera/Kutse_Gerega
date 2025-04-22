using Kutse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class HolidayController : Controller
{
    // GET: Holiday/CreateHoliday
    public ActionResult CreateHoliday()
    {
        return View();
    }

    // POST: Holiday/CreateHoliday
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateHoliday(Kutse.Models.Holiday holiday)
    {
        if (ModelState.IsValid)
        {
            // Сохраняем праздник в базу данных (пример):
            // db.Holidays.Add(holiday);
            // db.SaveChanges();

            return RedirectToAction("Holiday"); // или другой метод для отображения списка
        }

        return View(holiday);
    }
}