namespace PrincePortalWeb.Migrations.ProductsContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ProductsContextConfig : DbMigrationsConfiguration<PrincePortalWeb.Products>
    {
        public ProductsContextConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ProductsContext";
        }

        protected override void Seed(PrincePortalWeb.Products context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
