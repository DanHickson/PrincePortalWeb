namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfirstlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstLogin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "firstLogin");
        }
    }
}
