namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameasusername : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "firstName");
            DropColumn("dbo.AspNetUsers", "lastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
        }
    }
}
