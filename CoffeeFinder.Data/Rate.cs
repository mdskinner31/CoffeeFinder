using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Data
{
    public class Rate
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }

        //[ForeignKey(nameof(CoffeeShop))]
        public int CoffeeShopId { get; set; }

        [ForeignKey("CoffeeShopId")]
        public virtual CoffeeShop CoffeeShop { get; set; }

        [Required,Range(0,10)]
        public double CustomerService { get; set; }

        [Required,Range(0, 10)]
        public double CoffeeSelection { get; set; }

        [Required,Range(0, 10)]
        public double Cleanliness { get; set; }

        [Required,Range(0, 10)]
        public double AvailableAmenities { get; set; }

        public double Rating
        {
            get
            {
                var totalAverageRating = CustomerService + CoffeeSelection + Cleanliness + AvailableAmenities;
                return totalAverageRating / 4;
            }
        }
    }
}
