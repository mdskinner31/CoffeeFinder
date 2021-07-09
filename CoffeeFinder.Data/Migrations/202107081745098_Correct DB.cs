namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeShop", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CoffeeShop", "Rating");
        }
    }
}
