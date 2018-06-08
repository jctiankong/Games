using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIGameTable.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        public string RatingValue { get; set; }
        public string Description { get; set; }
    }
}