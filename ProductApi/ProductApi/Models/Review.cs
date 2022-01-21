using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Review
    {
        [Key]
        [Required]
        [Display(Name = "reviewNumber")]
        public string ReviewNumber { get; set; }

        [Required]
        [Range(1, 5)]
        [Display(Name = "rating")]
        public int? Rating { get; set; }

        [Required]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "reviewBody")]
        public string ReviewBody { get; set; }
    }
}
