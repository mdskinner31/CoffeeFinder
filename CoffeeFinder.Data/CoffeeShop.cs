using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Data
{
   public class CoffeeShop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public double OverallRating { get; set; }

        public virtual Ratings Ratings { get; set; }

        public string MenuItemsId { get; set; }

        public virtual MenuItems MenuItem { get; set; }

        public string StoreHours { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsRecommended { get; set; }

        public bool IsParkingEasy { get; set; }

        public bool IsDiningOutside { get; set; }

        public bool IsDriveThru { get; set; }

        public bool IsWifiAvailable { get; set; }

        public bool IsFavorite { get; set; }
        public bool IsFavorite { get; set; }






    }
}
