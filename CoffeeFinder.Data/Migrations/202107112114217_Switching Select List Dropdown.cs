namespace CoffeeFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchingSelectListDropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rate", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rate", "OwnerId");
        }
    }
}
