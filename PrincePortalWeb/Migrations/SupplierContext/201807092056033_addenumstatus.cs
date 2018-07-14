namespace PrincePortalWeb.Migrations.SupplierContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addenumstatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.suppliers", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.suppliers", "status", c => c.String(maxLength: 50));
        }
    }
}
