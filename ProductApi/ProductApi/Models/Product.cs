﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "productNumber")]
        public string ProductNumber { get; set; }

        [Required]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required]
        [Range(10, 90)]
        [Display(Name = "price")]
        public double? Price { get; set; }

        [Required]
        [Display(Name = "department")]
        public string Department { get; set; }
         
        [Required]
        [Display(Name = "dateModified")]
        public virtual DateTime DateModified { get; set; }

        [Required]
        [Display(Name = "review")]
        public virtual List<Review> Reviews { get; set; }

        [Required]
        [Display(Name = "relatedProducts")]
        public virtual List<RelatedProduct> RelatedProducts {get; set;}
    }

    public class ProductPatch
    {
        [Display(Name = "productNumber")]
        public string ProductNumber { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Range(10, 90)]
        [Display(Name = "price")]
        public double? Price { get; set; }

        [Display(Name = "department")]
        public string Department { get; set; }

        [Display(Name = "dateModified")]
        public virtual DateTime DateModified { get; set; }

        [Display(Name = "review")]
        public virtual List<Review> Reviews { get; set; }

        [Display(Name = "relatedProduct")]
        public virtual List<RelatedProduct> RelatedProducts { get; set; }
    }
}
