using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int ProductInventory { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}