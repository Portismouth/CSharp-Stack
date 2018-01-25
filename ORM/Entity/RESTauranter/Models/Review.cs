using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace RESTauranter.Models
{
    public class Review : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Please enter your name.")]
        public string ReviewerName { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Please the name of the restaurant you want to review.")]
        public string RestName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please add a review")]
        public string RestReview { get; set; }

        [Required]
        public DateTime VisitDate { get; set;}

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        public bool Helpful { get; set; }
    }
}