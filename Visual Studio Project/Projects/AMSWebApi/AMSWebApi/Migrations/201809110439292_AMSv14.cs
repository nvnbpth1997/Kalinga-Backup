namespace AMSWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AMSv14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageContent = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Images");
        }
    }
}
