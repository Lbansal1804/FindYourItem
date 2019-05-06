using System;
using System.Collections.Generic;
using System.Linq;
using FindYourItem.Models;
using System.Web;

namespace FindYourItem.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<ProductName> ProductNames { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}