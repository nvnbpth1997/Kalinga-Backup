namespace AMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AMSv15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageURL", c => c.String());
            DropColumn("dbo.Images", "ImageContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImageContent", c => c.Binary());
            DropColumn("dbo.Images", "ImageURL");
        }
    }
}
