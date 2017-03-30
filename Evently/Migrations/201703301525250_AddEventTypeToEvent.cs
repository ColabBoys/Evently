namespace Evently.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTypeToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Events", "EventTypeId");
            AddForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropColumn("dbo.Events", "EventTypeId");
        }
    }
}
