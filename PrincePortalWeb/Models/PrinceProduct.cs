namespace PrincePortalWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrinceProduct
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string ProductGroup { get; set; }

       


    }
}
