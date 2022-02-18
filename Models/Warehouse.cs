namespace Accounting_of_Goods_ver_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.Entrances = new HashSet<Entrance>();
        }
    
        [Required]
        [Range(0, 10000)]
        public int Number { get; set; }

        [Required]
        [StringLength(100)]
        public string full_name_of_the_torekeeper { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrance> Entrances { get; set; }
    }
}
