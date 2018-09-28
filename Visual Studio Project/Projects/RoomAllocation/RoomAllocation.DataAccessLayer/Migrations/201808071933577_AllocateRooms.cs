namespace RoomAllocation.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllocateRooms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocatedRoom",
                c => new
                    {
                        AllocateRoomID = c.Int(nullable: false, identity: true),
                        roomID = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllocateRoomID)
                .ForeignKey("dbo.Room", t => t.roomID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userID, cascadeDelete: true)
                .Index(t => t.roomID, unique: true)
                .Index(t => t.userID, unique: true);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        roomID = c.Int(nullable: false, identity: true),
                        room_RID = c.String(),
                        room_blockName = c.String(),
                        room_floorNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.roomID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        user_mid = c.String(),
                        user_name = c.String(),
                        user_trackName = c.String(),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocatedRoom", "userID", "dbo.User");
            DropForeignKey("dbo.AllocatedRoom", "roomID", "dbo.Room");
            DropIndex("dbo.AllocatedRoom", new[] { "userID" });
            DropIndex("dbo.AllocatedRoom", new[] { "roomID" });
            DropTable("dbo.User");
            DropTable("dbo.Room");
            DropTable("dbo.AllocatedRoom");
        }
    }
}
