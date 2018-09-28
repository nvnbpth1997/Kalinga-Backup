namespace BookStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbBookDetails", "Book_Title", c => c.String(nullable: false));
            AlterColumn("dbo.tbBookDetails", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbBookDetails", "Location", c => c.String());
            AlterColumn("dbo.tbBookDetails", "Book_Title", c => c.String());
        }
    }
}
