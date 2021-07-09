using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeFinder.WebMVC.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateMenuService();

            if (service.CreateMenu(model))
            {
                TempData["SaveResult"] = "Your rate was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Rate could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMenuService();
            var model = svc.GetMenuById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMenuService();
            var detail = service.GetByMenuId(id);
            var model =
                new MenuEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Description = detail.Description,
                    Price = detail.Price,
                    MiRating = detail.MiRating,
                    IsRecommended = detail.IsRecommended
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMenuService();

            if (service.UpdateMenu(model))
            {
                TempData["SaveResult"] = "Your Menu was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Menu could not be updated.");
            return View();
        }



        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMenuService();
            var model = svc.GetMenuById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMenuService();

            service.DeleteMenu(id);

            TempData["SaveResult"] = "Your menu has been deleted.";

            return RedirectToAction("Index");
        }

        private MenuService CreateMenuService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MenuService(userId);
            return service;
        }


    }
}