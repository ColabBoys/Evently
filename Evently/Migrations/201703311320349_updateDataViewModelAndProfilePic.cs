namespace Evently.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataViewModelAndProfilePic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserPhoto");
            DropColumn("dbo.Events", "Address");
        }
    }
}
