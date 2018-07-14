namespace PrincePortalWeb.Migrations.SupplierContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeback2datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.suppliers", "Whencompliant", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.suppliers", "Reviewdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.suppliers", "Reviewdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.suppliers", "Whencompliant", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
