namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRatefromservicesncontroller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeShop", "OverallRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CoffeeShop", "OverallRating");
        }
    }
}
