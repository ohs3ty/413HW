using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW3_413.Models
{
    public class MovieResponse
    {
        [Key]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Please input a title.")]  
        [MovieTitleValidation]
        public string Title { get; set; } 

        [Required(ErrorMessage = "Please input a category.")]
        public string Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please input a director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please input a rating.")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

        
    }
}
