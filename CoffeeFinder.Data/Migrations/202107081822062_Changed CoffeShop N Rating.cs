namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCoffeShopNRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CoffeeShop", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeShop", "Rating", c => c.Double(nullable: false));
        }
    }
}
