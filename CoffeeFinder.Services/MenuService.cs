using CoffeeFinder.Data;
using CoffeeFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Services
{
    public class MenuService
    {
        private readonly Guid _userId;

        public MenuService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMenu(MenuCreate model)
        {
            var entity =
                new Menu()
            {
                 OwnerId = _userId,
                 Id = model.Id,
                 Name = model.Name,
                 Description = model.Description,
                 Price = model.Price,
                 MiRating = model.MiRating,
                 IsRecommended = model.IsRecommended,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menus.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    

        public IEnumerable<MenuListItem> GetMenus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Menus
                    .Where(e => e.Id == e.Id)
                    .Select(
                        e =>
                            new MenuListItem
                            {
                                 Id = e.Id,
                                 Name = e.Name,
                                 Description = e.Description,
                                 Price = e.Price,
                                 MiRating = e.MiRating,
                                 IsRecommended = e.IsRecommended,


                            }
                    );

            return query.ToArray();
            }
    }
    public MenuDetail GetMenuById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.Id == id && e.Id == e.Id);
            return
                new MenuDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                    MiRating = entity.MiRating,
                    IsRecommended = entity.IsRecommended,
                };
        }
    }

    public bool UpdateMenu(MenuEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.Id == model.Id && e.Id == e.Id);

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.MiRating = model.MiRating;
            entity.IsRecommended = model.IsRecommended;

            return ctx.SaveChanges() == 1;
        }
    }

        public bool DeleteMenu(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                    .Menus
                    .Single(e => e.Id == id);// && e.CoffeeShopId == e.CoffeeShopId);

                ctx.Menus.Remove(entity);

                return ctx.SaveChanges() == 1;
        }
    }
  }
}

