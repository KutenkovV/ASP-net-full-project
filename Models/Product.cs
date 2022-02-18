namespace Accounting_of_Goods_ver_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Entrances = new HashSet<Entrance>();
            this.Entrance_2 = new HashSet<Entrance_2>();
        }
    
        public int Registration_number { get; set; }

        [Required]
        [StringLength(50)]
        public string name_of_the_company { get; set; }
        
        [Required]
        [StringLength(25)]
        public string Units_of_measurement { get; set; }

        [Required]
        [Range(5, 10000)]
        public int Cost_of_change { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrance> Entrances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrance_2> Entrance_2 { get; set; }
    }
}
