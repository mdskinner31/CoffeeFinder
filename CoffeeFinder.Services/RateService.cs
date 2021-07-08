using CoffeeFinder.Data;
using CoffeeFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Services
{
   public class RateService
    {
        private readonly Guid _userId;
        public RateService(Guid userId)
        {
            _userId = userId;
        }
        //CREATE
        public bool CreateRate(RateCreate model)
        {
            var entity = new Rate()
            {
                Id = model.Id,
                CoffeeShopId = model.CoffeeShopId,
               
                CustomerService = model.CustomerService,
                CoffeeSelection = model.CoffeeSelection,
                Cleanliness = model.Cleanliness,
                AvailableAmenities = model.AvailableAmenities,
                //OverallRating = model.OverallRating

            };
             using (var ctx = new ApplicationDbContext())
            {
                ctx.Rates.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RateListItem> GetRates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Rates
                    .Where(e => e.Id == e.CoffeeShopId )
                    .Select(
                        e =>
                        new RateListItem
                        {
                            Id = e.Id,
                            CoffeeShopId = e.CoffeeShopId,
                            CustomerService = e.CustomerService,
                            CoffeeSelection = e.CoffeeSelection,
                            Cleanliness = e.Cleanliness,
                            AvailableAmenities = e.AvailableAmenities,
                        }
                        );
                return query.ToArray();
            }
        }
        //READ


        //UPDATE
        public bool UpdateRate(RateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Rates
                    .Single(e => e.Id == model.Id);
                //&& e.OwnerId == _userId);

                entity.Id = model.Id;
                entity.CoffeeShopId = model.CoffeeShopId;
                entity.CustomerService = model.CustomerService;
                entity.CoffeeSelection = model.CoffeeSelection;
                entity.Cleanliness = model.Cleanliness;
                entity.AvailableAmenities = model.AvailableAmenities;

                return ctx.SaveChanges() == 1;
            }
        }
        //DELETE
        //public bool DeleteRate(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Rates
        //                .Single(e => e.Id == Id && Id = e.CoffeeShopIdId);

        //        ctx.Rates.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
