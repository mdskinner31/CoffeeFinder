namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMenuControllersIndexagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menu", "CoffeeShopId", "dbo.CoffeeShop");
            DropIndex("dbo.Menu", new[] { "CoffeeShopId" });
            DropColumn("dbo.Menu", "CoffeeShopId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "CoffeeShopId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menu", "CoffeeShopId");
            AddForeignKey("dbo.Menu", "CoffeeShopId", "dbo.CoffeeShop", "Id", cascadeDelete: true);
        }
    }
}
