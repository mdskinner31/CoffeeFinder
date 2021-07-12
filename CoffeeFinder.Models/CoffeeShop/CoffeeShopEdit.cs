using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Models
{
    public class CoffeeShopEdit
    {
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        
        public string Name { get; set; }

        
        public string StreetAddress { get; set; }

        
        public string City { get; set; }

        
        public string State { get; set; }

        
        public string ZipCode { get; set; }


        public string Phone { get; set; }

        public string Website { get; set; }

        /*public virtual Ratings Ratings { get; set; }
        */


        /*public virtual MenuItems MenuItem { get; set; }
        */
        public string StoreHours { get; set; }

       // [Display(Name = "Is this your Favorite?")]
        public bool IsFavorite { get; set; }
        //[Display(Name = "Would you Recommend?")]
        public bool IsRecommended { get; set; }
        //[Display(Name = "Is Parking Easy?")]
        public bool IsParkingEasy { get; set; }
        //[Display(Name = "Is there seating outside?")]
        public bool IsDiningOutside { get; set; }
        //[Display(Name = "Is there a Drive Thru?")]
        public bool IsDriveThru { get; set; }
        //[Display(Name = "Is WiFi available?")]
        public bool IsWifiAvailable { get; set; }

        
    }
}
