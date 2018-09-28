namespace AMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AMSv12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AMSTable", "Day", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AMSTable", "Day");
        }
    }
}
