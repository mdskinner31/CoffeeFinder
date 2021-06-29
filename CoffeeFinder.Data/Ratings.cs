using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Data
{
   public class Ratings
    {
        public int Id { get; set; }

        public double CustomerService { get; set; }

        public double CoffeeSelection { get; set; }

        public double Cleanliness { get; set; }

        public double AvailableAmenities { get; set; }

        public double OverallRating { get; set; }
    }
}
