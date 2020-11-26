using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public short? GenreId { get; set; }

        
        [Required]
        [Display(Name = "Date of Release")]
        public DateTime? ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Title 
        {
            get
            {
                return (Id != 0 ? "Edit Movie" : "New Movie");
            }
        }


        public MovieFormViewModel()
        {

            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            GenreId = movie.GenreId;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}