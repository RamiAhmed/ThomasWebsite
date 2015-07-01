namespace ThomasWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPublished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogModels", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogModels", "IsPublished");
        }
    }
}
