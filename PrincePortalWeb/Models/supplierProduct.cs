namespace PrincePortalWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class supplierProduct
    {
        [Key]
        public int productID { get; set; }

        [StringLength(50)]
        public string productname { get; set; }

        [Required]
        [StringLength(50)]
        public string productcode { get; set; }

        [StringLength(50)]
        public string productgroup { get; set; }

        public int? PrinceProductCode { get; set; }

      

    }
}
