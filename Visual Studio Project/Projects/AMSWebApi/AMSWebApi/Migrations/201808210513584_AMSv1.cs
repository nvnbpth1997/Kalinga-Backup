namespace AMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AMSv1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AMSTable", new[] { "MID" });
            DropIndex("dbo.AMSTable", new[] { "Mobile" });
            DropIndex("dbo.AMSTable", new[] { "Email" });
            AlterColumn("dbo.AMSTable", "MID", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.AMSTable", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AMSTable", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AMSTable", "Mobile", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.AMSTable", "Email", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.AMSTable", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.AMSTable", "SwipeInTime", c => c.String(nullable: false));
            CreateIndex("dbo.AMSTable", "MID", unique: true);
            CreateIndex("dbo.AMSTable", "Mobile", unique: true);
            CreateIndex("dbo.AMSTable", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AMSTable", new[] { "Email" });
            DropIndex("dbo.AMSTable", new[] { "Mobile" });
            DropIndex("dbo.AMSTable", new[] { "MID" });
            AlterColumn("dbo.AMSTable", "SwipeInTime", c => c.String());
            AlterColumn("dbo.AMSTable", "Gender", c => c.String());
            AlterColumn("dbo.AMSTable", "Email", c => c.String(maxLength: 450));
            AlterColumn("dbo.AMSTable", "Mobile", c => c.String(maxLength: 10));
            AlterColumn("dbo.AMSTable", "LastName", c => c.String());
            AlterColumn("dbo.AMSTable", "FirstName", c => c.String());
            AlterColumn("dbo.AMSTable", "MID", c => c.String(maxLength: 8));
            CreateIndex("dbo.AMSTable", "Email", unique: true);
            CreateIndex("dbo.AMSTable", "Mobile", unique: true);
            CreateIndex("dbo.AMSTable", "MID", unique: true);
        }
    }
}
