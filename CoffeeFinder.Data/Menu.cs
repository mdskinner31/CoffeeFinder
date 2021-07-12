using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeFinder.Data
{
    public class Menu
    {
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        //public int CoffeeShopId { get; set; }
        //[ForeignKey("CoffeeShopId")]

        //public virtual CoffeeShop CoffeeShop { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double MiRating { get; set; }

        public bool IsRecommended { get; set; }
    }
}
