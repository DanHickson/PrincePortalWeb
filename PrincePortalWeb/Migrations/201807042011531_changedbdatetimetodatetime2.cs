namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedbdatetimetodatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LastLogDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastLogDateTime", c => c.DateTime(nullable: false));
        }
    }
}
