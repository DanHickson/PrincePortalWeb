namespace PrincePortalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupplierInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "supplierId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "supplierName", c => c.String());
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lastName");
            DropColumn("dbo.AspNetUsers", "firstName");
            DropColumn("dbo.AspNetUsers", "supplierName");
            DropColumn("dbo.AspNetUsers", "supplierId");
        }
    }
}
