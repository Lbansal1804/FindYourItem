using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FindYourItem.Models
{
    public class AdminDetail
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        
        [Required]
        [StringLength(255)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }


        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }


        [Required]
        [StringLength(255)]
        public string Location { get; set; }
    }
}