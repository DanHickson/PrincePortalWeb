namespace PrincePortalWeb.Migrations.ProductsContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtestfieldmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrinceProducts", "testfield", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrinceProducts", "testfield");
        }
    }
}
