using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    public class PromocodesController : Controller
    {
        // GET: PromocodesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PromocodesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PromocodesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PromocodesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PromocodesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PromocodesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PromocodesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PromocodesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
