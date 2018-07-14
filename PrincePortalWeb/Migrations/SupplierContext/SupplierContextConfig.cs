namespace PrincePortalWeb.Migrations.SupplierContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SupplierContextConfig : DbMigrationsConfiguration<PrincePortalWeb.Models.SupplierDBModel>
    {
        public SupplierContextConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SupplierContext";
        }

        protected override void Seed(PrincePortalWeb.Models.SupplierDBModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
