namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMenuClass2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeShop", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Rate", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rate", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.CoffeeShop", "OwnerId");
        }
    }
}
