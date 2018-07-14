namespace PrincePortalWeb.Migrations.SupplierContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.suppliers",
                c => new
                {
                    supplierid = c.Int(nullable: false, identity: true),
                    suppliername = c.String(nullable: false, maxLength: 50),
                    address1 = c.String(maxLength: 50),
                    county = c.String(maxLength: 50),
                    country = c.String(maxLength: 50),
                    telephone = c.String(maxLength: 50),
                    address2 = c.String(maxLength: 50),
                    postcode = c.String(maxLength: 11),
                    webstatus = c.String(maxLength: 20),
                    status = c.String(maxLength: 50),
                    LastreviewedBy = c.String(maxLength: 50),
                    Whencompliant = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Reviewdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    lastreviewedby = c.String(),
                })
                .PrimaryKey(t => t.supplierid);

        }

        public override void Down()
        {
            DropTable("dbo.suppliers");
        }
    }
}
