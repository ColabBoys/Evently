namespace Evently.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToEventAndAddEventType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventTypes");
        }
    }
}
