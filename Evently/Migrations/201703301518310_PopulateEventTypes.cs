namespace Evently.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEventTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (1, 'Private')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (2, 'Public')");
        }
        
        public override void Down()
        {
        }
    }
}
