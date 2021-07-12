namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRateDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "CoffeeShopId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menu", "CoffeeShopId");
            AddForeignKey("dbo.Menu", "CoffeeShopId", "dbo.CoffeeShop", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "CoffeeShopId", "dbo.CoffeeShop");
            DropIndex("dbo.Menu", new[] { "CoffeeShopId" });
            DropColumn("dbo.Menu", "CoffeeShopId");
        }
    }
}
