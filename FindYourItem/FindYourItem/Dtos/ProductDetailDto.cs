using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FindYourItem.Models;
using System.Web;

namespace FindYourItem.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        
        public string Name { get; set; } //will delete later on


        [Range(1, 200)]
        public float Price { get; set; }

        [Range(1, 200)]
        public int Quantity { get; set; }


        [Required]
        [StringLength(255)]
        

        public string AisleNumber { get; set; }


        [Required]
        [StringLength(255)]
        public string Location { get; set; }


        
        public int ProductNameId { get; set; }

        public AdminDetail AdminDetail { get; set; }

        public int AdminDetailStoreId { get; set; }

    }
}