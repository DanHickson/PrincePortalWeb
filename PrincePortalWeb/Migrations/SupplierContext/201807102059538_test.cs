namespace PrincePortalWeb.Migrations.SupplierContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.suppliers", "status", c => c.Int());
            AlterColumn("dbo.suppliers", "Whencompliant", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.suppliers", "Reviewdate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.suppliers", "Reviewdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.suppliers", "Whencompliant", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.suppliers", "status", c => c.Int(nullable: false));
        }
    }
}
