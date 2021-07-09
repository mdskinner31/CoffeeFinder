using CoffeeFinder.Data;
using CoffeeFinder.Models;
using CoffeeFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CoffeeFinder.WebMVC.Controllers
{
    [Authorize]
    public class CoffeeShopController : Controller
    {
        
        //private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: CoffeeShop
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CoffeeShopService(userId);
           
            var model = service.GetCoffeeShops();
            
            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoffeeShopCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateCoffeeShopServices();

            if (service.CreateCoffeeShop(model))
            {
                TempData["SaveResult"] = "Your Coffee Shop was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Coffee Shop could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCoffeeShopServices();
            var model = svc.GetCoffeeShopById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCoffeeShopServices();
            var detail = service.GetCoffeeShopById(id);
            var model =
                new CoffeeShopEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    Phone = detail.Phone,
                    Website = detail.Website,
                    StoreHours = detail.StoreHours,
                    IsFavorite = detail.IsFavorite,
                    IsRecommended = detail.IsRecommended,
                    IsParkingEasy = detail.IsParkingEasy,
                    IsDiningOutside = detail.IsDiningOutside,
                    IsDriveThru = detail.IsDriveThru,
                    IsWifiAvailable = detail.IsWifiAvailable,
                    


                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoffeeShopEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCoffeeShopServices();

            if (service.UpdateCoffeeShop(model))
            {
                TempData["SaveResult"] = "Your Coffee Shop was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Coffee Shop could not be updated.");
            return View(model);
        }

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateCoffeeShopServices();
        //    var model = svc.GetCoffeeShopById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateCoffeeShopServices();

        //    service.DeleteCoffeeShop(id);

        //    TempData["SaveResult"] = "Your Coffee Shop was deleted";

        //    return RedirectToAction("Index");
        //}


        private CoffeeShopService CreateCoffeeShopServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CoffeeShopService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCoffeeShopServices();
            var model = svc.GetCoffeeShopById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCoffeeShopServices();

            service.DeleteCoffeeShop(id);

            TempData["SaveResult"] = "Your Coffee Shop was deleted";

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    CoffeeShop coffeeshop = _db.CoffeeShops.Find(id);
        //    if (coffeeshop == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(coffeeshop);
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    CoffeeShop coffeeshop = _db.CoffeeShops.Find(id);
        //    _db.CoffeeShops.Remove(coffeeshop);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CoffeeShop coffeeshop = _db.CoffeeShops.Find(id);
        //    if (coffeeshop == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(coffeeshop);
        //}

        //// POST : Edit
        //// CoffeeShop/Edit/{id}
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(CoffeeShop coffeeshop)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Entry(coffeeshop).State = EntityState.Modified;
        //        _db.SaveChanges(); return RedirectToAction("Index");
        //    }
        //    return View(coffeeshop);
        //}

        //// GET : Details
        //// CoffeeShop/Details/{id}
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CoffeeShop coffeeshop = _db.CoffeeShops.Find(id);
        //    if (coffeeshop == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(coffeeshop);
        //}
    }
    }