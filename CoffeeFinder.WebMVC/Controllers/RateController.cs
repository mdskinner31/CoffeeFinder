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

            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateRateService();

            if (service.CreateRate(model))
            {
                TempData["SaveResult"] = "Your rate was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Rate could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRateService();
            var model = svc.GetRateById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRateService();
            var detail = service.GetRateById(id);
            var model =
                new RateEdit
                {
                    Id = detail.Id,
                    CoffeeShopId = detail.CoffeeShopId,
                    
                    CustomerService = detail.CustomerService,
                    CoffeeSelection = detail.CoffeeSelection,
                    Cleanliness = detail.Cleanliness,
                    AvailableAmenities = detail.AvailableAmenities
        };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRateService();

            if (service.UpdateRate(model))
            {
                TempData["SaveResult"] = "Your Rate was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Rate could not be updated.");
            return View();
        }



        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
           var svc = CreateRateService();
            var model = svc.GetRateById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRateService();

            service.DeleteRate(id);

            TempData["SaveResult"] = "Your ratings have been deleted.";

            return RedirectToAction("Index");
        }

        private RateService CreateRateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RateService(userId);
            return service;
        }
    }
}
