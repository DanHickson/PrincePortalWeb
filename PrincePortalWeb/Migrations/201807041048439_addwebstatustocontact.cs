namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwebstatustocontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "webStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "webStatus");
        }
    }
}
