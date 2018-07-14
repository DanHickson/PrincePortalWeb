namespace PrincePortalWeb.Migrations.ProductsContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrinceProducts",
                c => new
                {
                    ProductID = c.Int(nullable: false, identity: true),
                    ProductCode = c.String(nullable: false, maxLength: 50),
                    ProductName = c.String(maxLength: 100),
                    ProductGroup = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.ProductID);

            CreateTable(
                "dbo.supplierProducts",
                c => new
                {
                    productID = c.Int(nullable: false, identity: true),
                    productname = c.String(maxLength: 50),
                    productcode = c.String(nullable: false, maxLength: 50),
                    productgroup = c.String(maxLength: 50),
                    PrinceProductCode = c.Int(),
                })
                .PrimaryKey(t => t.productID);

        }
        
        public override void Down()
        {
            DropTable("dbo.supplierProducts");
            DropTable("dbo.PrinceProducts");
        }
    }
}
