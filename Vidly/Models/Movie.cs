using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public short GenreId { get; set; }
        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Date of Release")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}