namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMenuClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CoffeeShop", "OwnerId");
            DropColumn("dbo.Menu", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.CoffeeShop", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
