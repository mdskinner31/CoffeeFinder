namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMenuControllersIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "OwnerId");
        }
    }
}
