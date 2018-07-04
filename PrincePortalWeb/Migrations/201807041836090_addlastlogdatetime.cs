namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlastlogdatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastLogDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastLogDateTime");
        }
    }
}
