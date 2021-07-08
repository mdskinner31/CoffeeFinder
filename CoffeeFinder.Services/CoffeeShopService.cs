using CoffeeFinder.Data;
using CoffeeFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Services
{
    public class CoffeeShopService
    {
        private readonly Guid _userId;

        public CoffeeShopService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCoffeeShop(CoffeeShopCreate model)
        {
            var entity =
                new CoffeeShop()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Phone = model.Phone,
                    Website = model.Website,
                   
                    StoreHours = model.StoreHours,
                    IsFavorite = model.IsFavorite,
                    IsRecommended = model.IsRecommended,
                    IsParkingEasy = model.IsParkingEasy,
                    IsDiningOutside = model.IsDiningOutside,
                    IsDriveThru = model.IsDriveThru,
                    IsWifiAvailable = model.IsWifiAvailable,



                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CoffeeShops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<CoffeeShopListItem> GetCoffeeShops()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CoffeeShops
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CoffeeShopListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    StreetAddress = e.StreetAddress,
                                    City = e.City,
                                    State = e.State,
                                    ZipCode = e.ZipCode,
                                    Phone = e.Phone,
                                    Website = e.Website,
                                    StoreHours = e.StoreHours,
                                    IsFavorite = e.IsFavorite,
                                    IsRecommended = e.IsRecommended,
                                    IsParkingEasy = e.IsParkingEasy,
                                    IsDiningOutside = e.IsDiningOutside,
                                    IsDriveThru = e.IsDriveThru,
                                    IsWifiAvailable = e.IsWifiAvailable,
                                   // OverallRating = e.OverallRating
                                }
                        );

                return query.ToArray();
            }
        }
        public CoffeeShopDetail GetCoffeeShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CoffeeShops
                        .Single(e => e.Id == id &&  e.OwnerId == _userId );
                return
                    new CoffeeShopDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        Phone = entity.Phone,
                        Website = entity.Website,
                        StoreHours = entity.StoreHours,
                        IsFavorite = entity.IsFavorite,
                        IsRecommended = entity.IsRecommended,
                        IsParkingEasy = entity.IsParkingEasy,
                        IsDiningOutside = entity.IsDiningOutside,
                        IsDriveThru = entity.IsDriveThru,
                        IsWifiAvailable = entity.IsWifiAvailable,
                        
                    };
            }
        }

        public bool UpdateCoffeeShop(CoffeeShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CoffeeShops
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);
                        
                        entity.Id = model.Id;
                        entity.Name = model.Name;
                        entity.StreetAddress = model.StreetAddress;
                        entity.City = model.City;
                        entity.State = model.State;
                        entity.ZipCode = model.ZipCode;
                        entity.Phone = model.Phone;
                        entity.Website = model.Website;
                        entity.StoreHours = model.StoreHours;
                        entity.IsFavorite = model.IsFavorite;
                        entity.IsRecommended = model.IsRecommended;
                        entity.IsParkingEasy = model.IsParkingEasy;
                        entity.IsDiningOutside = model.IsDiningOutside;
                        entity.IsDriveThru = model.IsDriveThru;
                        entity.IsWifiAvailable = model.IsWifiAvailable;
                        




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCoffeeShop(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CoffeeShops
                        .Single(e => e.Id == id && e.OwnerId == _userId);

                ctx.CoffeeShops.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
