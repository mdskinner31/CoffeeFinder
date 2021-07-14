namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "CoffeeShopId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "CoffeeShopId");
        }
    }
}
