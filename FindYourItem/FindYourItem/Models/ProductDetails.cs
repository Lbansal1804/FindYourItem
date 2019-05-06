using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindYourItem.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } //will delete later on

        
        [Range(1,200)]
        public float Price { get; set; }

        [Range(1, 200)]
        public int Quantity { get; set; }


        [Required]
        [StringLength(255)]
        [Display (Name = "Aisle No.")]
        public string AisleNumber { get; set; }


        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        public ProductName ProductName { get; set; } //Navigation Property


        [Display(Name = "Product")]
        public int ProductNameId { get; set; }

        public AdminDetail AdminDetail { get; set; }

        public int AdminDetailStoreId{ get; set; }

    }
}