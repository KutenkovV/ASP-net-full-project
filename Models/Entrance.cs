namespace Accounting_of_Goods_ver_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Entrance
    {
        public int ID { get; set; }
        public int Products_Registration_number { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Warehouse_Number { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Product_quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime delivery_date { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
