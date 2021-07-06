namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRateClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoffeeShopId = c.Int(nullable: false),
                        CustomerService = c.Double(nullable: false),
                        CoffeeSelection = c.Double(nullable: false),
                        Cleanliness = c.Double(nullable: false),
                        AvailableAmenities = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoffeeShop", t => t.CoffeeShopId, cascadeDelete: true)
                .Index(t => t.CoffeeShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rate", "CoffeeShopId", "dbo.CoffeeShop");
            DropIndex("dbo.Rate", new[] { "CoffeeShopId" });
            DropTable("dbo.Rate");
        }
    }
}
