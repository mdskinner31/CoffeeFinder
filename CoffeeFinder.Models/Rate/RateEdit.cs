using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Models
{
    public class RateEdit
    {
        public int Id { get; set; }

        public int CoffeeShopId { get; set; }

        public string Name { get; set; }

        public double CustomerService { get; set; }

        public double CoffeeSelection { get; set; }

        public double Cleanliness { get; set; }

        public double AvailableAmenities { get; set; }

        
    }
}
