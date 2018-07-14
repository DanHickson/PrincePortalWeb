namespace PrincePortalWeb.Migrations.ProductsContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetestfieldmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PrinceProducts", "testfield");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrinceProducts", "testfield", c => c.String(maxLength: 50));
        }
    }
}
