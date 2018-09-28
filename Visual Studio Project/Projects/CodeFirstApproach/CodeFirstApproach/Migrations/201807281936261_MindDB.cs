namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MindDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mind", "TrackId", "dbo.Track");
            DropPrimaryKey("dbo.Track");
            AddColumn("dbo.Track", "Track_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Track", "Track_Name", c => c.String());
            AddPrimaryKey("dbo.Track", "Track_Id");
            AddForeignKey("dbo.Mind", "TrackId", "dbo.Track", "Track_Id");
            DropColumn("dbo.Track", "TrackId");
            DropColumn("dbo.Track", "TrackName");
            DropColumn("dbo.Track", "RoomAllocated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Track", "RoomAllocated", c => c.String());
            AddColumn("dbo.Track", "TrackName", c => c.String());
            AddColumn("dbo.Track", "TrackId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Mind", "TrackId", "dbo.Track");
            DropPrimaryKey("dbo.Track");
            DropColumn("dbo.Track", "Track_Name");
            DropColumn("dbo.Track", "Track_Id");
            AddPrimaryKey("dbo.Track", "TrackId");
            AddForeignKey("dbo.Mind", "TrackId", "dbo.Track", "TrackId");
        }
    }
}
