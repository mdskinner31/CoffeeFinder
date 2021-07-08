using CoffeeFinder.Data;
using CoffeeFinder.Models;
using CoffeeFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeFinder.WebMVC.Controllers
{
    public class RateController : Controller
    {
        // GET: Rate
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RateService(userId);
            var model = service.GetRates();
            return View(model);
        }

        public ActionResult Create()
        {
            //ViewBag.Title = "New Rating";

            //List<CoffeeShop> CoffeeShops = (new CoffeeShopService()).GetCoffeeShops().ToList();
            //CoffeeShops.Select(c => new SelectListItem() { });
            //var query = from c in CoffeeShops
            //            select new SelectListItem()
            //            {
            //                Value = c.Id.ToString(),
            //                Text = c.Name
            //            };
            //ViewBag.CoffeeShopId = query.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateRateService();

            if (service.CreateRate(model))
            {
                TempData["SaveResult"] = "Your rate was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Rate could not be created.");

            return View(model);
        }

        //public ActionResult Details(int id)
        //{
        //    var svc = CreateRateService();
        //    var model = svc.GetRateById(id);

        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = CreateRateService();
        //    var detail = service.GetRateById(id);
        //    var model =
        //        new RateEdit
        //        {
        //            CoffeeShopId = detail.CoffeeShopId,
        //            Name = detail.Name
        //            Content = detail.Content
        //        };
        //    return View(model);
        //}

        private RateService CreateRateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RateService(userId);
            return service;
        }
    }
}
