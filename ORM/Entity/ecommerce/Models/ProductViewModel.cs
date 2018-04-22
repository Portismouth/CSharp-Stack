using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class NewProduct : BaseEntity
    {
        [Required(ErrorMessage = "You must enter a first name!")]
        [MinLength(2, ErrorMessage = "First Name must be at least {1} characters!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter an image URL.")]
        [DataType(DataType.ImageUrl)]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Let your customers know a little more about your product.")]
        [MinLength(2, ErrorMessage = "First Name must be at least {1} characters!")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than $0")]
        public float ProductPrice { get; set; }

        [Required(ErrorMessage = "Please enter a starting quantity!")]
        public int ProductInventory { get; set; }
    }
}