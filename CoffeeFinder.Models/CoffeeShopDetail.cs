using CoffeeFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Models
{
    public class CoffeeShopDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }


        public string City { get; set; }


        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }


        public string Phone { get; set; }

        public string Website { get; set; }



        /*public virtual Rate Rates { get; set; }*/



        /*public virtual MenuItems MenuItem { get; set; }
        */
        [Display(Name = "Store Hours")]
        public string StoreHours { get; set; }

        [Display(Name = "Is this your Favorite?")]
        public bool IsFavorite { get; set; }
        [Display(Name = "Would you Recommend?")]
        public bool IsRecommended { get; set; }
        [Display(Name = "Is Parking Easy?")]
        public bool IsParkingEasy { get; set; }
        [Display(Name = "Is there seating outside?")]
        public bool IsDiningOutside { get; set; }
        [Display(Name = "Is there a Drive Thru?")]
        public bool IsDriveThru { get; set; }
        [Display(Name = "Is WiFi available?")]
        public bool IsWifiAvailable { get; set; }
        [Display(Name = "Overall Rating")]

        public virtual List<Rate> Rates { get; set; } = new List<Rate>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rate in Rates)
                {
                    totalAverageRating += rate.AverageRating;
                }

                return Rates.Count > 0
                    ? Math.Round(totalAverageRating / Rates.Count, 2) : 0;
            }

        }
    }
}
