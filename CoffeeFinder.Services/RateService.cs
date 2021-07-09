﻿using CoffeeFinder.Data;
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
                    .Where(e => e.Id == e.Id)
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
                            //Rating = e.Rating,
                        }
                        );
                return query.ToArray();
            }
        }

        
        //READ
        public RateDetail GetRateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                 ctx
                  .Rates
                  .Single(e => e.Id == id && e.Id == id);
                return
                    new RateDetail
                    {
                        Id = entity.Id,
                        CoffeeShopId = entity.CoffeeShopId,
                        CustomerService = entity.CustomerService,
                        CoffeeSelection = entity.CoffeeSelection,
                        Cleanliness = entity.Cleanliness,
                        AvailableAmenities = entity.AvailableAmenities,
                        
                    };
            }
        }


        //UPDATE
        public bool UpdateRate(RateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Rates
                    .SingleOrDefault(e => e.Id == model.Id
                && e.CoffeeShopId == model.CoffeeShopId);

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
        public bool DeleteRate(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rates
                        .Single(e => e.Id == id && //e.Id == _userId);
                        e.CoffeeShopId == e.CoffeeShopId);

                ctx.Rates.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
