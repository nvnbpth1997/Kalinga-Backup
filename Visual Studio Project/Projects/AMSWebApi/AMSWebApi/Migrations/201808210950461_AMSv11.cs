namespace AMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AMSv11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AMSTable", "SwipeStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AMSTable", "SwipeStatus");
        }
    }
}
