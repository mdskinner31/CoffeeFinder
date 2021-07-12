using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Models
{
    public class MenuListItem
    {
        public int Id { get; set; }

        public int CoffeeShopId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double MiRating { get; set; }

        public bool IsRecommended { get; set; }
    }
}
