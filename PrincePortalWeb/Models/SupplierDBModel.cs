namespace PrincePortalWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    using System.Runtime.Serialization;
    using System.Web.Mvc;

    public partial class SupplierDBModel : DbContext
    {




        public SupplierDBModel()
            : base("name=SupplierDBModel")
        {


            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupplierDBModel, EF6Console.Migrations.Configuration>());


        }

        public virtual DbSet<supplier> suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }

    public partial class supplier
    {

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int supplierid { get; set; }

        [Required]
        [StringLength(50)]
        public string suppliername { get; set; }

        [StringLength(50)]
        public string address1 { get; set; }

        [StringLength(50)]
        public string county { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }

        [StringLength(50)]
        public string address2 { get; set; }

        [StringLength(11)]
        public string postcode { get; set; }

        [StringLength(20)]
        public string webstatus { get; set; }


        public status? status { get; set; }

        [StringLength(50)]
        public string LastreviewedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Whencompliant { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Reviewdate { get; set; }



    }

    public enum status
    {


        InProgress,
        Started,
        NotStarted,


    }

}
