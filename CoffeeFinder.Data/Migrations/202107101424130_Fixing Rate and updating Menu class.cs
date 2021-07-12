namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingRateandupdatingMenuclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rate", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Menu", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "OwnerId");
            DropColumn("dbo.Rate", "OwnerId");
        }
    }
}
