namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RateDetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CoffeeShop", "OverallRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeShop", "OverallRating", c => c.Double(nullable: false));
        }
    }
}
