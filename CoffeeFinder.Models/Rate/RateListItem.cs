using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Models
{
    public class RateListItem
    {
        public int Id { get; set; }

        [Display(Name = "Coffee Shop")]
        public int CoffeeShopId {get; set;}

        public string Name { get; set; }

        [Display(Name = "Customer Service Rating")]
        public double CustomerService { get; set; }

        [Display(Name = "Coffee Selection Rating")]
        public double CoffeeSelection { get; set; }

        [Display(Name = "Cleanliness Rating")]
        public double Cleanliness { get; set; }

        [Display(Name = "Available Amenities Rating")]
        public double AvailableAmenities { get; set; }

        [Display(Name = "Average Rating")]
        public double Rating //{ get; set; }
        { get

            {
                var totalAverageRating = CustomerService + CoffeeSelection + Cleanliness + AvailableAmenities;
                return totalAverageRating / 4;
            }
}
    }
}
